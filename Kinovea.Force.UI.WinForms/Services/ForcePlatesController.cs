using Kinovea.Force.BleForcePlates;
using Kinovea.Force.UI.WinForms.Controls;
using Kinovea.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Kinovea.Force.UI.WinForms.Services
{
    public class ForcePlatesController
    {
        private ForcePlateDeviceInfo leftPlateInfo;
        private BleForcePlateDevice leftBleForceDevice;
        private List<ForceMeasurement> leftForceRecordings;

        private ForcePlateDeviceInfo rightPlateInfo;
        private BleForcePlateDevice rightBleForceDevice;
        private List<ForceMeasurement> rightForceRecordings;

        private bool isRecording;
        private DateTime recordingStart;
        private string currentVideoFile;
        
        private object syncRoot = new object();
        private FileSystemWatcher fileWatcher = new FileSystemWatcher();

        public ForceGraphPairUserControl ForceGraph { get; set; }

        public ForcePlatesController() 
        {
            
            fileWatcher.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastWrite;
            fileWatcher.Filter = "*.*";
            fileWatcher.IncludeSubdirectories = false;
            fileWatcher.EnableRaisingEvents = false;
            fileWatcher.Deleted += VideoFileDeleted;
            fileWatcher.Renamed += VideoFileRenamed;

            NotificationCenter.CurrentDirectoryChanged += CurrentDirectoryChanged;
        }

        public void SetDevices(ForcePlateDeviceInfo leftPlateInfo, ForcePlateDeviceInfo rightPlateInfo)
        {
            this.leftPlateInfo = leftPlateInfo;
            if (leftPlateInfo != null && !string.IsNullOrEmpty(leftPlateInfo.DeviceName))
            {
                leftBleForceDevice = new BleForcePlateDevice(leftPlateInfo.DeviceName);
                AttachDeviceEvents(leftBleForceDevice);
            }

            this.rightPlateInfo = rightPlateInfo;
            if (rightPlateInfo != null &&
                !string.IsNullOrEmpty(rightPlateInfo.DeviceName))
            {
                rightBleForceDevice = new BleForcePlateDevice(rightPlateInfo.DeviceName);
                AttachDeviceEvents(rightBleForceDevice);
            }
        }

        public void StartDeviceConnections()
        {
            if (leftBleForceDevice != null)
            {
                leftBleForceDevice.Start();
            }
            if (rightBleForceDevice != null)
            {
                rightBleForceDevice.Start();
            }
        }

        public void RestoreDeviceEvents()
        {
            AttachDeviceEvents(leftBleForceDevice);
            AttachDeviceEvents(rightBleForceDevice);
        }

        private void AttachDeviceEvents(BleForcePlateDevice device)
        {
            device.DeviceConnected += ForceDeviceConnected;
            device.DeviceDisconnected += ForceDeviceDisconnected;
            device.ForceValueReceived += ForceValueReceived;
        }

        public void DetachDeviceEvents()
        {
            DetachDeviceEvents(leftBleForceDevice);
            DetachDeviceEvents(rightBleForceDevice);
        }

        private void DetachDeviceEvents(BleForcePlateDevice device)
        {
            device.DeviceConnected -= ForceDeviceConnected;
            device.DeviceDisconnected -= ForceDeviceDisconnected;
            device.ForceValueReceived -= ForceValueReceived;
        }


        private void ForceDeviceConnected(BleForcePlateDevice device)
        {
            if (device == leftBleForceDevice)
            {
                ForceGraph?.ForceGraphLeft.SetConnectionStatus(true);
            }
            else if (device == rightBleForceDevice)
            {
                ForceGraph?.ForceGraphRight.SetConnectionStatus(true);
            }
        }

        private void ForceDeviceDisconnected(BleForcePlateDevice device)
        {
            if (device == leftBleForceDevice)
            {
                ForceGraph?.ForceGraphLeft.SetConnectionStatus(false);
            }
            else if (device == rightBleForceDevice)
            {
                ForceGraph?.ForceGraphRight.SetConnectionStatus(false);
            }
        }

        private void ForceValueReceived(BleForcePlateDevice device, string value)
        {
            lock (syncRoot)
            {
                if (!isRecording)
                {
                    StopRecording(string.Empty);
                    return;
                }
                ForceMeasurement leftForce = null;
                ForceMeasurement rightForce = null;
                ForceMeasurement force = GetForceMeasurement(value);
                if (force != null)
                {
                    force.TimeMs = (long)(DateTime.Now - recordingStart).TotalMilliseconds;

                    if (device == leftBleForceDevice)
                    {

                        leftForceRecordings.Add(force);
                        leftForce = force;
                        rightForce = GetMeasurementBySequenceNumber(force.SequenceNumber, rightForceRecordings);
                        
                    }
                    else if (device == rightBleForceDevice)
                    {
                        rightForceRecordings.Add(force);
                        rightForce = force;
                        leftForce = GetMeasurementBySequenceNumber(force.SequenceNumber, leftForceRecordings);
                    }
                    if (leftForce != null && rightForce != null)
                    {
                        double totalForce = leftForce.ADC + rightForce.ADC;
                        leftForce.LoadPercentage = Math.Round((leftForce.ADC / totalForce) * 100, 0);
                        rightForce.LoadPercentage = Math.Round((rightForce.ADC / totalForce) * 100, 0);
                        
                        ForceGraph?.ForceGraphLeft.ViewModel.AddMeasurement(leftForce);
                        ForceGraph?.ForceGraphRight.ViewModel.AddMeasurement(rightForce);
                    }
                    
                }
            }

        }

        private ForceMeasurement GetMeasurementBySequenceNumber(long sequenceNumber, List<ForceMeasurement> measurements)
        {
            
            if (measurements.Count > 0)
            {
                for (int i = measurements.Count-1; i >= 0; i--)
                {
                    ForceMeasurement force = measurements[i];
                    if (force.SequenceNumber == sequenceNumber)
                    {
                        return force;
                    }
                }
            }
            return null;
        }

        private ForceMeasurement GetForceMeasurement(string bleValue)
        {
            ForceMeasurement measurement = new ForceMeasurement();
            measurement.TimeMs = (long)(DateTime.Now - recordingStart).TotalMilliseconds;
            if (!string.IsNullOrEmpty(bleValue))
            {
                string[] msgContent = bleValue.Split(';');
                if (msgContent != null && msgContent.Length > 0)
                {
                    foreach (string fld in msgContent)
                    {
                        string[] fldContent = fld.Split('=');
                        if (fldContent.Length == 2)
                        {
                            string fldName = fldContent[0];
                            if (fldName.StartsWith("SEQ"))
                            {
                                if (int.TryParse(fldContent[1], out int sequenceNumber))
                                {
                                    measurement.SequenceNumber = sequenceNumber;
                                }
                            }
                            else if (fldName.StartsWith("ADC"))
                            {
                                if (float.TryParse(fldContent[1], out float adc))
                                {
                                    measurement.ADC = adc;
                                }
                            }
                        }
                    }
                }
            }
            return measurement;
        }

        public void StartRecording()
        {
            recordingStart = DateTime.Now;
            isRecording = true;
            currentVideoFile = string.Empty;

            leftForceRecordings = new List<ForceMeasurement>();
            if (leftBleForceDevice != null)
            {
                ForceGraph?.ForceGraphLeft.SetRecording(true);
                ForceGraph?.ForceGraphLeft.ViewModel.ClearMeasurments();
                leftBleForceDevice.StartRecording();
            }

            rightForceRecordings = new List<ForceMeasurement>();
            if (rightBleForceDevice != null)
            {
                ForceGraph?.ForceGraphRight.SetRecording(true);
                ForceGraph?.ForceGraphRight.ViewModel.ClearMeasurments();
                rightBleForceDevice.StartRecording();
            }
        }

        public void StopRecording(string videoFileName)
        {
            // Ensure this is not the second video capture file
            string fileName = Path.GetFileNameWithoutExtension(videoFileName);
            if (fileName.EndsWith("-2"))
            {
                return;
            }

            currentVideoFile = videoFileName;
            if (leftBleForceDevice != null)
            {
                ForceGraph?.ForceGraphLeft.SetRecording(false);
                leftBleForceDevice.StopRecording();
            }
            if (rightBleForceDevice != null)
            {
                ForceGraph?.ForceGraphRight.SetRecording(false);
                rightBleForceDevice.StopRecording();
            }
            if (!string.IsNullOrEmpty(videoFileName))
            {
                SaveRecordings(videoFileName);
            }
        }

        private void SaveRecordings(string videoFileName)
        {
            string path = Path.GetDirectoryName(videoFileName);
            string fileName = Path.GetFileNameWithoutExtension(videoFileName);
            string file = Path.Combine(path, fileName);

            if (leftForceRecordings.Count > 0)
            {
                SaveForceData(GetForceDataFileFromVideoFile(videoFileName, true), leftForceRecordings);
            }
            if (rightForceRecordings.Count > 0)
            {
                SaveForceData(GetForceDataFileFromVideoFile(videoFileName, false), rightForceRecordings);
            }
        }

        private void SaveForceData(string fileName, List<ForceMeasurement> measurements)
        {
            try
            {
                File.WriteAllText(fileName, JsonConvert.SerializeObject(measurements));
            }
            catch (Exception ex)
            {
                // TODO: Log error
                _ = ex;
            }
        }

        private void CurrentDirectoryChanged(object sender, CurrentDirectoryChangedEventArgs e)
        {
            fileWatcher.EnableRaisingEvents = false;

            if (e.Path == null || e.Path.StartsWith("::"))
                return;

            try
            {
                fileWatcher.Path = e.Path;
                fileWatcher.EnableRaisingEvents = true;
            }
            catch
            {
                // Log error

            }
        }

        private void VideoFileRenamed(object sender, RenamedEventArgs e)
        {
            try
            {
                // Suppress events so that we don't get multiple event notifications
                // during renaming of the force files.
                fileWatcher.EnableRaisingEvents = false;
            
                string oldFileName = Path.GetFileNameWithoutExtension(e.OldFullPath);
                if (oldFileName.EndsWith("-2"))
                    return;

                string oldForceFileLeftName = GetForceDataFileFromVideoFile(oldFileName, true);
                string oldForceFullFileLeftName = Path.Combine(Path.GetDirectoryName(e.OldFullPath), oldForceFileLeftName);
                if (File.Exists(oldForceFullFileLeftName))
                {
                    string newForceFileLeftName = GetForceDataFileFromVideoFile(e.FullPath, true);
                    File.Move(oldForceFullFileLeftName, newForceFileLeftName);
                }

                string oldForceFileRightName = GetForceDataFileFromVideoFile(oldFileName, false);
                string oldForceFullFileRightName = Path.Combine(Path.GetDirectoryName(e.OldFullPath), oldForceFileRightName);
                if (File.Exists(oldForceFullFileRightName))
                {
                    string newForceFileRightName = GetForceDataFileFromVideoFile(e.FullPath, false);
                    File.Move(oldForceFullFileRightName, newForceFileRightName);
                }
            }
            catch 
            { 
                // TODO: Log error
            }
            finally
            {
                fileWatcher.EnableRaisingEvents = true;
            }
        }

        private void VideoFileDeleted(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        private string GetForceDataFileFromVideoFile(string videoFileName, bool left)
        {
            string path = Path.GetDirectoryName(videoFileName);
            string fileName = Path.GetFileNameWithoutExtension(videoFileName);
            string file = Path.Combine(path, fileName);
            string side = left ? "left" : "right";
            return $"{file}-forcedata-{side}.json";
        }

        public void PlayerSelectionChanged(string videoFileName)
        {
            string fileName = Path.GetFileNameWithoutExtension(videoFileName);
            if (fileName.EndsWith("-2"))
                return;

            if (currentVideoFile == videoFileName)
            {
                return;
            }
            LoadForceDataFromVideoFile(videoFileName);
            currentVideoFile = videoFileName;
        }

        private void LoadForceDataFromVideoFile(string videoFileName)
        {
            leftForceRecordings = LoadForceData(GetForceDataFileFromVideoFile(videoFileName, true));
            ForceGraph?.ForceGraphLeft.ViewModel.AddMeasurements(leftForceRecordings);

            rightForceRecordings = LoadForceData(GetForceDataFileFromVideoFile(videoFileName, false));
            ForceGraph?.ForceGraphRight.ViewModel.AddMeasurements(rightForceRecordings);
        }

        private List<ForceMeasurement> LoadForceData(string forceDataFile)
        {
            if (File.Exists(forceDataFile))
            {
                try
                {
                    return JsonConvert.DeserializeObject<List<ForceMeasurement>>(File.ReadAllText(forceDataFile));
                }
                catch (Exception e)
                {
                    // TODO: Log error
                    _ = e;
                }
            }
            return new List<ForceMeasurement>();
        }

        public void GoToTime(long milliSeconds)
        {
            ForceGraph.GoToTime(milliSeconds);
        }

        public BleForcePlateDevice LeftForcePlate => leftBleForceDevice;
        public BleForcePlateDevice RightForcePlate => rightBleForceDevice;
    }
}

using InTheHand.Bluetooth;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Kinovea.Force.BleForcePlates
{
    public class BleForcePlateDevice
    {
        // Default GUID of the GATT service exposed by the foreplates
        public static string bleDefaultServiceGuid = "03197e0f-fee2-4a0a-a12a-8bf696e4d4b7";
        public string DeviceName { get; set; }

        private string serviceGuid = bleDefaultServiceGuid;
        private BluetoothLEScan scanner;

        public Action<BleForcePlateDevice, string> ForceValueReceived;
        public bool IsConnected { get; set; }
        public Action<BleForcePlateDevice> DeviceConnected;
        public Action<BleForcePlateDevice> DeviceDisconnected;

        private GattCharacteristic bleNotifyService;
        private GattCharacteristic bleWriteService;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BleForcePlateDevice(string deviceName, string serviceGuid = null)
        {
            DeviceName = deviceName;
            if (!string.IsNullOrEmpty(serviceGuid))
            {
                this.serviceGuid = serviceGuid;
            }
            this.serviceGuid = serviceGuid ?? bleDefaultServiceGuid;
        }

        public async Task Start()
        {
            Bluetooth.AdvertisementReceived += BluetoothAdvertisementReceived;
            await StartBleScanner();
        }

        private async Task StartBleScanner()
        {
            BluetoothLEScanOptions options = new BluetoothLEScanOptions();
            options.AcceptAllAdvertisements = true;

            scanner = await Bluetooth.RequestLEScanAsync(options);
        }

        public void SetZero()
        {
            SendString("zero");
        }

        public void Scale(int grams)
        {
            SendString($"scale:{grams}");
        }

        public void Stop()
        {
            scanner.Stop();
        }

        public void StartRecording()
        {
            SendString("start");
        }

        public void StopRecording()
        {
            SendString("stop");
        }

        public void SendString(string value)
        {
            if (bleWriteService != null)
            {
                bleWriteService.WriteValueWithoutResponseAsync(UTF8Encoding.UTF8.GetBytes(value));
            }
        }


        private async void BluetoothAdvertisementReceived(object sender, BluetoothAdvertisingEvent e)
        {
            try
            {
                log.Info($"New bluetooth device discovered. Name: {e.Name}, Device name: {e.Device?.Name}, IDs: {e.Device?.Id}");
                if (e.Device != null && e.Device != null && e.Device.Name == DeviceName)
                {
                    scanner.Stop();

                    log.Info($"Found BLE device {DeviceName}.");
                    foreach (var uuid in e.Uuids)
                    {
                        log.Info($"UUID: {uuid}");
                    }

                    log.Info($"Connecting to {DeviceName}");

                    e.Device.GattServerDisconnected += BleGattServerDisconnected;

                    await e.Device.Gatt.ConnectAsync();

                    log.Info($"Connected to {DeviceName}");

                    IsConnected = true;
                    DeviceConnected?.Invoke(this);

                    var services = await e.Device.Gatt.GetPrimaryServicesAsync();

                    foreach (var service in services)
                    {

                        log.Info($"BLE service: UUID: {service.Uuid}, Primary: {service.IsPrimary}");
                        foreach (var c in await service.GetCharacteristicsAsync())
                        {
                            if (c.Uuid.ToString() == serviceGuid)
                            {
                                log.Info($"Service characteristics: UUID: {c.Uuid}. Properties: {c.Properties}");
                                if (c.Properties.HasFlag(GattCharacteristicProperties.Notify))
                                {
                                    bleNotifyService = c;
                                    try
                                    {
                                        await c.StartNotificationsAsync();
                                        c.CharacteristicValueChanged += CharacteristicValueChanged;
                                    }
                                    catch (Exception ex)
                                    {
                                        log.Error("Error starting notification on service.", ex);
                                    }
                                }
                                if (c.Properties.HasFlag(GattCharacteristicProperties.Write))
                                {
                                    log.Info("Found Write Service");
                                    bleWriteService = c;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error($"{ex.Message}", ex);
            }
        }

        private void CharacteristicValueChanged(object sender, GattCharacteristicValueChangedEventArgs e)
        {
            log.Info($"BLE value received {e.Value.Length} bytes");
            if (ForceValueReceived != null)
            {
                try
                {
                    string stringValue = Encoding.UTF8.GetString(e.Value);
                    ForceValueReceived?.Invoke(this, stringValue);
                }
                catch (Exception ex)
                {
                    log.Error("Decoding BLE bytes failed.", ex);
                }
            }
        }

        private void BleGattServerDisconnected(object sender, EventArgs e)
        {
            log.Info($"{DeviceName} disconnected.");
            IsConnected = false;
            DeviceDisconnected?.Invoke(this);
            StartBleScanner();
        }
    }
}

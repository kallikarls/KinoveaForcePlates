using CommunityToolkit.Mvvm.ComponentModel;
using Kinovea.Force;
using Kinovea.Force.UI.WinForms.Services;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Policy;

namespace Kinovea.Force.UI.WinForms.ViewModels
{
    [Browsable(false)]
    public class ForceDataViewModel : ObservableObject
    {
        [Browsable(false)]
        public ObservableCollection<ISeries> Series { get; set; }
        private readonly ObservableCollection<ObservablePoint> values;
        private int lastPlayBackIndex = 0;

        public Action<double> ActiveMeasurement { get; set; }
                
        public RectangularSection[] Sections { get; } = new RectangularSection[1];

        private RectangularSection currentPosition;

        public object Sync { get; } = new object();

        public void AddMeasurements(List<ForceMeasurement> forces)
        {
            ClearMeasurments();
            lock(Sync)
            {
                foreach (ForceMeasurement measurement in forces)
                {
                    values.Add(new ObservablePoint(measurement.TimeMs, measurement.LoadPercentage));
                }
                if (forces.Count > 0)
                {
                    ActiveMeasurement?.Invoke(forces[forces.Count - 1].LoadPercentage);
                }
                
            }
        }

        public void AddMeasurement(ForceMeasurement measurement)
        {
            lock(Sync)
            {
                values.Add(new ObservablePoint(measurement.TimeMs, measurement.LoadPercentage));
                //while(values.Count > 100) 
                //{ 
                //    values.RemoveAt(0);
                //}
                ActiveMeasurement?.Invoke(measurement.LoadPercentage);
            }
        }

        public void ClearMeasurments()
        {
            lock(Sync)
            {
                values.Clear();
                lastPlayBackIndex = 0;
            }
        }

        public ForceDataViewModel()
        {
            values = new ObservableCollection<ObservablePoint>();
            Series = new ObservableCollection<ISeries>
            {
                new LineSeries<ObservablePoint>
                {
                    Values = values,
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null,
                    Name = "Series",
                    IsVisibleAtLegend = true,

                }
            };

            currentPosition = new RectangularSection
            {
                Xi = 0,
                Xj = 0,
                Stroke = new SolidColorPaint
                {
                    Color = SKColors.Blue,
                    StrokeThickness = 2
                    /*PathEffect = new DashEffect(new float[] { 6, 6 })*/
                }
            };

            Sections[0] = currentPosition;
        }

        private ObservableCollection<ObservablePoint> GetDataPoints()
        {

            ObservableCollection<ObservablePoint> points = new ObservableCollection<ObservablePoint>();
            for (int i = 0; i < 2000; i += 20)
            {
                points.Add(new ObservablePoint(i, 200 + Math.Sin(i * 0.01) * 100));
            }
            return points;
        }

        public void GoToTime(long milliSeconds)
        {
            if (values.Count > 0)
            {
                double? maxTime = values[values.Count - 1].X;
                if (maxTime != null && maxTime >= milliSeconds)
                {
                    currentPosition.Xi = milliSeconds;
                    currentPosition.Xj = milliSeconds;

                    EmitActiveMeasurement(milliSeconds);
                }
            }
        }

        private void EmitActiveMeasurement(long milliSeconds)
        {
            if (values.Count > 0 && ActiveMeasurement != null)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    ObservablePoint point = values[i];
                    if (point.X >= milliSeconds)
                    {
                        ActiveMeasurement?.Invoke(point.Y.Value);
                        return;
                    }
                }
            }
        }

    }

}

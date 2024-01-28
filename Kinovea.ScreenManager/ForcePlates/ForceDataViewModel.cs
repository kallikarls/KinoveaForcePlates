using CommunityToolkit.Mvvm.ComponentModel;
using Kinovea.Force;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kinovea.ScreenManager.ForcePlates
{
    public class ForceDataViewModel : ObservableObject
    {
        public ObservableCollection<ISeries> Series { get; set; }

                
        public RectangularSection[] Sections { get; } = new RectangularSection[1];

        private RectangularSection currentPosition;

        public object Sync { get; } = new object();

        private ForceDataPlayer forceDataPlayer;
        public ForceDataPlayer ForceDataPlayer 
        {
            get { return forceDataPlayer; }
            set
            {
                forceDataPlayer = value;
                forceDataPlayer.MeasurementsLoaded += MeasurementsLoaded;
            }
        }

        public void MeasurementsLoaded(List<ForceMeasurement> forces)
        {
            lock(Sync)
            {
                foreach (ForceMeasurement measurement in forces)
                {
                    _values.Add(new ObservablePoint(measurement.TimeMs, measurement.ADC));
                }
            }
        }


        private readonly List<ObservablePoint> _values;

        

        public ForceDataViewModel()
        {
            _values = GetDataPoints();
            Series = new ObservableCollection<ISeries>
            {
                new LineSeries<ObservablePoint>
                {
                    Values = _values,
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

        private List<ObservablePoint> GetDataPoints()
        {

            List<ObservablePoint> points = new List<ObservablePoint>();
            for (int i = 0; i < 2000; i += 20)
            {
                points.Add(new ObservablePoint(i, 200 + Math.Sin(i * 0.01) * 100));
            }
            return points;
        }

        public void GoToTime(long milliSeconds)
        {
            if (_values.Count > 0)
            {
                double? maxTime = _values[_values.Count - 1].X;
                if (maxTime != null && maxTime >= milliSeconds)
                {
                    currentPosition.Xi = milliSeconds;
                    currentPosition.Xj = milliSeconds;
                }
            }
        }

    }

}

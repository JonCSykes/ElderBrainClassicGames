using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;

namespace MineSweeperPro.Charts.ViewModel
{
    public partial class WinTimeOverTimeModel : ObservableObject
    {
        private double? average;
        public ISeries[] Series { get; set; }

        public Axis[] XAxis { get; set; } =
        {
            new Axis
            {
                LabelsRotation = 50,
                Labeler = value => new DateTime((long)value).ToString("dd-MMM-yy"),
                UnitWidth = TimeSpan.FromDays(1).Ticks
            }
        };

        public Axis[] YAxis { get; set; } =
        {
            new Axis
            {
                LabelsRotation = 0,
                Labeler = value => TimeSpan.FromMilliseconds((long)value).ToString(@"m\:ss\:fff"),
                UnitWidth = TimeSpan.FromMilliseconds(1).Ticks,
            }
        };

        public double? Average 
        { 
            get 
            { 
                return average;
            } 

            set 
            {
                average = value;

                var averageSection = new RectangularSection
                {
                    Yi = average,
                    Yj = average,
                    Stroke = new SolidColorPaint
                    {
                        Color = SKColors.Red,
                        StrokeThickness = 1,
                        PathEffect = new DashEffect(new float[] { 6, 6 })
                    }
                };

                Sections = new RectangularSection[] { averageSection  };
            } 
        }

        public RectangularSection[] Sections { get; set; }  
        public WinTimeOverTimeModel() { }
        public WinTimeOverTimeModel(ISeries[] series)
        {
            Series = series;
        }

        public void AddValues(double[] values)
        {
            var series = Series;

            ScatterSeries<double> newLine = new ScatterSeries<double>
            {
                Values = values,
                GeometrySize = 3,
                Fill = null
            };

            if (series != null)
            {
                Array.Resize(ref series, series.Length + 1);
                series[series.Length - 1] = newLine;
            }
            else
            {
                series = new ISeries[] { newLine };
            }

            Series = series;
        }

        public void AddValues(ObservableCollection<DateTimePoint> values)
        {
            var series = Series;

            ScatterSeries<DateTimePoint> newLine = new ScatterSeries<DateTimePoint>
            {
                Values = values,
                GeometrySize = 10,
                TooltipLabelFormatter = point => $"({point.Model?.DateTime.ToString("dd-MMM-yy")}) {TimeSpan.FromMilliseconds((long)point.Model?.Value).ToString(@"m\:ss\:fff")}"
            };

            if (series != null)
            {
                Array.Resize(ref series, series.Length + 1);
                series[series.Length - 1] = newLine;
            }
            else
            {
                series = new ISeries[] { newLine };
            }

            Series = series;
        }

    }
}

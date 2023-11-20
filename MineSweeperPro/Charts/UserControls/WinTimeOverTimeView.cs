using LiveChartsCore.SkiaSharpView.WinForms;
using MineSweeperPro.Charts.ViewModel;

namespace MineSweeperPro.Charts.UserControls
{
    public partial class WinTimeOverTimeView : UserControl
    {
        private readonly CartesianChart cartesianChart;
        public WinTimeOverTimeView(WinTimeOverTimeModel model)
        {
            cartesianChart = new CartesianChart();
            cartesianChart.Series = model.Series;
            cartesianChart.XAxes = model.XAxis;
            cartesianChart.YAxes = model.YAxis;
            cartesianChart.Sections = model.Sections;
            cartesianChart.Location = new Point(0, 0);
            cartesianChart.Size = this.Size;
            cartesianChart.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

            Controls.Add(cartesianChart);
        }

        public void UpdateChart(WinTimeOverTimeModel model)
        {
            cartesianChart.Series = model.Series;
            cartesianChart.XAxes = model.XAxis;
            cartesianChart.YAxes = model.YAxis;
            cartesianChart.Sections = model.Sections;
        }
    }
}

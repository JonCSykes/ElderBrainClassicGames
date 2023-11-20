using LiveChartsCore.Defaults;
using MineSweeperPro.Charts.UserControls;
using MineSweeperPro.Charts.ViewModel;
using MineSweeperPro.Properties;
using System.Collections.ObjectModel;

namespace MineSweeperPro
{
    public partial class PlayerStats : ThemedForm
    {
        private Panel chartPanel;
        private ComboBox gameTypeComboBox;
        private GameTypeEnum[] gameTypeEnumValues;
        private GameEntryCollection gameEntryCollection;
        private WinTimeOverTimeView winTimeChart;
        private Dictionary<GameTypeEnum, ObservableCollection<DateTimePoint>> winTimeOverTimeData;

        public PlayerStats()
        {
            gameTypeEnumValues = (GameTypeEnum[])Enum.GetValues(typeof(GameTypeEnum));
            gameEntryCollection = new GameEntryCollection();
            winTimeOverTimeData = new Dictionary<GameTypeEnum, ObservableCollection<DateTimePoint>>();
           

            InitializeComponent();
            BuildControls();
            BuildDataDictionary();
            BuildLayout();

            Title = "Player Stats";
        }
        private void BuildControls()
        {
            gameTypeComboBox = new ComboBox();
            gameTypeComboBox.Dock = DockStyle.Right;
            gameTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            gameTypeComboBox.FlatStyle = FlatStyle.Flat;
            gameTypeComboBox.FormattingEnabled = true;
            gameTypeComboBox.Location = new Point(1076, 0);
            gameTypeComboBox.Name = "GameTypeComboBox";
            gameTypeComboBox.Size = new Size(198, 33);
            gameTypeComboBox.TabIndex = 38;
            gameTypeComboBox.SelectedIndexChanged += GameTypeComboBox_SelectedIndexChanged;
            gameTypeComboBox.DataSource = gameTypeEnumValues;
            gameTypeComboBox.SelectedItem = gameTypeEnumValues[Settings.Default.GameType];
        }

        private void BuildDataDictionary()
        {
            foreach (var gameType in gameTypeEnumValues)
            {
                var data = new ObservableCollection<DateTimePoint>();
                var gameEntries = gameEntryCollection.GetEntries(gameType);

                foreach (var gameEntry in gameEntries)
                {
                    if (gameEntry.Game.IsWin)
                    {
                        data.Add(new DateTimePoint(gameEntry.Game.GameTimestamp, gameEntry.Timestamp.TotalMilliseconds));
                    }
                }

                winTimeOverTimeData.Add(gameType, data);
            }
        }

        private void BuildLayout()
        {
            chartPanel = new Panel();
            chartPanel.Size = new Size(ClientSize.Width / 2, 500);
            chartPanel.Location = new Point(0, 150);
            winTimeChart = new WinTimeOverTimeView(GetWinTimeModel());
            winTimeChart.Size = chartPanel.Size;
            chartPanel.Controls.Add(winTimeChart);

            var metricPanel = new Panel
            {
                Location = new Point(0, 50),
                ClientSize = new Size(ClientSize.Width, 100),
                Padding = new Padding(0, 0, 0, 0),
                Margin = new Padding(0, 0, 0, 0)
            };

            var leftMetricPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(metricPanel.Width / 3, 100),
                Padding = new Padding(0, 0, 0, 0),
                Margin = new Padding(0, 0, 0, 0),
                Dock = DockStyle.Left
            };

            var rightMetricPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(metricPanel.Width / 3, 100),
                Padding = new Padding(0, 0, 0, 0),
                Margin = new Padding(0, 0, 0, 0),
                Dock = DockStyle.Right
            };

            var centerMetricPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(metricPanel.Width / 3, 100),
                Padding = new Padding(0, 0, 0, 0),
                Margin = new Padding(0, 0, 0, 0),
                Dock = DockStyle.Fill
            };

            metricPanel.Controls.Add(rightMetricPanel);
            metricPanel.Controls.Add(centerMetricPanel);
            metricPanel.Controls.Add(leftMetricPanel);

            AddControl(metricPanel);
            AddControl(chartPanel);
            AddControl(gameTypeComboBox);
        }

        private WinTimeOverTimeModel GetWinTimeModel()
        {
            var winTimeData = new WinTimeOverTimeModel();
            var selectedGameType = new GameTypeEnum();

            if (gameTypeComboBox != null && gameTypeComboBox.Items.Count > 0)
            {
                selectedGameType = (GameTypeEnum)gameTypeComboBox.SelectedItem;
            } else
            {
                selectedGameType = gameTypeEnumValues[Settings.Default.GameType];
            }

            if (winTimeOverTimeData != null && winTimeOverTimeData[selectedGameType] != null)
            {
                winTimeData.AddValues(winTimeOverTimeData[selectedGameType]);
            }

            winTimeData.Average = gameEntryCollection.GetAverageTime(selectedGameType);

            return winTimeData;
        }

        private void GameTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        { 
            winTimeChart.UpdateChart(GetWinTimeModel());
        }

        protected override void ResizeForm()
        {
            base.ResizeForm();

            if (chartPanel != null && winTimeChart != null)
            {
                chartPanel.Size = new Size(ClientSize.Width, 500);
                winTimeChart.Size = chartPanel.Size;
            }
        }
    }
}

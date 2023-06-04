namespace MineSweeperPro
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using Properties;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
    using static System.Net.WebRequestMethods;
    using System.Media;

    public partial class Main : Form
    {
        #region P/Invoke

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        private const int WM_NCHITTEST = 0x0084;
        private const int HTLEFT = 0x0A;
        private const int HTRIGHT = 0x0B;
        private const int HTTOP = 0x0C;
        private const int HTTOPLEFT = 0x0D;
        private const int HTTOPRIGHT = 0x0E;
        private const int HTBOTTOM = 0x0F;
        private const int HTBOTTOMLEFT = 0x10;
        private const int HTBOTTOMRIGHT = 0x11;

        private Panel ToolbarPanel;
        private Panel ButtonPanel;
        private Button MinimizeButton;
        private Button MaximizeButton;
        private Button CloseButton;
        private Label TitleLabel;
        private LeaderBoard LeaderBoard;

        const int STATUS_PANEL_WIDTH = 300;
        const int CAPTION_HEIGHT = 40;
        const int DEFAULT_CELL_SIZE = 50;
        const int DEFAULT_CELL_PADDING = 5;
        const int WINDOW_RESIZE_THICKNESS = 10;

        Dictionary<string, DoubleClickButton> MineCellButtonDictionary = new Dictionary<string, DoubleClickButton>();
        Dictionary<string, DoubleClickButton> MineButtonDictionary = new Dictionary<string, DoubleClickButton>();

        Sound SoundPlayer;
        Timer AnimationTimer;
        Timer BBBVSTimer;
        Timer GlobalTimer;
        TimeSpan ElapsedTime;

        DateTime StartTime;
        int TimerCounter = 0;
        bool IsTimerRunning = false;
        public Player CurrentPlayer;
        Game MineSweeperPro;
        Theme SelectedTheme;



        public Main()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            InitializeComponent();
            InitializeCustomWindow();

            Enabled = false;

            CurrentPlayer = new Player();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            GlobalTimer = new System.Windows.Forms.Timer();
            GlobalTimer.Interval = 1;
            GlobalTimer.Tick += new EventHandler(GlobalTimer_Tick);

            BBBVSTimer = new System.Windows.Forms.Timer();
            BBBVSTimer.Interval = 1;
            BBBVSTimer.Tick += new EventHandler(BBBVSTimer_Tick);

            ApplyTheme();
            NewGame();

            Enabled = true;

        }

        private void BBBVSTimer_Tick(object sender, EventArgs e)
        {
            double efficiencyPercentage = 0;

            int bbbv = MineSweeperPro.BBBV;
            int bbbvTotal = MineSweeperPro.BBBVTotal;
            if (bbbv > 0 && bbbvTotal > 0)
            {
                efficiencyPercentage = (double)(bbbv) / (double)(bbbvTotal) * 100;

                BBBVSValueLabel.Text = MineSweeperPro.BBBVS.ToString("0.00");
                BBBVTotalValueLabel.Text = MineSweeperPro.BBBVTotal.ToString();
                EfficiencyValueLabel.Text = efficiencyPercentage.ToString("0.00") + "%";
            }
        }

        private void GlobalTimer_Tick(object sender, EventArgs e)
        {

            if (IsTimerRunning)
            {
                TimerCounter++;
                ElapsedTime = DateTime.Now - StartTime;
                string time = $"{ElapsedTime.Minutes:D2}:{ElapsedTime.Seconds:D2}:{ElapsedTime.Milliseconds / 10:D2}";

                TimerLabel.Text = time;
            }

        }

        public void StartTimer()
        {
            TimerCounter = 0;
            StartTime = DateTime.Now;
            IsTimerRunning = true;
            GlobalTimer.Start();
            BBBVSTimer.Start();
        }

        public void StopTimer()
        {
            IsTimerRunning = false;
            GlobalTimer.Stop();
            BBBVSTimer.Stop();
        }

        public void Mark(UserActionEnum action, EventEnum eventCaptured, MineCell? mineCell)
        {
            TimeSpan timeSpan = DateTime.Now - StartTime;
            MineSweeperPro.AddTelemetry(new Telemetry(action, eventCaptured, timeSpan, mineCell));
        }

        public void LoadPlayerProfile()
        {
            CurrentPlayer.GetSettings();
            ProfilePictureBox.Image = CurrentPlayer.Portrait;
            UsernameLabel.Text = CurrentPlayer.Username;

            CenterPanels(StatusPanel, ProfilePictureBox, true, false);
            CenterPanels(StatusPanel, UsernameLabel, true, false);
        }

        public void ApplyTheme()
        {
            SelectedTheme = new Theme(Settings.Default.Theme);

            this.ForeColor = SelectedTheme.TextColor;
            this.BackColor = SelectedTheme.BackColor;

            TitleLabel.ForeColor = SelectedTheme.TextColor;

            StartPanel.BackColor = SelectedTheme.StatusPanelBackColor;
            StartPanel.ForeColor = SelectedTheme.TextColor;
            SelectedTheme.SetRoundedCorners(StartPanel);

            EndGamePanel.BackColor = SelectedTheme.StatusPanelBackColor;
            EndGamePanel.ForeColor = SelectedTheme.TextColor;
            SelectedTheme.SetRoundedCorners(EndGamePanel);

            StartButton.BackColor = SelectedTheme.MineCellNumberColor2;
            StartButton.ForeColor = SelectedTheme.TextColor;
            SelectedTheme.SetRoundedCorners(StartButton);

            NewGameButton.BackColor = SelectedTheme.MineCellNumberColor2;
            NewGameButton.ForeColor = SelectedTheme.TextColor;
            SelectedTheme.SetRoundedCorners(NewGameButton);

            ShowBoardButton.BackColor = SelectedTheme.MineCellBackColor;
            ShowBoardButton.ForeColor = SelectedTheme.TextColor;
            SelectedTheme.SetRoundedCorners(ShowBoardButton);

            TimerLabel.BackColor = SelectedTheme.StatusPanelBackColor;
            RemainingMinesLabel.BackColor = SelectedTheme.StatusPanelBackColor;
            StatusMineIconLabel.BackColor = SelectedTheme.StatusPanelBackColor;

            StatusPanel.BackColor = SelectedTheme.StatusPanelBackColor;
            StatusPanel.ForeColor = SelectedTheme.StatusPanelTextColor;

            MineFieldPanel.BackColor = SelectedTheme.MineFieldBackColor;

            StatusMineIconLabel.Image = SelectedTheme.MineImage;
            NewGamePictureBox.Image = SelectedTheme.NewGameImage;
            HintPictureBox.Image = SelectedTheme.HintImage;
            SharePictureBox.Image = SelectedTheme.ShareImage;
            ConfigPictureBox.Image = SelectedTheme.SettingsImage;

            MinimizeButton.Image = SelectedTheme.MinimizeImage;

            if (this.WindowState == FormWindowState.Maximized)
            {
                MaximizeButton.Image = SelectedTheme.MaximizeOnImage;
            }
            else
            {
                MaximizeButton.Image = SelectedTheme.MaximizeOffImage;
            }

            CloseButton.Image = SelectedTheme.CloseImage;
        }

        public void NewGame()
        {
            SoundPlayer = new Sound(Settings.Default.EnableSound);
            MineSweeperPro = new Game(CurrentPlayer, Settings.Default.MineFieldWidth, Settings.Default.MineFieldHeight, Settings.Default.MineCount, Settings.Default.HintCount);
            LeaderBoard = new LeaderBoard(MineSweeperPro);

            if (WindowState != FormWindowState.Maximized)
            {
                ClientSize = new Size(Math.Max(Settings.Default.MineFieldWidth * (DEFAULT_CELL_SIZE + DEFAULT_CELL_PADDING) + STATUS_PANEL_WIDTH + WINDOW_RESIZE_THICKNESS, 1274), Math.Max(Settings.Default.MineFieldHeight * (DEFAULT_CELL_SIZE + DEFAULT_CELL_PADDING) + CAPTION_HEIGHT + WINDOW_RESIZE_THICKNESS, 1024));
                MinimumSize = new Size(Math.Max(Settings.Default.MineFieldWidth * (DEFAULT_CELL_SIZE + DEFAULT_CELL_PADDING) + STATUS_PANEL_WIDTH + WINDOW_RESIZE_THICKNESS, 1274), Math.Max(Settings.Default.MineFieldHeight * (DEFAULT_CELL_SIZE + DEFAULT_CELL_PADDING) + CAPTION_HEIGHT + WINDOW_RESIZE_THICKNESS, 1024));
            }

            HideButtons();
            StopTimer();
            ClearMineButtons();
            GenerateMineButtons();
            ShowButtons();
            ResizeGameBoard();

            if (MineSweeperPro != null && MineSweeperPro.MineField != null)
            {
                TimerLabel.Text = "00:00:00";
                RemainingMinesLabel.Text = "0";
                MineFieldPanel.Enabled = false;
                RemainingMinesLabel.Text = Settings.Default.MineCount.ToString();
                BBBVValueLabel.Text = MineSweeperPro.BBBV.ToString();
                BoardSizeValueLabel.Text = MineSweeperPro.MineField.Width.ToString() + " x " + MineSweeperPro.MineField.Height.ToString();
                MineCountValueLabel.Text = MineSweeperPro.MineField.MineCount.ToString();

                EndGamePanel.Visible = false;
                StartPanel.Visible = true;
                StartPanel.BringToFront();
            }
        }

        private void ResizeGameBoard()
        {
            PerformLayout();

            GameBoardPanel.Size = new Size(ClientSize.Width - (WINDOW_RESIZE_THICKNESS * 2), ClientSize.Height - CAPTION_HEIGHT - (WINDOW_RESIZE_THICKNESS * 2));
            GameBoardPanel.Location = new Point(WINDOW_RESIZE_THICKNESS, CAPTION_HEIGHT + WINDOW_RESIZE_THICKNESS);
            GameBoardPanel.PerformLayout();

            MineFieldPanel.Size = new Size(ClientSize.Width - STATUS_PANEL_WIDTH - (WINDOW_RESIZE_THICKNESS * 2), ClientSize.Height - CAPTION_HEIGHT - (WINDOW_RESIZE_THICKNESS * 2));
            MineFieldPanel.Location = new Point(0, 0);
            MineFieldPanel.PerformLayout();

            int gameControlCenterX = (STATUS_PANEL_WIDTH - GameControlPanel.ClientSize.Width) / 2;
            GameControlPanel.Location = new Point(gameControlCenterX, ClientSize.Height - CAPTION_HEIGHT - (WINDOW_RESIZE_THICKNESS * 2) - 70);

            StatusPanel.Size = new Size(STATUS_PANEL_WIDTH, ClientSize.Height - CAPTION_HEIGHT - (WINDOW_RESIZE_THICKNESS * 2));
            StatusPanel.Location = new Point(ClientSize.Width - STATUS_PANEL_WIDTH - (WINDOW_RESIZE_THICKNESS * 2), 0);
            StatusPanel.PerformLayout();

            ToolbarPanel.Size = new Size(GameBoardPanel.ClientSize.Width, CAPTION_HEIGHT);
            ToolbarPanel.Location = new Point(WINDOW_RESIZE_THICKNESS, WINDOW_RESIZE_THICKNESS);
            ToolbarPanel.PerformLayout();

            CenterPanels(MineFieldPanel, ButtonPanel, true, true);
            CenterPanels(MineFieldPanel, EndGamePanel, true, true);
            CenterPanels(MineFieldPanel, StartPanel, true, true);
            CenterPanels(StatusPanel, TimerLabel, true, false);
            CenterPanels(StatusPanel, RemainingMineCountPanel, true, false);
            CenterPanels(EndGamePanel, LeaderBoardTitleLabel, true, false);
            CenterPanels(EndGamePanel, LeaderBoardPanel, true, false);
            CenterPanels(EndGamePanel, GameStatsPanel, true, false);
            CenterPanels(EndGamePanel, FinalTimeLabel, true, false);

        }

        private void StartGame()
        {
            if (!MineSweeperPro.IsGameStarted)
            {
                MineSweeperPro.IsGameStarted = true;
                StartPanel.Visible = false;
                MineFieldPanel.Enabled = true;

                StartTimer();

                RevealLargestCluster();
            }
        }

        private void ValidateWin(MineCell mineCell)
        {
            if (MineSweeperPro != null)
            {
                if (!MineSweeperPro.IsGameOver && MineSweeperPro.IsWin)
                {
                    GameOver(mineCell);
                }
            }
        }
        private void GameOver(MineCell mineCell)
        {

            StopTimer();

            LeaderBoard.AddGameEntry(ElapsedTime);
            LeaderBoard.LoadData();

            if (MineSweeperPro != null)
            {
                MineSweeperPro.IsGameOver = true;
                EndGamePanel.Visible = true;
                EndGamePanel.BringToFront();

                CreateLeaderBoard();

                if (MineSweeperPro.IsWin)
                {
                    WinLoseLabel.Text = "You Won!";
                    WinLoseLabel.ForeColor = Color.Green;
                    FinalTimeLabel.Text = TimerLabel.Text;

                    SoundPlayer.AddToQueue(Sound.WinSound);
                }
                else
                {
                    RevealAllMines(mineCell);

                    WinLoseLabel.Text = "You Exploded!";
                    WinLoseLabel.ForeColor = Color.Red;
                    FinalTimeLabel.Text = TimerLabel.Text;
                    EfficiencyValueLabel.Text = "0%";

                    SoundPlayer.Play(Sound.GameOverSound);

                    DoubleClickButton mineCellButton = MineCellButtonDictionary[string.Concat(mineCell.X.ToString(), ",", mineCell.Y.ToString())] as DoubleClickButton;
                    if (mineCellButton != null)
                    {
                        mineCellButton.BackColor = SelectedTheme.MineCellNumberColor5;
                    }
                }

                CenterPanels(EndGamePanel, WinLoseLabel, true, false);
                CenterPanels(MineFieldPanel, EndGamePanel, true, true);

            }
        }

        private void CreateLeaderBoard()
        {
            LeaderBoardPanel.Controls.Clear();

            var gameEntries = LeaderBoard.GetLeaderBoard();
            int displayCount = 4; //TODO: make this globally configurable.
            int count = 0;
            if (gameEntries != null && gameEntries.Count > 0)
            {
                foreach (var scoreEntry in gameEntries)
                {
                    if (count <= displayCount)
                    {
                        CreateLeaderBoardRow(scoreEntry, count);
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        private void CreateLeaderBoardRow(GameEntry gameEntry, int index)
        {
            int labelHeight = 20;
            int labelPadding = 10;

            Label LeaderBoardNumberLabel = new Label();
            LeaderBoardNumberLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            LeaderBoardNumberLabel.Location = new Point(0, labelPadding / 2);
            LeaderBoardNumberLabel.Name = "LeaderBoardNumberLabel" + index;
            LeaderBoardNumberLabel.Size = new Size(40, labelHeight);
            LeaderBoardNumberLabel.TabIndex = 30;
            LeaderBoardNumberLabel.Text = gameEntry.Rank + ".";
            LeaderBoardNumberLabel.TextAlign = ContentAlignment.MiddleLeft;

            Label LeaderBoardNameLabel = new Label();
            LeaderBoardNameLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            LeaderBoardNameLabel.Location = new Point(40, labelPadding / 2);
            LeaderBoardNameLabel.Name = "LeaderBoardNameLabel" + index;
            LeaderBoardNameLabel.Size = new Size(150, labelHeight);
            LeaderBoardNameLabel.TabIndex = 35;
            LeaderBoardNameLabel.Text = gameEntry.Username;
            LeaderBoardNameLabel.TextAlign = ContentAlignment.MiddleLeft;

            Label LeaderBoardTimeLabel = new Label();
            LeaderBoardTimeLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            LeaderBoardTimeLabel.Location = new Point(190, labelPadding / 2);
            LeaderBoardTimeLabel.Name = "LeaderBoardTimeLabel" + index;
            LeaderBoardTimeLabel.Size = new Size(110, labelHeight);
            LeaderBoardTimeLabel.TabIndex = 40;
            LeaderBoardTimeLabel.Text = $"{gameEntry.Timestamp.Minutes:D2}:{gameEntry.Timestamp.Seconds:D2}:{gameEntry.Timestamp.Milliseconds / 10:D2}"; ;
            LeaderBoardTimeLabel.TextAlign = ContentAlignment.MiddleRight;

            Panel rowPanel = new Panel();
            rowPanel.Size = new Size(300, labelHeight + labelPadding);
            rowPanel.Location = new Point(0, (labelHeight + labelPadding) * index);
            if (index % 2 == 0)
            {
                rowPanel.BackColor = SelectedTheme.MineCellBackColor;
            }
            else
            {
                rowPanel.BackColor = SelectedTheme.StatusPanelBackColor;
            }

            rowPanel.Controls.Add(LeaderBoardNumberLabel);
            rowPanel.Controls.Add(LeaderBoardNameLabel);
            rowPanel.Controls.Add(LeaderBoardTimeLabel);

            LeaderBoardPanel.Controls.Add(rowPanel);
        }

        private void SetButtonColor(DoubleClickButton button, int mineCount)
        {
            button.FlatAppearance.BorderSize = 0;

            switch (mineCount)
            {
                case 1:
                    button.ForeColor = SelectedTheme.MineCellNumberColor1;
                    break;
                case 2:
                    button.ForeColor = SelectedTheme.MineCellNumberColor2;
                    break;
                case 3:
                    button.ForeColor = SelectedTheme.MineCellNumberColor3;
                    break;
                case 4:
                    button.ForeColor = SelectedTheme.MineCellNumberColor4;
                    break;
                case 5:
                    button.ForeColor = SelectedTheme.MineCellNumberColor5;
                    break;
                case 6:
                    button.ForeColor = SelectedTheme.MineCellNumberColor7;
                    break;
                case 7:
                    button.ForeColor = SelectedTheme.MineCellNumberColor7;
                    break;
                case 8:
                    button.ForeColor = SelectedTheme.MineCellNumberColor8;
                    break;
                default:
                    button.ForeColor = SelectedTheme.MineCellNumberColor0;
                    break;
            }
        }

        private void GenerateMineButtons()
        {
            ButtonPanel = new Panel();
            ButtonPanel.AutoSize = true;

            for (int i = 0; i < Settings.Default.MineFieldWidth; i++)
            {
                for (int j = 0; j < Settings.Default.MineFieldHeight; j++)
                {
                    DoubleClickButton mineCellButton = new();
                    mineCellButton.BackColor = SelectedTheme.MineCellBackColor;
                    mineCellButton.FlatStyle = FlatStyle.Flat;
                    mineCellButton.Size = new Size(DEFAULT_CELL_SIZE - DEFAULT_CELL_PADDING, DEFAULT_CELL_SIZE - DEFAULT_CELL_PADDING);
                    mineCellButton.FlatAppearance.BorderSize = 0;
                    mineCellButton.Name = i + "," + j;
                    mineCellButton.Location = new Point((DEFAULT_CELL_SIZE * i), (DEFAULT_CELL_SIZE * j));
                    mineCellButton.MouseUp += new MouseEventHandler(Btn_MouseUp);
                    mineCellButton.MouseDown += new MouseEventHandler(Btn_MouseDown);
                    mineCellButton.Dock = DockStyle.None;

                    SelectedTheme.SetRoundedCorners(mineCellButton);

                    ButtonPanel.Controls.Add(mineCellButton);
                    MineCellButtonDictionary[mineCellButton.Name] = mineCellButton;
                }
            }
            MineFieldPanel.Controls.Add(ButtonPanel);
        }

        private void CenterPanels(Control parentPanel, Control childPanel, bool includeX, bool includeY)
        {
            if (parentPanel == null || childPanel == null) { return; }

            int centeredX = childPanel.Location.X;

            if (includeX)
                centeredX = (parentPanel.ClientSize.Width - childPanel.ClientSize.Width) / 2;

            int centeredY = childPanel.Location.Y;

            if (includeY)
                centeredY = (parentPanel.ClientSize.Height - childPanel.ClientSize.Height) / 2;

            childPanel.Location = new Point(centeredX, centeredY);
        }

        private void Btn_MouseDown1(object? sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowButtons()
        {
            MineFieldPanel.Visible = true;
        }

        private void HideButtons()
        {
            MineFieldPanel.Visible = false;
        }

        private void ClearMineButtons()
        {

            while (MineFieldPanel.Controls.Count > 0)
            {
                Control control = MineFieldPanel.Controls[0];

                MineFieldPanel.Controls.Remove(control);
                control.Dispose();

            }

            MineCellButtonDictionary.Clear();

        }

        private void RevealAllMines(MineCell explodedMineCell)
        {
            if (MineSweeperPro != null && MineSweeperPro.MineField != null && MineSweeperPro.MineField.MineCellCollection != null)
            {
                foreach (var mineCell in MineSweeperPro.MineField.MineCollection)
                {
                    if (mineCell.Type == MineCellTypeEnum.Mine)
                    {
                        DoubleClickButton mineCellButton = MineCellButtonDictionary[string.Concat(mineCell.X.ToString(), ",", mineCell.Y.ToString())] as DoubleClickButton;
                        if (mineCellButton != null)
                        {
                            if (mineCell.Status == MineCellStatusEnum.Flagged)
                            {
                                mineCellButton.Text = "";
                                mineCellButton.BackColor = SelectedTheme.MineCellExplodedBackColor;
                                mineCellButton.Image = SelectedTheme.FlagValidImage;
                            }

                            if (mineCell == explodedMineCell)
                            {

                                mineCellButton.Image = SelectedTheme.MineImage;
                                mineCell.Status = MineCellStatusEnum.Exploded;

                                Image gifImage = Properties.Resources.explosion_transparent_small;

                                PictureBox pictureBox = new PictureBox();
                                pictureBox.Image = gifImage;
                                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                                pictureBox.Location = mineCellButton.Location;
                                pictureBox.BackColor = Color.Transparent;

                                MineFieldPanel.Controls.Add(pictureBox);
                                pictureBox.BringToFront();

                                ImageAnimator.Animate(gifImage, (sender, args) => pictureBox.Invalidate());

                                AnimationTimer = new Timer();
                                AnimationTimer.Interval = 500;

                                AnimationTimer.Tick += (s, ea) =>
                                {
                                    MineFieldPanel.Controls.Remove(pictureBox);
                                    ImageAnimator.StopAnimate(gifImage, (sender, args) => pictureBox.Invalidate());

                                    pictureBox.Dispose();
                                    gifImage.Dispose();

                                    AnimationTimer.Stop();
                                };

                                AnimationTimer.Start();
                            }
                        }
                    }
                }
            }
        }

        private void UseHint()
        {
            if (MineSweeperPro.HintCounter < Settings.Default.HintCount)
            {
                RevealLargestCluster();

                MineSweeperPro.HintCounter++;

                var remainingHintCount = Settings.Default.HintCount - MineSweeperPro.HintCounter;

            }
        }

        private int RevealMineGroup(MineCell mineCell)
        {
            int clusterCount = 0;

            if (MineSweeperPro != null && MineSweeperPro.MineField != null)
            {
                var mineCellGroup = MineSweeperPro.MineField.GetMineCellGroup(mineCell);
                if (mineCellGroup != null)
                {
                    // Check for game over first, before reveal.
                    foreach (var cell in mineCellGroup)
                    {
                        if (!MineSweeperPro.IsGameOver && cell.Status != MineCellStatusEnum.Revealed)
                        {
                            if (cell.Status != MineCellStatusEnum.Flagged && cell.Type == MineCellTypeEnum.Mine)
                            {
                                GameOver(cell);
                                return clusterCount;
                            }
                        }
                    }

                    foreach (var cell in mineCellGroup)
                    {
                        if (!MineSweeperPro.IsGameOver && cell.Status != MineCellStatusEnum.Revealed)
                        {
                            if (cell.Status == MineCellStatusEnum.Flagged && cell.Type == MineCellTypeEnum.Mine)
                            {
                                continue;
                            }

                            SoundPlayer.AddToQueue(Sound.CellRevealSound, 100);
                            RevealMineCell(cell);

                            if (cell.SurroundingMineCount == 0)
                            {
                                clusterCount++;
                                clusterCount += RevealCluster(cell);
                            }
                        }
                    }

                }

            }
            return clusterCount;
        }

        private int RevealCluster(MineCell mineCell)
        {
            int clusterCount = 0;
            if (mineCell.SurroundingMineCount == 0)
            {
                if (MineSweeperPro != null && MineSweeperPro.MineField != null)
                {
                    var mineCellGroup = MineSweeperPro.MineField.GetMineCellGroup(mineCell);
                    if (mineCellGroup != null)
                    {
                        foreach (var cell in mineCellGroup)
                        {
                            if (!MineSweeperPro.IsGameOver)
                            {
                                if (cell.Status == MineCellStatusEnum.Revealed)
                                {
                                    continue;
                                }

                                if (cell.Status == MineCellStatusEnum.Flagged && cell.Type != MineCellTypeEnum.Mine)
                                {
                                    ToggleFlag(cell);
                                }

                                RevealClusterCell(cell);

                                if (cell.SurroundingMineCount == 0)
                                {
                                    clusterCount++;
                                    clusterCount += RevealCluster(cell);
                                }
                            }
                        }

                    }

                }
            }

            return clusterCount;
        }

        private void RevealLargestCluster()
        {
            if (MineSweeperPro != null && MineSweeperPro.MineField != null && MineSweeperPro.MineField.MineCellCollection != null && MineSweeperPro.MineField.SortedClusterCollection != null)
            {
                SoundPlayer.AddToQueue(Sound.ClusterRevealSound, 500);

                foreach (var mineCell in MineSweeperPro.MineField.SortedClusterCollection)
                {
                    if (mineCell.Status == MineCellStatusEnum.Revealed || mineCell.Status == MineCellStatusEnum.Flagged && mineCell.Type == MineCellTypeEnum.Mine)
                    {
                        continue;
                    }

                    RevealClusterCell(mineCell);

                    Mark(UserActionEnum.MiddleClick, EventEnum.ChordReveal, mineCell);

                    if (!MineSweeperPro.IsGameOver)
                    {
                        RevealCluster(mineCell);

                        ValidateWin(mineCell);
                    }

                    break;
                }
            }
        }

        private void RevealClusterCell(MineCell mineCell)
        {
            if (mineCell.Type == MineCellTypeEnum.Mine)
            {
                return;
            }

            if (mineCell.Status != MineCellStatusEnum.Revealed)
            {
                if (MineSweeperPro != null && MineSweeperPro.MineField != null)
                {
                    if (MineCellButtonDictionary[string.Concat(mineCell.X.ToString(), ",", mineCell.Y.ToString())] is DoubleClickButton mineCellButton)
                    {
                        mineCell.Status = MineCellStatusEnum.Revealed;
                        MineSweeperPro.MineField.MineCellsRevealedCounter++;

                        mineCellButton.BackColor = SelectedTheme.MineCellActivatedBackColor; ;
                        mineCellButton.Image = null;
                        mineCellButton.Text = mineCell.SurroundingMineCount.ToString();
                        mineCellButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                        if (Settings.Default.ChordControl == (int)ChordControlEnum.DoubleClick)
                        {
                            mineCellButton.DoubleClick += Btn_DoubleClick;
                        }

                        SetButtonColor(mineCellButton, mineCell.SurroundingMineCount);
                    }
                }
            }
        }

        private void RevealMineCell(MineCell mineCell)
        {
            if (mineCell.Type == MineCellTypeEnum.Mine)
            {
                if (mineCell.Status != MineCellStatusEnum.Flagged)
                {
                    GameOver(mineCell);
                    return;
                }
            }

            if (mineCell.Status != MineCellStatusEnum.Revealed && mineCell.Status != MineCellStatusEnum.Flagged)
            {
                if (MineSweeperPro != null && MineSweeperPro.MineField != null)
                {
                    if (MineCellButtonDictionary[string.Concat(mineCell.X.ToString(), ",", mineCell.Y.ToString())] is DoubleClickButton mineCellButton)
                    {
                        mineCell.Status = MineCellStatusEnum.Revealed;
                        MineSweeperPro.MineField.MineCellsRevealedCounter++;

                        mineCellButton.BackColor = SelectedTheme.MineCellActivatedBackColor;
                        mineCellButton.Image = null;
                        mineCellButton.Text = mineCell.SurroundingMineCount.ToString();
                        mineCellButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                        if (Settings.Default.ChordControl == (int)ChordControlEnum.DoubleClick)
                        {
                            mineCellButton.DoubleClick += Btn_DoubleClick;
                        }

                        SetButtonColor(mineCellButton, mineCell.SurroundingMineCount);
                    }
                }
            }
        }


        private void ToggleFlag(MineCell mineCell)
        {
            var mineCellButton = MineCellButtonDictionary[string.Concat(mineCell.X.ToString(), ",", mineCell.Y.ToString())];

            if (MineSweeperPro != null && MineSweeperPro.MineField != null)
            {
                if (mineCell.Status != MineCellStatusEnum.Exploded && !MineSweeperPro.IsGameOver)
                {
                    if (mineCell.Status != MineCellStatusEnum.Flagged && mineCell.Status != MineCellStatusEnum.Revealed)
                    {
                        SoundPlayer.Play(Sound.FlagOnSound);

                        mineCellButton.Text = "";
                        mineCellButton.Image = SelectedTheme.FlagImage;
                        mineCellButton.BackColor = SelectedTheme.MineCellFlaggedBackColor;
                        mineCell.Status = MineCellStatusEnum.Flagged;

                        MineSweeperPro.MineField.MineCellsFlaggedCounter++;
                        RemainingMinesLabel.Text = (Settings.Default.MineCount - MineSweeperPro.MineField.MineCellsFlaggedCounter).ToString();

                        Mark(UserActionEnum.RightClick, EventEnum.CellFlag, mineCell);
                    }
                    else if (mineCell.Status == MineCellStatusEnum.Flagged)
                    {
                        SoundPlayer.Play(Sound.FlagOffSound);

                        mineCellButton.Text = "";
                        mineCellButton.Image = null;
                        mineCellButton.BackColor = SelectedTheme.MineCellBackColor;
                        mineCell.Status = MineCellStatusEnum.Default;

                        MineSweeperPro.MineField.MineCellsFlaggedCounter--;
                        RemainingMinesLabel.Text = (Settings.Default.MineCount - MineSweeperPro.MineField.MineCellsFlaggedCounter).ToString();

                        Mark(UserActionEnum.RightClick, EventEnum.CellUnflag, mineCell);
                    }
                }
            }
        }
        private void Btn_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickButton btn = (DoubleClickButton)sender;
            string[] coords = btn.Name.Split(',');
            int x = Convert.ToInt32(coords[0]);
            int y = Convert.ToInt32(coords[1]);

            if (MineSweeperPro != null && MineSweeperPro.MineField != null && MineSweeperPro.MineField.MineCellCollection != null)
            {
                var mineCell = MineSweeperPro.MineField.MineCellCollection[x, y];
                var surroundingFlagCount = MineSweeperPro.MineField.GetFlagCount(x, y);

                if (surroundingFlagCount == mineCell.SurroundingMineCount)
                {
                    var clusterCount = RevealMineGroup(mineCell);

                    if (clusterCount > 0)
                    {
                        SoundPlayer.AddToQueue(Sound.ClusterRevealSound, 500);
                    }

                    Mark(UserActionEnum.DoubleClick, EventEnum.ChordReveal, mineCell);
                }

                if (!MineSweeperPro.IsGameOver)
                {
                    ValidateWin(mineCell);
                }
            }
        }
        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            DoubleClickButton btn = (DoubleClickButton)sender;
            string[] coords = btn.Name.Split(',');
            int i = Convert.ToInt32(coords[0]);
            int j = Convert.ToInt32(coords[1]);

            if (MineSweeperPro != null && MineSweeperPro.MineField != null && MineSweeperPro.MineField.MineCellCollection != null)
            {
                var mineCell = MineSweeperPro.MineField.MineCellCollection[i, j];
                var surroundingFlagCount = MineSweeperPro.MineField.GetFlagCount(i, j);

                if (e.Button == MouseButtons.Left)
                {
                    if (!MineSweeperPro.IsGameOver)
                    {
                        if (Settings.Default.ChordControl == (int)ChordControlEnum.SingleClick && mineCell.Status == MineCellStatusEnum.Revealed && mineCell.SurroundingMineCount == surroundingFlagCount)
                        {
                            var mineCellGroup = MineSweeperPro.MineField.GetMineCellGroup(mineCell);
                            if (mineCellGroup != null)
                            {
                                foreach (MineCell cell in mineCellGroup)
                                {
                                    if (cell.Status == MineCellStatusEnum.Default)
                                    {
                                        var mineCellButton = MineCellButtonDictionary[string.Concat(cell.X.ToString(), ",", cell.Y.ToString())];
                                        mineCellButton.BackColor = SelectedTheme.MineCellActivatedBackColor;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            DoubleClickButton btn = (DoubleClickButton)sender;
            string[] coords = btn.Name.Split(',');
            int i = Convert.ToInt32(coords[0]);
            int j = Convert.ToInt32(coords[1]);

            if (MineSweeperPro != null && MineSweeperPro.MineField != null && MineSweeperPro.MineField.MineCellCollection != null)
            {
                var mineCell = MineSweeperPro.MineField.MineCellCollection[i, j];
                var surroundingFlagCount = MineSweeperPro.MineField.GetFlagCount(i, j);

                if (e.Button == MouseButtons.Left)
                {
                    if (!MineSweeperPro.IsGameOver)
                    {
                        if (mineCell.SurroundingMineCount == 0)
                        {
                            SoundPlayer.AddToQueue(Sound.CellRevealSound, 100);

                            RevealMineCell(mineCell);

                            var clusterCount = RevealCluster(mineCell);

                            if (clusterCount > 0)
                            {
                                SoundPlayer.AddToQueue(Sound.ClusterRevealSound, 500);
                            }

                            Mark(UserActionEnum.LeftClick, EventEnum.ChordReveal, mineCell);
                        }
                        else if (Settings.Default.ChordControl == (int)ChordControlEnum.SingleClick && mineCell.Status == MineCellStatusEnum.Revealed && mineCell.SurroundingMineCount == surroundingFlagCount)
                        {
                            var clusterCount = RevealMineGroup(mineCell);

                            if (clusterCount > 0)
                            {
                                SoundPlayer.AddToQueue(Sound.ClusterRevealSound, 500);
                            }

                            Mark(UserActionEnum.LeftClick, EventEnum.ChordReveal, mineCell);
                        }
                        else
                        {
                            SoundPlayer.AddToQueue(Sound.CellRevealSound, 100);
                            RevealMineCell(mineCell);

                            Mark(UserActionEnum.LeftClick, EventEnum.CellReveal, mineCell);
                        }

                        ValidateWin(mineCell);

                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    ToggleFlag(mineCell);
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    UseHint();

                    if (!MineSweeperPro.IsGameOver)
                    {
                        ValidateWin(mineCell);
                    }
                }

            }
        }

        private void CreateNewGameHandler()
        {
            ApplyTheme();
            NewGame();
        }

        private void LoadProfileHandler()
        {
            LoadPlayerProfile();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SoundPlayer.Stop();
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SoundPlayer.Stop();
            Application.Exit();
        }

        private void TimerLabel_Click(object sender, EventArgs e)
        {

        }

        private void ProfilePictureBox_Click(object sender, EventArgs e)
        {
            using ProfileDialog profileForm = new(CurrentPlayer);
            profileForm.StartPosition = FormStartPosition.CenterParent;
            profileForm.LoadProfileEvent += LoadProfileHandler;
            profileForm.ShowDialog();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (CurrentPlayer.ProfileExists())
            {
                LoadPlayerProfile();
            }
            else
            {
                using ProfileDialog profileForm = new(CurrentPlayer);
                profileForm.StartPosition = FormStartPosition.CenterParent;
                profileForm.LoadProfileEvent += LoadProfileHandler;
                profileForm.ShowDialog();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        public void SaveScreenshot(Bitmap screenshot)
        {
            string assemblyPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string homeFolder = "";

            if (!string.IsNullOrEmpty(assemblyPath))
            {
                homeFolder = Path.Combine(assemblyPath, "MineSweeperPro");
            }

            if (!string.IsNullOrEmpty(homeFolder))
            {
                string screenshotFilePath = Path.Combine(homeFolder, "Screenshots");

                if (!Directory.Exists(screenshotFilePath))
                {
                    Directory.CreateDirectory(screenshotFilePath);
                }
                string currentTimeString = DateTime.Now.ToString("yyyyMMdd-HHmmss");

                string imagePath = Path.Combine(screenshotFilePath, "screenshot_" + currentTimeString + ".png");

                screenshot.Save(imagePath, ImageFormat.Png);

            }
        }

        private void InitializeCustomWindow()
        {
            ToolbarPanel = new Panel();
            ToolbarPanel.MouseDown += ToolbarOnMouseDown;

            TitleLabel = new Label()
            {
                Text = "Mine Sweeper Pro",
                Font = new Font(Font.FontFamily, 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(250, 30)
            };

            MinimizeButton = CreateCaptionButton("");
            MaximizeButton = CreateCaptionButton("");
            CloseButton = CreateCaptionButton("");

            MinimizeButton.Click += (sender, e) => WindowState = FormWindowState.Minimized;
            MaximizeButton.Click += (sender, e) => ToggleMaximize();
            CloseButton.Click += (sender, e) => Close();

            ToolbarPanel.Controls.Add(TitleLabel);
            ToolbarPanel.Controls.Add(MinimizeButton);
            ToolbarPanel.Controls.Add(MaximizeButton);
            ToolbarPanel.Controls.Add(CloseButton);

            Controls.Add(ToolbarPanel);
        }

        private void ToolbarOnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCHITTEST, 0, 0);

                if (Cursor == Cursors.Default)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 0xA1, 0x2, 0);
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);

                if (pos.X <= WINDOW_RESIZE_THICKNESS)
                {
                    if (pos.Y <= WINDOW_RESIZE_THICKNESS)
                        m.Result = (IntPtr)HTTOPLEFT;
                    else if (pos.Y >= ClientSize.Height - WINDOW_RESIZE_THICKNESS)
                        m.Result = (IntPtr)HTBOTTOMLEFT;
                    else
                        m.Result = (IntPtr)HTLEFT;
                }
                else if (pos.X >= ClientSize.Width - WINDOW_RESIZE_THICKNESS)
                {
                    if (pos.Y <= WINDOW_RESIZE_THICKNESS)
                        m.Result = (IntPtr)HTTOPRIGHT;
                    else if (pos.Y >= ClientSize.Height - WINDOW_RESIZE_THICKNESS)
                        m.Result = (IntPtr)HTBOTTOMRIGHT;
                    else
                        m.Result = (IntPtr)HTRIGHT;
                }
                else if (pos.Y <= WINDOW_RESIZE_THICKNESS)
                {
                    m.Result = (IntPtr)HTTOP;
                }
                else if (pos.Y >= ClientSize.Height - WINDOW_RESIZE_THICKNESS)
                {
                    m.Result = (IntPtr)HTBOTTOM;
                }
            }

        }

        private void ToggleMaximize()
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                MaximizeButton.Image = SelectedTheme.MaximizeOnImage;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                MaximizeButton.Image = SelectedTheme.MaximizeOffImage;
            }
        }

        private Button CreateCaptionButton(string text)
        {
            return new Button()
            {
                Text = text,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Width = CAPTION_HEIGHT,
                Height = CAPTION_HEIGHT,
                Dock = DockStyle.Right
            };
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            ResizeGameBoard();
        }

        private void Main_ResizeEnd(object sender, EventArgs e)
        {
        }

        private void ConfigPictureBox_Click(object sender, EventArgs e)
        {
            using (SettingsDialog settingsForm = new SettingsDialog())
            {

                settingsForm.Owner = this;
                settingsForm.StartPosition = FormStartPosition.CenterParent;
                settingsForm.CreateNewGameEvent += CreateNewGameHandler;
                settingsForm.ShowDialog();
            }
        }

        private void NewGamePictureBox_Click(object sender, EventArgs e)
        {

            NewGame();
            ApplyTheme();
            ResizeGameBoard();
            EndGamePanel.Visible = false;
        }

        private void HintPictureBox_Click(object sender, EventArgs e)
        {
            if (!MineSweeperPro.IsGameStarted)
            {
                MineSweeperPro.IsGameStarted = true;

                StartTimer();
            }

            UseHint();
        }

        private void SharePictureBox_Click(object sender, EventArgs e)
        {
            Bitmap screenshot = new Bitmap(Width, Height);
            using (Graphics graphics = Graphics.FromImage(screenshot))
            {
                graphics.CopyFromScreen(GameBoardPanel.PointToScreen(Point.Empty).X, GameBoardPanel.PointToScreen(Point.Empty).Y, 0, 0, GameBoardPanel.ClientSize);
            }

            SaveScreenshot(screenshot);

            // Open the file dialog to allow the user to select the social media app to share
            // OpenFileDialog openFileDialog = new OpenFileDialog();
            // openFileDialog.FileName = "Select an app to share the screenshot";
            // openFileDialog.Filter = "Executables (*.exe)|*.exe";
            // openFileDialog.ShowDialog();

            // Get the selected app's path
            //  string selectedAppPath = openFileDialog.FileName;

            // Share the image using the selected app
            // if (!string.IsNullOrEmpty(selectedAppPath))
            //  {
            //      System.Diagnostics.Process.Start(selectedAppPath, tempImagePath);
            //  }

            screenshot.Dispose();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            ApplyTheme();
            NewGame();

            Enabled = true;
            EndGamePanel.Visible = false;
        }

        private void ShowBoardButton_Click(object sender, EventArgs e)
        {
            EndGamePanel.Visible = false;
        }
    }
}
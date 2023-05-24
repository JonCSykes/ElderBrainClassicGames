namespace MineSweeper
{
    // Import libraries
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Reflection.Metadata;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using MineSweeper.Properties;
    using Microsoft.VisualBasic.ApplicationServices;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


    /// <summary>
    /// The main form
    /// </summary>
    public partial class Main : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        const int WM_RBUTTONDOWN = 0x0204;
        const int WM_RBUTTONUP = 0x0205;
        const int WM_LBUTTONDOWN = 0x201;
        const int WM_LBUTTONUP = 0x202;
        const int DEFAULT_CELL_SIZE = 50;

        Dictionary<string, DoubleClickButton> MineCellButtonDictionary = new Dictionary<string, DoubleClickButton>();
        Dictionary<string, DoubleClickButton> MineButtonDictionary = new Dictionary<string, DoubleClickButton>();

        Sound SoundPlayer = new Sound();
        Timer AnimationTimer = new Timer();
        System.Windows.Forms.Timer GlobalTimer;
        DateTime StartTime;
        int TimerCounter = 0;
        bool IsTimerRunning = false;
        public Player CurrentPlayer;
        Game MineSweeperPro;
        Theme ConfiguredTheme;
        Image MineImage;
        Image FlagImage;

        public Main()
        {
            InitializeComponent();

            Enabled = false;

            CurrentPlayer = new Player();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            GlobalTimer = new System.Windows.Forms.Timer();
            GlobalTimer.Interval = 1;
            GlobalTimer.Tick += new EventHandler(GlobalTimer_Tick);

            CreateMenu();
            ApplyTheme();
            NewGame();

            Enabled = true;
           
        }

        private void GlobalTimer_Tick(object sender, EventArgs e)
        {

            if (IsTimerRunning)
            {
                TimerCounter++;
                TimeSpan elapsedTime = DateTime.Now - StartTime;
                string time = $"{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}:{elapsedTime.Milliseconds / 10:D2}";

                TimerLabel.Text = time;
            }

        }

        public void StartTimer()
        {
            TimerCounter = 0;
            StartTime = DateTime.Now;
            IsTimerRunning = true;
            GlobalTimer.Start();
        }

        public void StopTimer()
        {
            IsTimerRunning = false;
            GlobalTimer.Stop();
        }

        public void LoadPlayerProfile()
        {
            CurrentPlayer.GetSettings();
            ProfilePictureBox.Image = CurrentPlayer.Portrait;
            UsernameLabel.Text = CurrentPlayer.Username;
        }

        public void ApplyTheme()
        {
            ConfiguredTheme = new Theme();
            ConfiguredTheme.LoadTheme(Settings.Default.Theme);

            this.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.TextColor);
            this.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineFieldBackColor);

            StartPanel.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineFieldBackColor);
            StartPanel.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.TextColor);
            Theme.SetRoundedCorners(StartPanel);

            StartButton.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellNumberColor2);
            StartButton.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.TextColor);
            Theme.SetRoundedCorners(StartButton);

            TimerLabel.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.StatusPanelBackColor);
            RemainingMinesLabel.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.StatusPanelBackColor);
            StatusMineIconLabel.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.StatusPanelBackColor);
            BoardDetailsLabel.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.StatusPanelBackColor);
            StatusPanel.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.StatusPanelBackColor);
            StatusPanel.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.StatusPanelTextColor);

            MineFieldPanel.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineFieldBackColor);

            if (!string.IsNullOrEmpty(ConfiguredTheme.MineImage))
            {
                using (FileStream stream = new FileStream(ConfiguredTheme.MineImage, FileMode.Open))
                {
                    Image mineImage = Image.FromStream(stream);

                    MineImage = mineImage;
                }
            }
            else
            {
                MineImage = Properties.Resources.mine_small;
            }

            if (!string.IsNullOrEmpty(ConfiguredTheme.FlagImage))
            {
                using (FileStream stream = new FileStream(ConfiguredTheme.FlagImage, FileMode.Open))
                {
                    Image flagImage = Image.FromStream(stream);

                    FlagImage = flagImage;
                }
            }
            else
            {
                FlagImage = Properties.Resources.redflag_small;
            }

            StatusMineIconLabel.Image = MineImage;

            if (this.Controls.Find("mineMenu", false)[0] is MenuStrip mineMenu)
            {
                mineMenu.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MenuTextColor);
                mineMenu.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MenuBackColor);

                mineMenu.Items[0].BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MenuBackColor);
                mineMenu.Items[0].ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MenuTextColor);

                mineMenu.Items[1].BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MenuBackColor);
                mineMenu.Items[1].ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MenuTextColor);

                mineMenu.Items[2].BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MenuBackColor);
                mineMenu.Items[2].ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MenuTextColor);
            }

        }

        public void NewGame()
        {
            if (Settings.Default.Debug)
            {
                DebugPanel.Visible = true;
            }
            else
            {
                DebugPanel.Visible = false;
            }

            MineSweeperPro = new Game(Settings.Default.MineFieldWidth, Settings.Default.MineFieldHeight, Settings.Default.MineCount, Settings.Default.HintCount);

            ClientSize = new Size(Settings.Default.MineFieldWidth * DEFAULT_CELL_SIZE + 235, Settings.Default.MineFieldHeight * DEFAULT_CELL_SIZE + 35);
            MineFieldPanel.PerformLayout();
            this.PerformLayout();

            

            HideButtons();

            StopTimer();

            TimerLabel.Text = "00:00:00";
            GameStatusLabel.Text = "";
            RemainingMinesLabel.Text = "0";

            if (this.Controls.Find("mineMenu", false)[0] is MenuStrip mineMenu)
            {
                mineMenu.Items[2].Text = "Hint (" + Settings.Default.HintCount + ")";
                mineMenu.Items[2].Enabled = false;
            }

            ClearMineButtons();

            RemainingMinesLabel.Text = Settings.Default.MineCount.ToString();
            BoardDetailsLabel.Text = Settings.Default.MineFieldWidth.ToString() + " x " + Settings.Default.MineFieldHeight.ToString() + " - 1:" + (Settings.Default.MineFieldWidth * Settings.Default.MineFieldHeight / Settings.Default.MineCount);

            GenerateMineButtons();

            ShowButtons();

            MineFieldPanel.Enabled = false;

            StartPanel.Location = new Point((MineFieldPanel.Width - StartPanel.Width) / 2 + MineFieldPanel.Left, (MineFieldPanel.Height - StartPanel.Height) / 2 + MineFieldPanel.Top);
            StartPanel.Visible = true;
            StartPanel.BringToFront();
        }

        private void StartGame()
        {
            if (!MineSweeperPro.IsGameStarted)
            {
                MineSweeperPro.IsGameStarted = true;
                StartPanel.Visible = false;
                MineFieldPanel.Enabled = true;

                if (this.Controls.Find("mineMenu", false)[0] is MenuStrip mineMenu)
                {
                    mineMenu.Items[2].Enabled = true;
                }

                StartTimer();

                RevealLargestCluster();
            }
        }

        private void ValidateWin()
        {
            if (MineSweeperPro != null)
            {
                if (!MineSweeperPro.IsGameOver && MineSweeperPro.ValidateWin())
                {
                    StopTimer();
                    GameStatusLabel.Text = "You Won!";
                    GameStatusLabel.ForeColor = Color.Green;
                    if (Controls.Find("mineMenu", false)[0] is MenuStrip menu)
                    {
                        menu.Items[2].Enabled = false;
                    }

                    SoundPlayer.AddToQueue(Sound.WinSound);
                }
            }
        }

        private void GameOver(MineCell mineCell)
        {
            StopTimer();

            SoundPlayer.Play(Sound.GameOverSound);

            if (MineSweeperPro != null)
            {
                MineSweeperPro.IsGameOver = true;

                RevealAllMines(mineCell);

                GameStatusLabel.Text = "You Exploded!";
                GameStatusLabel.ForeColor = Color.Red;
                DoubleClickButton mineCellButton = MineCellButtonDictionary[string.Concat(mineCell.X.ToString(), ",", mineCell.Y.ToString())] as DoubleClickButton;
                if (mineCellButton != null)
                {
                    mineCellButton.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellNumberColor5);
                }

                if (Controls.Find("mineMenu", false)[0] is MenuStrip menu)
                {
                    menu.Items[2].Enabled = false;
                }
            }

            
        }
        private void CreateMenu()
        {
            MenuStrip menu = new MenuStrip();
            menu.Name = "mineMenu";
            menu.Margin = new Padding(0);
            menu.Padding = new Padding(0);
            menu.Height = 40;
            menu.Items.Add("New Game");
            menu.Items.Add("Settings");
            menu.Items.Add("Hint (" + Settings.Default.HintCount + ")");
            menu.Items[0].Click += new EventHandler(NewGame_Click);
            menu.Items[0].MouseEnter += new EventHandler(menuItem_MouseEnter);
            menu.Items[0].MouseLeave += new EventHandler(menuItem_MouseLeave);

            menu.Items[1].Click += new EventHandler(Settings_Click);
            menu.Items[1].MouseEnter += new EventHandler(menuItem_MouseEnter);
            menu.Items[1].MouseLeave += new EventHandler(menuItem_MouseLeave);

            menu.Items[2].Click += new EventHandler(Hint_Click);
            menu.Items[2].MouseEnter += new EventHandler(menuItem_MouseEnter);
            menu.Items[2].MouseLeave += new EventHandler(menuItem_MouseLeave);

            Controls.Add(menu);
        }

        private void Menu_MouseEnter(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SetButtonColor(DoubleClickButton button, int mineCount)
        {
            button.FlatAppearance.BorderSize = 0;

            switch (mineCount)
            {
                case 1:
                    button.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellNumberColor1);
                    break;
                case 2:
                    button.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellNumberColor2);
                    break;
                case 3:
                    button.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellNumberColor3);
                    break;
                case 4:
                    button.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellNumberColor4);
                    break;
                case 5:
                    button.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellNumberColor5);
                    break;
                case 6:
                    button.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellNumberColor7);
                    break;
                case 7:
                    button.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellNumberColor7);
                    break;
                case 8:
                    button.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellNumberColor8);
                    break;
                default:
                    button.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellNumberColor0);
                    break;
            }
        }

        private void GenerateMineButtons()
        {
            for (int i = 0; i < Settings.Default.MineFieldWidth; i++)
            {
                for (int j = 0; j < Settings.Default.MineFieldHeight; j++)
                {
                    DoubleClickButton btn = new();
                    btn.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellBackColor);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Size = new Size(DEFAULT_CELL_SIZE - 5, DEFAULT_CELL_SIZE - 5);
                    btn.FlatAppearance.BorderSize = 0;

                    int cornerRadius = 10;

                    // Create a rounded rectangle shape using GraphicsPath
                    GraphicsPath path = new GraphicsPath();
                    path.AddArc(btn.ClientRectangle.Left, btn.ClientRectangle.Top, cornerRadius, cornerRadius, 180, 90);
                    path.AddArc(btn.ClientRectangle.Right - cornerRadius, btn.ClientRectangle.Top, cornerRadius, cornerRadius, 270, 90);
                    path.AddArc(btn.ClientRectangle.Right - cornerRadius, btn.ClientRectangle.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                    path.AddArc(btn.ClientRectangle.Left, btn.ClientRectangle.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                    path.CloseFigure();

                    btn.Region = new Region(path);
                    btn.Name = i + "," + j;
                    btn.Location = new Point((DEFAULT_CELL_SIZE * i) + 5, (DEFAULT_CELL_SIZE * j) + 5);
                    btn.MouseDown += new MouseEventHandler(Btn_MouseDown);
                    btn.Dock = DockStyle.None;

                    MineFieldPanel.Controls.Add(btn);
                    MineCellButtonDictionary[btn.Name] = btn;
                }
            }
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
                                mineCellButton.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellExplodedBackColor);
                                mineCellButton.Image = Properties.Resources.greenflag_small;
                            }

                            if (mineCell == explodedMineCell)
                            {

                                mineCellButton.Image = MineImage;
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

                if (Controls.Find("mineMenu", false)[0] is MenuStrip menu)
                {
                    menu.Items[2].Text = "Hint (" + remainingHintCount + ")";
                }
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

                    if (!MineSweeperPro.IsGameOver)
                    {
                        RevealCluster(mineCell);

                        ValidateWin();

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

                        mineCellButton.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellActivatedBackColor); ;
                        mineCellButton.Image = null;
                        mineCellButton.Text = mineCell.SurroundingMineCount.ToString();
                        mineCellButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                        mineCellButton.MouseDown -= Btn_MouseDown;
                        mineCellButton.DoubleClick += Btn_DoubleClick;

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

                        mineCellButton.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellActivatedBackColor); ;
                        mineCellButton.Image = null;
                        mineCellButton.Text = mineCell.SurroundingMineCount.ToString();
                        mineCellButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                        mineCellButton.MouseDown -= Btn_MouseDown;
                        mineCellButton.DoubleClick += Btn_DoubleClick;

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
                        mineCellButton.Image = FlagImage;
                        mineCellButton.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellFlaggedBackColor);
                        mineCell.Status = MineCellStatusEnum.Flagged;

                        MineSweeperPro.MineField.MineCellsFlaggedCounter++;
                        RemainingMinesLabel.Text = (Settings.Default.MineCount - MineSweeperPro.MineField.MineCellsFlaggedCounter).ToString();
                    }
                    else if (mineCell.Status == MineCellStatusEnum.Flagged)
                    {
                        SoundPlayer.Play(Sound.FlagOffSound);

                        mineCellButton.Text = "";
                        mineCellButton.Image = null;
                        mineCellButton.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellBackColor);
                        mineCell.Status = MineCellStatusEnum.Default;

                        MineSweeperPro.MineField.MineCellsFlaggedCounter--;
                        RemainingMinesLabel.Text = (Settings.Default.MineCount - MineSweeperPro.MineField.MineCellsFlaggedCounter).ToString();
                    }
                }
            }
        }

        private void UpdateDebugPanel(MineCell mineCell, string triggeringEvent)
        {
            if (MineSweeperPro != null && MineSweeperPro.MineField != null)
            {
                DebugRevealedLabel.Text = "Revealed: " + MineSweeperPro.MineField.MineCellsRevealedCounter.ToString();
                DebugMinesFlaggedLabel.Text = "Flagged: " + MineSweeperPro.MineField.MineCellsFlaggedCounter.ToString();
                DebugEventLabel.Text = "Event: " + triggeringEvent;

                var mineCellGroup = MineSweeperPro.MineField.GetMineCellGroup(mineCell);
                if (mineCellGroup != null)
                {
                    DebugGroupButton1.Text = mineCellGroup[0].SurroundingMineCount.ToString();
                    SetButtonColor(DebugGroupButton1, mineCellGroup[0].SurroundingMineCount);

                    DebugGroupButton4.Text = mineCellGroup[1].SurroundingMineCount.ToString();
                    SetButtonColor(DebugGroupButton2, mineCellGroup[1].SurroundingMineCount);

                    DebugGroupButton7.Text = mineCellGroup[2].SurroundingMineCount.ToString();
                    SetButtonColor(DebugGroupButton3, mineCellGroup[2].SurroundingMineCount);

                    if (mineCellGroup.Count > 3)
                    {
                        DebugGroupButton2.Text = mineCellGroup[3].SurroundingMineCount.ToString();
                        SetButtonColor(DebugGroupButton4, mineCellGroup[3].SurroundingMineCount);

                        DebugGroupButton5.Text = mineCell.SurroundingMineCount.ToString();
                        SetButtonColor(DebugGroupButton5, mineCell.SurroundingMineCount);

                        if (mineCellGroup.Count > 5)
                        {
                            DebugGroupButton8.Text = mineCellGroup[4].SurroundingMineCount.ToString();
                            SetButtonColor(DebugGroupButton6, mineCellGroup[4].SurroundingMineCount);

                            DebugGroupButton3.Text = mineCellGroup[5].SurroundingMineCount.ToString();
                            SetButtonColor(DebugGroupButton7, mineCellGroup[5].SurroundingMineCount);

                            DebugGroupButton6.Text = mineCellGroup[6].SurroundingMineCount.ToString();
                            SetButtonColor(DebugGroupButton8, mineCellGroup[6].SurroundingMineCount);

                            DebugGroupButton9.Text = mineCellGroup[7].SurroundingMineCount.ToString();
                            SetButtonColor(DebugGroupButton9, mineCellGroup[7].SurroundingMineCount);
                        }
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
                }

                if (!MineSweeperPro.IsGameOver)
                {
                    ValidateWin();
                }

                UpdateDebugPanel(mineCell, "DOUBLE_CLICK");
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
                        }
                        else
                        {
                            SoundPlayer.AddToQueue(Sound.CellRevealSound, 100);
                            RevealMineCell(mineCell);
                        }
                    }

                    if (!MineSweeperPro.IsGameOver)
                    {
                        ValidateWin();
                    }

                    UpdateDebugPanel(mineCell, "LEFT_CLICK");
                }
                else if (e.Button == MouseButtons.Right)
                {
                    ToggleFlag(mineCell);
                    UpdateDebugPanel(mineCell, "RIGHT_CLICK");
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    UseHint();

                    if (!MineSweeperPro.IsGameOver)
                    {
                        ValidateWin();
                    }

                    UpdateDebugPanel(mineCell, "MIDDLE_CLICK");
                }

            }
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            ApplyTheme();
            NewGame();
        }

        private void Hint_Click(object sender, EventArgs e)
        {
            if (!MineSweeperPro.IsGameStarted)
            {
                MineSweeperPro.IsGameStarted = true;

                StartTimer();
            }

            UseHint();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            using (SettingsDialog settingsForm = new SettingsDialog())
            {

                settingsForm.Owner = this;
                settingsForm.StartPosition = FormStartPosition.CenterParent;
                settingsForm.CreateNewGameEvent += CreateNewGameHandler;
                settingsForm.ShowDialog();
            }
        }

        private void menuItem_MouseEnter(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            menuItem.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MenuHoverBackgroundColor);
            menuItem.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MenuHoverTextColor);
        }

        private void menuItem_MouseLeave(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            menuItem.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MenuBackColor);
            menuItem.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.MenuTextColor);
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
    }
}
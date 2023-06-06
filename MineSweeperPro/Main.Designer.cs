using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MineSweeperPro
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TimerLabel = new Label();
            GameBoardPanel = new Panel();
            StatusPanel = new Panel();
            GameControlPanel = new Panel();
            ConfigButtonPanel = new Panel();
            ConfigPictureBox = new PictureBox();
            ConfigLabel = new Label();
            ShareButtonPanel = new Panel();
            SharePictureBox = new PictureBox();
            ShareLabel = new Label();
            HintButtonPanel = new Panel();
            HintPictureBox = new PictureBox();
            HintLabel = new Label();
            NewButtonPanel = new Panel();
            NewGamePictureBox = new PictureBox();
            NewLabel = new Label();
            UsernameLabel = new Label();
            ProfilePictureBox = new RoundedPictureBox();
            RemainingMineCountPanel = new Panel();
            RemainingMinesLabel = new Label();
            StatusMineIconLabel = new Label();
            MineFieldPanel = new Panel();
            EfficiencyLabel = new Label();
            BBBVTotalLabel = new Label();
            BBBVSLabel = new Label();
            BBBVLabel = new Label();
            StartPanel = new Panel();
            NewGameExpertButton = new System.Windows.Forms.Button();
            NewGameHardButton = new System.Windows.Forms.Button();
            NewGameMediumButton = new System.Windows.Forms.Button();
            NewGameEasyButton = new System.Windows.Forms.Button();
            EndGamePanel = new Panel();
            GameTypeComboBox = new BorderedComboBox();
            LeaderBoardPanel = new Panel();
            ShowBoardButton = new System.Windows.Forms.Button();
            FinalTimeLabel = new Label();
            WinLoseLabel = new Label();
            GameStatsPanel = new Panel();
            HintsUsedValueLabel = new Label();
            HintsUsedLabel = new Label();
            MineCountValueLabel = new Label();
            MineCountLabel = new Label();
            BoardSizeValueLabel = new Label();
            BoardSizeLabel = new Label();
            EfficiencyValueLabel = new Label();
            BBBVTotalValueLabel = new Label();
            BBBVSValueLabel = new Label();
            BBBVValueLabel = new Label();
            LeaderBoardTitleLabel = new Label();
            NewGameButton = new System.Windows.Forms.Button();
            GameBoardPanel.SuspendLayout();
            StatusPanel.SuspendLayout();
            GameControlPanel.SuspendLayout();
            ConfigButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ConfigPictureBox).BeginInit();
            ShareButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SharePictureBox).BeginInit();
            HintButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HintPictureBox).BeginInit();
            NewButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NewGamePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProfilePictureBox).BeginInit();
            RemainingMineCountPanel.SuspendLayout();
            StartPanel.SuspendLayout();
            EndGamePanel.SuspendLayout();
            GameStatsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // TimerLabel
            // 
            TimerLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TimerLabel.BackColor = Color.Transparent;
            TimerLabel.Font = new Font("Consolas", 16F, FontStyle.Bold, GraphicsUnit.Point);
            TimerLabel.Location = new Point(0, 213);
            TimerLabel.Margin = new Padding(0);
            TimerLabel.Name = "TimerLabel";
            TimerLabel.Size = new Size(230, 47);
            TimerLabel.TabIndex = 2;
            TimerLabel.Text = "00:00:00";
            TimerLabel.TextAlign = ContentAlignment.MiddleCenter;
            TimerLabel.Click += TimerLabel_Click;
            // 
            // GameBoardPanel
            // 
            GameBoardPanel.AutoSize = true;
            GameBoardPanel.Controls.Add(StatusPanel);
            GameBoardPanel.Controls.Add(MineFieldPanel);
            GameBoardPanel.Location = new Point(0, 0);
            GameBoardPanel.Margin = new Padding(0);
            GameBoardPanel.Name = "GameBoardPanel";
            GameBoardPanel.Size = new Size(1465, 1035);
            GameBoardPanel.TabIndex = 0;
            // 
            // StatusPanel
            // 
            StatusPanel.Controls.Add(GameControlPanel);
            StatusPanel.Controls.Add(UsernameLabel);
            StatusPanel.Controls.Add(ProfilePictureBox);
            StatusPanel.Controls.Add(RemainingMineCountPanel);
            StatusPanel.Controls.Add(TimerLabel);
            StatusPanel.Location = new Point(1005, 0);
            StatusPanel.Margin = new Padding(0);
            StatusPanel.Name = "StatusPanel";
            StatusPanel.Size = new Size(250, 1035);
            StatusPanel.TabIndex = 1;
            // 
            // GameControlPanel
            // 
            GameControlPanel.Controls.Add(ConfigButtonPanel);
            GameControlPanel.Controls.Add(ShareButtonPanel);
            GameControlPanel.Controls.Add(HintButtonPanel);
            GameControlPanel.Controls.Add(NewButtonPanel);
            GameControlPanel.Location = new Point(0, 0);
            GameControlPanel.Name = "GameControlPanel";
            GameControlPanel.Size = new Size(250, 50);
            GameControlPanel.TabIndex = 0;
            // 
            // ConfigButtonPanel
            // 
            ConfigButtonPanel.Controls.Add(ConfigPictureBox);
            ConfigButtonPanel.Controls.Add(ConfigLabel);
            ConfigButtonPanel.Location = new Point(190, 0);
            ConfigButtonPanel.Margin = new Padding(0);
            ConfigButtonPanel.Name = "ConfigButtonPanel";
            ConfigButtonPanel.Size = new Size(50, 50);
            ConfigButtonPanel.TabIndex = 0;
            // 
            // ConfigPictureBox
            // 
            ConfigPictureBox.Cursor = Cursors.Hand;
            ConfigPictureBox.Location = new Point(10, 0);
            ConfigPictureBox.Name = "ConfigPictureBox";
            ConfigPictureBox.Size = new Size(30, 30);
            ConfigPictureBox.TabIndex = 27;
            ConfigPictureBox.TabStop = false;
            ConfigPictureBox.Click += ConfigPictureBox_Click;
            // 
            // ConfigLabel
            // 
            ConfigLabel.Font = new Font("Consolas", 6F, FontStyle.Regular, GraphicsUnit.Point);
            ConfigLabel.Location = new Point(0, 30);
            ConfigLabel.Margin = new Padding(0);
            ConfigLabel.Name = "ConfigLabel";
            ConfigLabel.Size = new Size(50, 20);
            ConfigLabel.TabIndex = 34;
            ConfigLabel.Text = "Config";
            ConfigLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ShareButtonPanel
            // 
            ShareButtonPanel.Controls.Add(SharePictureBox);
            ShareButtonPanel.Controls.Add(ShareLabel);
            ShareButtonPanel.Location = new Point(130, 0);
            ShareButtonPanel.Margin = new Padding(0);
            ShareButtonPanel.Name = "ShareButtonPanel";
            ShareButtonPanel.Size = new Size(50, 50);
            ShareButtonPanel.TabIndex = 0;
            // 
            // SharePictureBox
            // 
            SharePictureBox.Cursor = Cursors.Hand;
            SharePictureBox.Location = new Point(10, 0);
            SharePictureBox.Name = "SharePictureBox";
            SharePictureBox.Size = new Size(30, 30);
            SharePictureBox.TabIndex = 30;
            SharePictureBox.TabStop = false;
            SharePictureBox.Click += SharePictureBox_Click;
            // 
            // ShareLabel
            // 
            ShareLabel.Font = new Font("Consolas", 6F, FontStyle.Regular, GraphicsUnit.Point);
            ShareLabel.Location = new Point(0, 30);
            ShareLabel.Margin = new Padding(0);
            ShareLabel.Name = "ShareLabel";
            ShareLabel.Size = new Size(50, 20);
            ShareLabel.TabIndex = 33;
            ShareLabel.Text = "Share";
            ShareLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HintButtonPanel
            // 
            HintButtonPanel.Controls.Add(HintPictureBox);
            HintButtonPanel.Controls.Add(HintLabel);
            HintButtonPanel.Location = new Point(70, 0);
            HintButtonPanel.Margin = new Padding(0);
            HintButtonPanel.Name = "HintButtonPanel";
            HintButtonPanel.Size = new Size(50, 50);
            HintButtonPanel.TabIndex = 0;
            // 
            // HintPictureBox
            // 
            HintPictureBox.Cursor = Cursors.Hand;
            HintPictureBox.Location = new Point(10, 0);
            HintPictureBox.Name = "HintPictureBox";
            HintPictureBox.Size = new Size(30, 30);
            HintPictureBox.TabIndex = 29;
            HintPictureBox.TabStop = false;
            HintPictureBox.Click += HintPictureBox_Click;
            // 
            // HintLabel
            // 
            HintLabel.Font = new Font("Consolas", 6F, FontStyle.Regular, GraphicsUnit.Point);
            HintLabel.Location = new Point(0, 30);
            HintLabel.Margin = new Padding(0);
            HintLabel.Name = "HintLabel";
            HintLabel.Size = new Size(50, 20);
            HintLabel.TabIndex = 32;
            HintLabel.Text = "Hint";
            HintLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NewButtonPanel
            // 
            NewButtonPanel.Controls.Add(NewGamePictureBox);
            NewButtonPanel.Controls.Add(NewLabel);
            NewButtonPanel.Location = new Point(10, 0);
            NewButtonPanel.Margin = new Padding(0);
            NewButtonPanel.Name = "NewButtonPanel";
            NewButtonPanel.Size = new Size(50, 50);
            NewButtonPanel.TabIndex = 0;
            // 
            // NewGamePictureBox
            // 
            NewGamePictureBox.Cursor = Cursors.Hand;
            NewGamePictureBox.Location = new Point(10, 0);
            NewGamePictureBox.Name = "NewGamePictureBox";
            NewGamePictureBox.Size = new Size(30, 30);
            NewGamePictureBox.TabIndex = 28;
            NewGamePictureBox.TabStop = false;
            NewGamePictureBox.Click += NewGamePictureBox_Click;
            // 
            // NewLabel
            // 
            NewLabel.Font = new Font("Consolas", 6F, FontStyle.Regular, GraphicsUnit.Point);
            NewLabel.Location = new Point(0, 30);
            NewLabel.Margin = new Padding(0);
            NewLabel.Name = "NewLabel";
            NewLabel.Size = new Size(50, 20);
            NewLabel.TabIndex = 31;
            NewLabel.Text = "New";
            NewLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UsernameLabel
            // 
            UsernameLabel.BackColor = Color.Transparent;
            UsernameLabel.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point);
            UsernameLabel.Location = new Point(0, 160);
            UsernameLabel.Margin = new Padding(0);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(230, 51);
            UsernameLabel.TabIndex = 8;
            UsernameLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // ProfilePictureBox
            // 
            ProfilePictureBox.Cursor = Cursors.Hand;
            ProfilePictureBox.Location = new Point(40, 25);
            ProfilePictureBox.Margin = new Padding(0);
            ProfilePictureBox.Name = "ProfilePictureBox";
            ProfilePictureBox.Size = new Size(150, 150);
            ProfilePictureBox.TabIndex = 7;
            ProfilePictureBox.TabStop = false;
            ProfilePictureBox.Click += ProfilePictureBox_Click;
            // 
            // RemainingMineCountPanel
            // 
            RemainingMineCountPanel.Controls.Add(RemainingMinesLabel);
            RemainingMineCountPanel.Controls.Add(StatusMineIconLabel);
            RemainingMineCountPanel.Location = new Point(0, 275);
            RemainingMineCountPanel.Name = "RemainingMineCountPanel";
            RemainingMineCountPanel.Size = new Size(145, 45);
            RemainingMineCountPanel.TabIndex = 26;
            // 
            // RemainingMinesLabel
            // 
            RemainingMinesLabel.Font = new Font("Consolas", 16F, FontStyle.Bold, GraphicsUnit.Point);
            RemainingMinesLabel.Location = new Point(60, 0);
            RemainingMinesLabel.Margin = new Padding(0);
            RemainingMinesLabel.Name = "RemainingMinesLabel";
            RemainingMinesLabel.Size = new Size(75, 45);
            RemainingMinesLabel.TabIndex = 4;
            RemainingMinesLabel.Text = "200";
            RemainingMinesLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // StatusMineIconLabel
            // 
            StatusMineIconLabel.Location = new Point(10, 4);
            StatusMineIconLabel.Name = "StatusMineIconLabel";
            StatusMineIconLabel.Size = new Size(40, 40);
            StatusMineIconLabel.TabIndex = 3;
            // 
            // MineFieldPanel
            // 
            MineFieldPanel.Location = new Point(0, 0);
            MineFieldPanel.Margin = new Padding(0);
            MineFieldPanel.Name = "MineFieldPanel";
            MineFieldPanel.Size = new Size(1235, 1035);
            MineFieldPanel.TabIndex = 0;
            // 
            // EfficiencyLabel
            // 
            EfficiencyLabel.AutoSize = true;
            EfficiencyLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            EfficiencyLabel.Location = new Point(0, 75);
            EfficiencyLabel.Name = "EfficiencyLabel";
            EfficiencyLabel.Size = new Size(96, 17);
            EfficiencyLabel.TabIndex = 25;
            EfficiencyLabel.Text = "Efficiency:";
            EfficiencyLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BBBVTotalLabel
            // 
            BBBVTotalLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            BBBVTotalLabel.Location = new Point(0, 50);
            BBBVTotalLabel.Name = "BBBVTotalLabel";
            BBBVTotalLabel.Size = new Size(225, 20);
            BBBVTotalLabel.TabIndex = 24;
            BBBVTotalLabel.Text = "Total Reveal Clicks (3BVT):";
            BBBVTotalLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BBBVSLabel
            // 
            BBBVSLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            BBBVSLabel.Location = new Point(0, 25);
            BBBVSLabel.Name = "BBBVSLabel";
            BBBVSLabel.Size = new Size(225, 20);
            BBBVSLabel.TabIndex = 23;
            BBBVSLabel.Text = "Reveals/Sec (3BV/S):";
            BBBVSLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BBBVLabel
            // 
            BBBVLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            BBBVLabel.Location = new Point(0, 0);
            BBBVLabel.Name = "BBBVLabel";
            BBBVLabel.Size = new Size(225, 20);
            BBBVLabel.TabIndex = 22;
            BBBVLabel.Text = "Min. clicks to win (3BV):";
            BBBVLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // StartPanel
            // 
            StartPanel.Controls.Add(NewGameExpertButton);
            StartPanel.Controls.Add(NewGameHardButton);
            StartPanel.Controls.Add(NewGameMediumButton);
            StartPanel.Controls.Add(NewGameEasyButton);
            StartPanel.Location = new Point(0, 0);
            StartPanel.Name = "StartPanel";
            StartPanel.Size = new Size(396, 150);
            StartPanel.TabIndex = 0;
            StartPanel.Visible = false;
            // 
            // NewGameExpertButton
            // 
            NewGameExpertButton.FlatAppearance.BorderSize = 0;
            NewGameExpertButton.FlatStyle = FlatStyle.Flat;
            NewGameExpertButton.Location = new Point(288, 19);
            NewGameExpertButton.Name = "NewGameExpertButton";
            NewGameExpertButton.Size = new Size(91, 102);
            NewGameExpertButton.TabIndex = 4;
            NewGameExpertButton.Text = "Expert";
            NewGameExpertButton.UseVisualStyleBackColor = true;
            NewGameExpertButton.Click += NewGameExpertButton_Click;
            // 
            // NewGameHardButton
            // 
            NewGameHardButton.FlatAppearance.BorderSize = 0;
            NewGameHardButton.FlatStyle = FlatStyle.Flat;
            NewGameHardButton.Location = new Point(206, 19);
            NewGameHardButton.Name = "NewGameHardButton";
            NewGameHardButton.Size = new Size(91, 102);
            NewGameHardButton.TabIndex = 2;
            NewGameHardButton.Text = "Hard";
            NewGameHardButton.UseVisualStyleBackColor = true;
            NewGameHardButton.Click += NewGameHardButton_Click;
            // 
            // NewGameMediumButton
            // 
            NewGameMediumButton.FlatAppearance.BorderSize = 0;
            NewGameMediumButton.FlatStyle = FlatStyle.Flat;
            NewGameMediumButton.Location = new Point(109, 19);
            NewGameMediumButton.Name = "NewGameMediumButton";
            NewGameMediumButton.Size = new Size(91, 102);
            NewGameMediumButton.TabIndex = 1;
            NewGameMediumButton.Text = "Medium";
            NewGameMediumButton.UseVisualStyleBackColor = true;
            NewGameMediumButton.Click += NewGameMediumButton_Click;
            // 
            // NewGameEasyButton
            // 
            NewGameEasyButton.FlatAppearance.BorderSize = 0;
            NewGameEasyButton.FlatStyle = FlatStyle.Flat;
            NewGameEasyButton.Location = new Point(12, 19);
            NewGameEasyButton.Name = "NewGameEasyButton";
            NewGameEasyButton.Size = new Size(91, 102);
            NewGameEasyButton.TabIndex = 0;
            NewGameEasyButton.Text = "Easy";
            NewGameEasyButton.UseVisualStyleBackColor = true;
            NewGameEasyButton.Click += StartButton_Click;
            // 
            // EndGamePanel
            // 
            EndGamePanel.Controls.Add(GameTypeComboBox);
            EndGamePanel.Controls.Add(LeaderBoardPanel);
            EndGamePanel.Controls.Add(ShowBoardButton);
            EndGamePanel.Controls.Add(FinalTimeLabel);
            EndGamePanel.Controls.Add(WinLoseLabel);
            EndGamePanel.Controls.Add(GameStatsPanel);
            EndGamePanel.Controls.Add(LeaderBoardTitleLabel);
            EndGamePanel.Controls.Add(NewGameButton);
            EndGamePanel.Location = new Point(130, 140);
            EndGamePanel.Name = "EndGamePanel";
            EndGamePanel.Size = new Size(474, 686);
            EndGamePanel.TabIndex = 0;
            EndGamePanel.Visible = false;
            // 
            // GameTypeComboBox
            // 
            GameTypeComboBox.FlatStyle = FlatStyle.Flat;
            GameTypeComboBox.FormattingEnabled = true;
            GameTypeComboBox.Location = new Point(132, 628);
            GameTypeComboBox.Name = "GameTypeComboBox";
            GameTypeComboBox.Size = new Size(198, 33);
            GameTypeComboBox.TabIndex = 37;
            // 
            // LeaderBoardPanel
            // 
            LeaderBoardPanel.Location = new Point(87, 363);
            LeaderBoardPanel.Name = "LeaderBoardPanel";
            LeaderBoardPanel.Size = new Size(300, 162);
            LeaderBoardPanel.TabIndex = 36;
            // 
            // ShowBoardButton
            // 
            ShowBoardButton.FlatAppearance.BorderSize = 0;
            ShowBoardButton.FlatStyle = FlatStyle.Flat;
            ShowBoardButton.Location = new Point(436, 3);
            ShowBoardButton.Name = "ShowBoardButton";
            ShowBoardButton.Size = new Size(35, 34);
            ShowBoardButton.TabIndex = 35;
            ShowBoardButton.Text = "X";
            ShowBoardButton.UseVisualStyleBackColor = true;
            ShowBoardButton.Click += ShowBoardButton_Click;
            // 
            // FinalTimeLabel
            // 
            FinalTimeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FinalTimeLabel.BackColor = Color.Transparent;
            FinalTimeLabel.Font = new Font("Consolas", 16F, FontStyle.Bold, GraphicsUnit.Point);
            FinalTimeLabel.Location = new Point(137, 60);
            FinalTimeLabel.Margin = new Padding(0);
            FinalTimeLabel.Name = "FinalTimeLabel";
            FinalTimeLabel.Size = new Size(230, 47);
            FinalTimeLabel.TabIndex = 5;
            FinalTimeLabel.Text = "00:00:00";
            FinalTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WinLoseLabel
            // 
            WinLoseLabel.AutoSize = true;
            WinLoseLabel.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point);
            WinLoseLabel.Location = new Point(134, 13);
            WinLoseLabel.Name = "WinLoseLabel";
            WinLoseLabel.Size = new Size(178, 42);
            WinLoseLabel.TabIndex = 4;
            WinLoseLabel.Text = "You Won!";
            // 
            // GameStatsPanel
            // 
            GameStatsPanel.Controls.Add(HintsUsedValueLabel);
            GameStatsPanel.Controls.Add(HintsUsedLabel);
            GameStatsPanel.Controls.Add(MineCountValueLabel);
            GameStatsPanel.Controls.Add(MineCountLabel);
            GameStatsPanel.Controls.Add(BoardSizeValueLabel);
            GameStatsPanel.Controls.Add(BoardSizeLabel);
            GameStatsPanel.Controls.Add(EfficiencyValueLabel);
            GameStatsPanel.Controls.Add(BBBVTotalValueLabel);
            GameStatsPanel.Controls.Add(BBBVSValueLabel);
            GameStatsPanel.Controls.Add(BBBVValueLabel);
            GameStatsPanel.Controls.Add(EfficiencyLabel);
            GameStatsPanel.Controls.Add(BBBVTotalLabel);
            GameStatsPanel.Controls.Add(BBBVSLabel);
            GameStatsPanel.Controls.Add(BBBVLabel);
            GameStatsPanel.Location = new Point(87, 121);
            GameStatsPanel.Name = "GameStatsPanel";
            GameStatsPanel.Size = new Size(300, 175);
            GameStatsPanel.TabIndex = 3;
            // 
            // HintsUsedValueLabel
            // 
            HintsUsedValueLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            HintsUsedValueLabel.Location = new Point(225, 150);
            HintsUsedValueLabel.Name = "HintsUsedValueLabel";
            HintsUsedValueLabel.Size = new Size(75, 20);
            HintsUsedValueLabel.TabIndex = 43;
            HintsUsedValueLabel.Text = "0";
            HintsUsedValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // HintsUsedLabel
            // 
            HintsUsedLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            HintsUsedLabel.Location = new Point(0, 150);
            HintsUsedLabel.Name = "HintsUsedLabel";
            HintsUsedLabel.Size = new Size(225, 20);
            HintsUsedLabel.TabIndex = 42;
            HintsUsedLabel.Text = "Hints Used:";
            HintsUsedLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MineCountValueLabel
            // 
            MineCountValueLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            MineCountValueLabel.Location = new Point(225, 125);
            MineCountValueLabel.Name = "MineCountValueLabel";
            MineCountValueLabel.Size = new Size(75, 20);
            MineCountValueLabel.TabIndex = 41;
            MineCountValueLabel.Text = "0";
            MineCountValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MineCountLabel
            // 
            MineCountLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            MineCountLabel.Location = new Point(0, 125);
            MineCountLabel.Name = "MineCountLabel";
            MineCountLabel.Size = new Size(225, 20);
            MineCountLabel.TabIndex = 40;
            MineCountLabel.Text = "Mine Count:";
            MineCountLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BoardSizeValueLabel
            // 
            BoardSizeValueLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            BoardSizeValueLabel.Location = new Point(225, 100);
            BoardSizeValueLabel.Name = "BoardSizeValueLabel";
            BoardSizeValueLabel.Size = new Size(75, 20);
            BoardSizeValueLabel.TabIndex = 39;
            BoardSizeValueLabel.Text = "0 x 0";
            BoardSizeValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BoardSizeLabel
            // 
            BoardSizeLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            BoardSizeLabel.Location = new Point(0, 100);
            BoardSizeLabel.Name = "BoardSizeLabel";
            BoardSizeLabel.Size = new Size(225, 20);
            BoardSizeLabel.TabIndex = 38;
            BoardSizeLabel.Text = "Board Size:";
            BoardSizeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EfficiencyValueLabel
            // 
            EfficiencyValueLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            EfficiencyValueLabel.Location = new Point(225, 75);
            EfficiencyValueLabel.Name = "EfficiencyValueLabel";
            EfficiencyValueLabel.Size = new Size(75, 20);
            EfficiencyValueLabel.TabIndex = 29;
            EfficiencyValueLabel.Text = "0";
            EfficiencyValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BBBVTotalValueLabel
            // 
            BBBVTotalValueLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            BBBVTotalValueLabel.Location = new Point(225, 50);
            BBBVTotalValueLabel.Name = "BBBVTotalValueLabel";
            BBBVTotalValueLabel.Size = new Size(75, 20);
            BBBVTotalValueLabel.TabIndex = 28;
            BBBVTotalValueLabel.Text = "0";
            BBBVTotalValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BBBVSValueLabel
            // 
            BBBVSValueLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            BBBVSValueLabel.Location = new Point(225, 25);
            BBBVSValueLabel.Name = "BBBVSValueLabel";
            BBBVSValueLabel.Size = new Size(75, 20);
            BBBVSValueLabel.TabIndex = 27;
            BBBVSValueLabel.Text = "0";
            BBBVSValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BBBVValueLabel
            // 
            BBBVValueLabel.Font = new Font("Consolas", 7F, FontStyle.Regular, GraphicsUnit.Point);
            BBBVValueLabel.Location = new Point(225, 0);
            BBBVValueLabel.Name = "BBBVValueLabel";
            BBBVValueLabel.Size = new Size(75, 20);
            BBBVValueLabel.TabIndex = 26;
            BBBVValueLabel.Text = "0";
            BBBVValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LeaderBoardTitleLabel
            // 
            LeaderBoardTitleLabel.AutoSize = true;
            LeaderBoardTitleLabel.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point);
            LeaderBoardTitleLabel.Location = new Point(113, 319);
            LeaderBoardTitleLabel.Name = "LeaderBoardTitleLabel";
            LeaderBoardTitleLabel.Size = new Size(258, 42);
            LeaderBoardTitleLabel.TabIndex = 2;
            LeaderBoardTitleLabel.Text = "Leader Board";
            // 
            // NewGameButton
            // 
            NewGameButton.FlatAppearance.BorderSize = 0;
            NewGameButton.FlatStyle = FlatStyle.Flat;
            NewGameButton.Location = new Point(132, 562);
            NewGameButton.Name = "NewGameButton";
            NewGameButton.Size = new Size(198, 49);
            NewGameButton.TabIndex = 0;
            NewGameButton.Text = "Start New Game";
            NewGameButton.UseVisualStyleBackColor = true;
            NewGameButton.Click += NewGameButton_Click;
            // 
            // Main
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1465, 1035);
            ControlBox = false;
            Controls.Add(EndGamePanel);
            Controls.Add(StartPanel);
            Controls.Add(GameBoardPanel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mine Sweeper Pro";
            Load += Main_Load;
            Shown += Main_Shown;
            ResizeEnd += Main_ResizeEnd;
            Resize += Main_Resize;
            GameBoardPanel.ResumeLayout(false);
            StatusPanel.ResumeLayout(false);
            GameControlPanel.ResumeLayout(false);
            ConfigButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ConfigPictureBox).EndInit();
            ShareButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SharePictureBox).EndInit();
            HintButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)HintPictureBox).EndInit();
            NewButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NewGamePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProfilePictureBox).EndInit();
            RemainingMineCountPanel.ResumeLayout(false);
            StartPanel.ResumeLayout(false);
            EndGamePanel.ResumeLayout(false);
            EndGamePanel.PerformLayout();
            GameStatsPanel.ResumeLayout(false);
            GameStatsPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TimerLabel;
        private Panel MineFieldPanel;
        private Panel StatusPanel;
        private Panel GameBoardPanel;
        private Label RemainingMinesLabel;
        private Label StatusMineIconLabel;
        private Label GameStatusLabel;
        private Label BoardDetailsLabel;
        private RoundedPictureBox ProfilePictureBox;
        private Label UsernameLabel;
        private Label DebugRevealedLabel;
        private Label DebugMinesFlaggedLabel;
        private Panel DebugPanel;
        private DoubleClickButton DebugGroupButton5;
        private DoubleClickButton DebugGroupButton9;
        private DoubleClickButton DebugGroupButton8;
        private DoubleClickButton DebugGroupButton7;
        private Label DebugEventLabel;
        private DoubleClickButton DebugGroupButton6;
        private DoubleClickButton DebugGroupButton1;
        private DoubleClickButton DebugGroupButton2;
        private DoubleClickButton DebugGroupButton4;
        private DoubleClickButton DebugGroupButton3;
        private Panel StartPanel;
        private System.Windows.Forms.Button NewGameEasyButton;
        private Panel EndGamePanel;
        private System.Windows.Forms.Button NewGameButton;
        private Label LeaderBoardTitleLabel;
        private Label BBBVLabel;
        private Label BBBVSLabel;
        private Label BBBVTotalLabel;
        private Label EfficiencyLabel;
        private Panel GameStatsPanel;
        private Label WinLoseLabel;
        private PictureBox ConfigPictureBox;
        private PictureBox SharePictureBox;
        private PictureBox HintPictureBox;
        private PictureBox NewGamePictureBox;
        private Panel GameControlPanel;
        private Panel RemainingMineCountPanel;
        private Label ConfigLabel;
        private Label ShareLabel;
        private Label HintLabel;
        private Label NewLabel;
        private Label FinalTimeLabel;
        private Label EfficiencyValueLabel;
        private Label BBBVTotalValueLabel;
        private Label BBBVSValueLabel;
        private Label BBBVValueLabel;
        private System.Windows.Forms.Button ShowBoardButton;
        private Panel LeaderBoardPanel;
        private Label BoardSizeLabel;
        private Label MineCountValueLabel;
        private Label MineCountLabel;
        private Label BoardSizeValueLabel;
        private Label HintsUsedValueLabel;
        private Label HintsUsedLabel;
        private Panel ConfigButtonPanel;
        private Panel ShareButtonPanel;
        private Panel HintButtonPanel;
        private Panel NewButtonPanel;
        private System.Windows.Forms.Button NewGameExpertButton;
        private System.Windows.Forms.Button NewGameHardButton;
        private System.Windows.Forms.Button NewGameMediumButton;
        private BorderedComboBox GameTypeComboBox;
    }
}
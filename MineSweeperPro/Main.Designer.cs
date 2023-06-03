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
            ConfigLabel = new Label();
            ShareLabel = new Label();
            HintLabel = new Label();
            NewLabel = new Label();
            NewGamePictureBox = new RoundedPictureBox();
            HintPictureBox = new RoundedPictureBox();
            SharePictureBox = new RoundedPictureBox();
            SettingsPictureBox = new RoundedPictureBox();
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
            StartButton = new System.Windows.Forms.Button();
            EndGamePanel = new Panel();
            LeaderBoardPanel = new Panel();
            ShowBoardButton = new System.Windows.Forms.Button();
            FinalTimeLabel = new Label();
            WinLoseLabel = new Label();
            GameStatsPanel = new Panel();
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
            ((System.ComponentModel.ISupportInitialize)NewGamePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HintPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SharePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SettingsPictureBox).BeginInit();
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
            TimerLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
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
            GameControlPanel.Controls.Add(ConfigLabel);
            GameControlPanel.Controls.Add(ShareLabel);
            GameControlPanel.Controls.Add(HintLabel);
            GameControlPanel.Controls.Add(NewLabel);
            GameControlPanel.Controls.Add(NewGamePictureBox);
            GameControlPanel.Controls.Add(HintPictureBox);
            GameControlPanel.Controls.Add(SharePictureBox);
            GameControlPanel.Controls.Add(SettingsPictureBox);
            GameControlPanel.Location = new Point(0, 0);
            GameControlPanel.Name = "GameControlPanel";
            GameControlPanel.Size = new Size(200, 55);
            GameControlPanel.TabIndex = 0;
            // 
            // ConfigLabel
            // 
            ConfigLabel.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            ConfigLabel.Location = new Point(160, 40);
            ConfigLabel.Name = "ConfigLabel";
            ConfigLabel.Size = new Size(50, 15);
            ConfigLabel.TabIndex = 34;
            ConfigLabel.Text = "Config";
            // 
            // ShareLabel
            // 
            ShareLabel.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            ShareLabel.Location = new Point(110, 40);
            ShareLabel.Name = "ShareLabel";
            ShareLabel.Size = new Size(40, 15);
            ShareLabel.TabIndex = 33;
            ShareLabel.Text = "Share";
            // 
            // HintLabel
            // 
            HintLabel.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            HintLabel.Location = new Point(65, 40);
            HintLabel.Name = "HintLabel";
            HintLabel.Size = new Size(40, 15);
            HintLabel.TabIndex = 32;
            HintLabel.Text = "Hint";
            // 
            // NewLabel
            // 
            NewLabel.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            NewLabel.Location = new Point(10, 40);
            NewLabel.Name = "NewLabel";
            NewLabel.Size = new Size(40, 15);
            NewLabel.TabIndex = 31;
            NewLabel.Text = "New";
            NewLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NewGamePictureBox
            // 
            NewGamePictureBox.Cursor = Cursors.Hand;
            NewGamePictureBox.Image = Properties.Resources.new_dark;
            NewGamePictureBox.Location = new Point(10, 0);
            NewGamePictureBox.Name = "NewGamePictureBox";
            NewGamePictureBox.Size = new Size(40, 40);
            NewGamePictureBox.TabIndex = 28;
            NewGamePictureBox.TabStop = false;
            NewGamePictureBox.Click += NewGamePictureBox_Click;
            // 
            // HintPictureBox
            // 
            HintPictureBox.Cursor = Cursors.Hand;
            HintPictureBox.Image = Properties.Resources.hint_dark;
            HintPictureBox.Location = new Point(60, 0);
            HintPictureBox.Name = "HintPictureBox";
            HintPictureBox.Size = new Size(40, 40);
            HintPictureBox.TabIndex = 29;
            HintPictureBox.TabStop = false;
            HintPictureBox.Click += HintPictureBox_Click;
            // 
            // SharePictureBox
            // 
            SharePictureBox.Cursor = Cursors.Hand;
            SharePictureBox.Image = Properties.Resources.share_dark;
            SharePictureBox.Location = new Point(110, 0);
            SharePictureBox.Name = "SharePictureBox";
            SharePictureBox.Size = new Size(40, 40);
            SharePictureBox.TabIndex = 30;
            SharePictureBox.TabStop = false;
            SharePictureBox.Click += SharePictureBox_Click;
            // 
            // SettingsPictureBox
            // 
            SettingsPictureBox.Cursor = Cursors.Hand;
            SettingsPictureBox.Image = Properties.Resources.gear_open_dark;
            SettingsPictureBox.Location = new Point(160, 0);
            SettingsPictureBox.Name = "SettingsPictureBox";
            SettingsPictureBox.Size = new Size(40, 40);
            SettingsPictureBox.TabIndex = 27;
            SettingsPictureBox.TabStop = false;
            SettingsPictureBox.Click += SettingsPictureBox_Click;
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
            RemainingMinesLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            RemainingMinesLabel.Location = new Point(60, 0);
            RemainingMinesLabel.Margin = new Padding(0);
            RemainingMinesLabel.Name = "RemainingMinesLabel";
            RemainingMinesLabel.Size = new Size(75, 40);
            RemainingMinesLabel.TabIndex = 4;
            RemainingMinesLabel.Text = "200";
            // 
            // StatusMineIconLabel
            // 
            StatusMineIconLabel.Image = Properties.Resources.bomb_dark;
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
            EfficiencyLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            EfficiencyLabel.Location = new Point(13, 90);
            EfficiencyLabel.Name = "EfficiencyLabel";
            EfficiencyLabel.Size = new Size(84, 21);
            EfficiencyLabel.TabIndex = 25;
            EfficiencyLabel.Text = "Efficiency:";
            // 
            // BBBVTotalLabel
            // 
            BBBVTotalLabel.AutoSize = true;
            BBBVTotalLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            BBBVTotalLabel.Location = new Point(13, 60);
            BBBVTotalLabel.Name = "BBBVTotalLabel";
            BBBVTotalLabel.Size = new Size(82, 21);
            BBBVTotalLabel.TabIndex = 24;
            BBBVTotalLabel.Text = "3BV Total:";
            // 
            // BBBVSLabel
            // 
            BBBVSLabel.AutoSize = true;
            BBBVSLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            BBBVSLabel.Location = new Point(13, 30);
            BBBVSLabel.Name = "BBBVSLabel";
            BBBVSLabel.Size = new Size(76, 21);
            BBBVSLabel.TabIndex = 23;
            BBBVSLabel.Text = "3BV/Sec:";
            // 
            // BBBVLabel
            // 
            BBBVLabel.AutoSize = true;
            BBBVLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            BBBVLabel.Location = new Point(13, 0);
            BBBVLabel.Name = "BBBVLabel";
            BBBVLabel.Size = new Size(43, 21);
            BBBVLabel.TabIndex = 22;
            BBBVLabel.Text = "3BV:";
            // 
            // StartPanel
            // 
            StartPanel.Controls.Add(StartButton);
            StartPanel.Location = new Point(0, 0);
            StartPanel.Name = "StartPanel";
            StartPanel.Size = new Size(300, 150);
            StartPanel.TabIndex = 0;
            StartPanel.Visible = false;
            // 
            // StartButton
            // 
            StartButton.FlatAppearance.BorderSize = 0;
            StartButton.FlatStyle = FlatStyle.Flat;
            StartButton.Location = new Point(95, 60);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(112, 34);
            StartButton.TabIndex = 0;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // EndGamePanel
            // 
            EndGamePanel.Controls.Add(LeaderBoardPanel);
            EndGamePanel.Controls.Add(ShowBoardButton);
            EndGamePanel.Controls.Add(FinalTimeLabel);
            EndGamePanel.Controls.Add(WinLoseLabel);
            EndGamePanel.Controls.Add(GameStatsPanel);
            EndGamePanel.Controls.Add(LeaderBoardTitleLabel);
            EndGamePanel.Controls.Add(NewGameButton);
            EndGamePanel.Location = new Point(130, 140);
            EndGamePanel.Name = "EndGamePanel";
            EndGamePanel.Size = new Size(450, 644);
            EndGamePanel.TabIndex = 0;
            EndGamePanel.Visible = false;
            // 
            // LeaderBoardPanel
            // 
            LeaderBoardPanel.Location = new Point(87, 395);
            LeaderBoardPanel.Name = "LeaderBoardPanel";
            LeaderBoardPanel.Size = new Size(300, 162);
            LeaderBoardPanel.TabIndex = 36;
            // 
            // ShowBoardButton
            // 
            ShowBoardButton.FlatAppearance.BorderSize = 0;
            ShowBoardButton.FlatStyle = FlatStyle.Flat;
            ShowBoardButton.Location = new Point(87, 585);
            ShowBoardButton.Name = "ShowBoardButton";
            ShowBoardButton.Size = new Size(123, 34);
            ShowBoardButton.TabIndex = 35;
            ShowBoardButton.Text = "Show Board";
            ShowBoardButton.UseVisualStyleBackColor = true;
            ShowBoardButton.Click += ShowBoardButton_Click;
            // 
            // FinalTimeLabel
            // 
            FinalTimeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FinalTimeLabel.BackColor = Color.Transparent;
            FinalTimeLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            FinalTimeLabel.Location = new Point(113, 71);
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
            WinLoseLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            WinLoseLabel.Location = new Point(134, 13);
            WinLoseLabel.Name = "WinLoseLabel";
            WinLoseLabel.Size = new Size(184, 48);
            WinLoseLabel.TabIndex = 4;
            WinLoseLabel.Text = "You Won!";
            // 
            // GameStatsPanel
            // 
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
            GameStatsPanel.Location = new Point(113, 121);
            GameStatsPanel.Name = "GameStatsPanel";
            GameStatsPanel.Size = new Size(241, 189);
            GameStatsPanel.TabIndex = 3;
            // 
            // MineCountValueLabel
            // 
            MineCountValueLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            MineCountValueLabel.Location = new Point(142, 144);
            MineCountValueLabel.Name = "MineCountValueLabel";
            MineCountValueLabel.Size = new Size(99, 28);
            MineCountValueLabel.TabIndex = 41;
            MineCountValueLabel.Text = "0";
            MineCountValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MineCountLabel
            // 
            MineCountLabel.AutoSize = true;
            MineCountLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            MineCountLabel.Location = new Point(13, 148);
            MineCountLabel.Name = "MineCountLabel";
            MineCountLabel.Size = new Size(99, 21);
            MineCountLabel.TabIndex = 40;
            MineCountLabel.Text = "Mine Count:";
            // 
            // BoardSizeValueLabel
            // 
            BoardSizeValueLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            BoardSizeValueLabel.Location = new Point(142, 114);
            BoardSizeValueLabel.Name = "BoardSizeValueLabel";
            BoardSizeValueLabel.Size = new Size(99, 28);
            BoardSizeValueLabel.TabIndex = 39;
            BoardSizeValueLabel.Text = "0 x 0";
            BoardSizeValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BoardSizeLabel
            // 
            BoardSizeLabel.AutoSize = true;
            BoardSizeLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            BoardSizeLabel.Location = new Point(13, 118);
            BoardSizeLabel.Name = "BoardSizeLabel";
            BoardSizeLabel.Size = new Size(91, 21);
            BoardSizeLabel.TabIndex = 38;
            BoardSizeLabel.Text = "Board Size:";
            // 
            // EfficiencyValueLabel
            // 
            EfficiencyValueLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            EfficiencyValueLabel.Location = new Point(142, 90);
            EfficiencyValueLabel.Name = "EfficiencyValueLabel";
            EfficiencyValueLabel.Size = new Size(99, 28);
            EfficiencyValueLabel.TabIndex = 29;
            EfficiencyValueLabel.Text = "0";
            EfficiencyValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BBBVTotalValueLabel
            // 
            BBBVTotalValueLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            BBBVTotalValueLabel.Location = new Point(142, 60);
            BBBVTotalValueLabel.Name = "BBBVTotalValueLabel";
            BBBVTotalValueLabel.Size = new Size(99, 28);
            BBBVTotalValueLabel.TabIndex = 28;
            BBBVTotalValueLabel.Text = "0";
            BBBVTotalValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BBBVSValueLabel
            // 
            BBBVSValueLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            BBBVSValueLabel.Location = new Point(142, 30);
            BBBVSValueLabel.Name = "BBBVSValueLabel";
            BBBVSValueLabel.Size = new Size(99, 28);
            BBBVSValueLabel.TabIndex = 27;
            BBBVSValueLabel.Text = "0";
            BBBVSValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BBBVValueLabel
            // 
            BBBVValueLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            BBBVValueLabel.Location = new Point(142, 0);
            BBBVValueLabel.Name = "BBBVValueLabel";
            BBBVValueLabel.Size = new Size(99, 28);
            BBBVValueLabel.TabIndex = 26;
            BBBVValueLabel.Text = "0";
            BBBVValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LeaderBoardTitleLabel
            // 
            LeaderBoardTitleLabel.AutoSize = true;
            LeaderBoardTitleLabel.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point);
            LeaderBoardTitleLabel.Location = new Point(113, 346);
            LeaderBoardTitleLabel.Name = "LeaderBoardTitleLabel";
            LeaderBoardTitleLabel.Size = new Size(258, 42);
            LeaderBoardTitleLabel.TabIndex = 2;
            LeaderBoardTitleLabel.Text = "Leader Board";
            // 
            // NewGameButton
            // 
            NewGameButton.FlatAppearance.BorderSize = 0;
            NewGameButton.FlatStyle = FlatStyle.Flat;
            NewGameButton.Location = new Point(255, 585);
            NewGameButton.Name = "NewGameButton";
            NewGameButton.Size = new Size(112, 34);
            NewGameButton.TabIndex = 0;
            NewGameButton.Text = "New Game";
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
            ((System.ComponentModel.ISupportInitialize)NewGamePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)HintPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)SharePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)SettingsPictureBox).EndInit();
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
        private System.Windows.Forms.Button StartButton;
        private Panel EndGamePanel;
        private System.Windows.Forms.Button NewGameButton;
        private Label LeaderBoardTitleLabel;
        private Label BBBVLabel;
        private Label BBBVSLabel;
        private Label BBBVTotalLabel;
        private Label EfficiencyLabel;
        private Panel GameStatsPanel;
        private Label WinLoseLabel;
        private RoundedPictureBox SettingsPictureBox;
        private RoundedPictureBox SharePictureBox;
        private RoundedPictureBox HintPictureBox;
        private RoundedPictureBox NewGamePictureBox;
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
    }
}
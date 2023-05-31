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
            WinLoseLabel = new Label();
            GameStatsPanel = new Panel();
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
            GameControlPanel.Controls.Add(NewGamePictureBox);
            GameControlPanel.Controls.Add(HintPictureBox);
            GameControlPanel.Controls.Add(SharePictureBox);
            GameControlPanel.Controls.Add(SettingsPictureBox);
            GameControlPanel.Location = new Point(0, 0);
            GameControlPanel.Name = "GameControlPanel";
            GameControlPanel.Size = new Size(200, 40);
            GameControlPanel.TabIndex = 0;
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
            Controls.Add(EndGamePanel);
            Controls.Add(StartPanel);
            MineFieldPanel.Location = new Point(0, 0);
            MineFieldPanel.Margin = new Padding(0);
            MineFieldPanel.Name = "MineFieldPanel";
            MineFieldPanel.Size = new Size(1235, 1035);
            MineFieldPanel.TabIndex = 0;
            // 
            // EfficiencyLabel
            // 
            EfficiencyLabel.AutoSize = true;
            EfficiencyLabel.Location = new Point(13, 90);
            EfficiencyLabel.Name = "EfficiencyLabel";
            EfficiencyLabel.Size = new Size(89, 25);
            EfficiencyLabel.TabIndex = 25;
            EfficiencyLabel.Text = "Efficiency:";
            // 
            // BBBVTotalLabel
            // 
            BBBVTotalLabel.AutoSize = true;
            BBBVTotalLabel.Location = new Point(13, 60);
            BBBVTotalLabel.Name = "BBBVTotalLabel";
            BBBVTotalLabel.Size = new Size(89, 25);
            BBBVTotalLabel.TabIndex = 24;
            BBBVTotalLabel.Text = "3BV Total:";
            // 
            // BBBVSLabel
            // 
            BBBVSLabel.AutoSize = true;
            BBBVSLabel.Location = new Point(13, 30);
            BBBVSLabel.Name = "BBBVSLabel";
            BBBVSLabel.Size = new Size(81, 25);
            BBBVSLabel.TabIndex = 23;
            BBBVSLabel.Text = "3BV/Sec:";
            // 
            // BBBVLabel
            // 
            BBBVLabel.AutoSize = true;
            BBBVLabel.Location = new Point(13, 0);
            BBBVLabel.Name = "BBBVLabel";
            BBBVLabel.Size = new Size(47, 25);
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
            EndGamePanel.Controls.Add(WinLoseLabel);
            EndGamePanel.Controls.Add(GameStatsPanel);
            EndGamePanel.Controls.Add(LeaderBoardTitleLabel);
            EndGamePanel.Controls.Add(NewGameButton);
            EndGamePanel.Location = new Point(130, 140);
            EndGamePanel.Name = "EndGamePanel";
            EndGamePanel.Size = new Size(450, 450);
            EndGamePanel.TabIndex = 0;
            EndGamePanel.Visible = false;
            // 
            // WinLoseLabel
            // 
            WinLoseLabel.AutoSize = true;
            WinLoseLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            WinLoseLabel.Location = new Point(156, 50);
            WinLoseLabel.Name = "WinLoseLabel";
            WinLoseLabel.Size = new Size(184, 48);
            WinLoseLabel.TabIndex = 4;
            WinLoseLabel.Text = "You Won!";
            // 
            // GameStatsPanel
            // 
            GameStatsPanel.Controls.Add(EfficiencyLabel);
            GameStatsPanel.Controls.Add(BBBVTotalLabel);
            GameStatsPanel.Controls.Add(BBBVSLabel);
            GameStatsPanel.Controls.Add(BBBVLabel);
            GameStatsPanel.Location = new Point(121, 164);
            GameStatsPanel.Name = "GameStatsPanel";
            GameStatsPanel.Size = new Size(300, 150);
            GameStatsPanel.TabIndex = 3;
            // 
            // LeaderBoardTitleLabel
            // 
            LeaderBoardTitleLabel.AutoSize = true;
            LeaderBoardTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            LeaderBoardTitleLabel.Location = new Point(156, 343);
            LeaderBoardTitleLabel.Name = "LeaderBoardTitleLabel";
            LeaderBoardTitleLabel.Size = new Size(241, 48);
            LeaderBoardTitleLabel.TabIndex = 2;
            LeaderBoardTitleLabel.Text = "Leader Board";
            // 
            // NewGameButton
            // 
            NewGameButton.FlatAppearance.BorderSize = 0;
            NewGameButton.FlatStyle = FlatStyle.Flat;
            NewGameButton.Location = new Point(214, 733);
            NewGameButton.Name = "NewGameButton";
            NewGameButton.Size = new Size(112, 34);
            NewGameButton.TabIndex = 0;
            NewGameButton.Text = "New Game";
            NewGameButton.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1465, 1035);
            ControlBox = false;
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
    }
}
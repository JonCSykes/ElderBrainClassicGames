using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MineSweeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            TimerLabel = new Label();
            MineFieldPanel = new Panel();
            StartPanel = new Panel();
            StartButton = new System.Windows.Forms.Button();
            StatusPanel = new Panel();
            DebugPanel = new Panel();
            DebugGroupButton5 = new DoubleClickButton();
            DebugGroupButton9 = new DoubleClickButton();
            DebugRevealedLabel = new Label();
            DebugGroupButton8 = new DoubleClickButton();
            DebugMinesFlaggedLabel = new Label();
            DebugGroupButton7 = new DoubleClickButton();
            DebugEventLabel = new Label();
            DebugGroupButton6 = new DoubleClickButton();
            DebugGroupButton1 = new DoubleClickButton();
            DebugGroupButton2 = new DoubleClickButton();
            DebugGroupButton4 = new DoubleClickButton();
            DebugGroupButton3 = new DoubleClickButton();
            UsernameLabel = new Label();
            ProfilePictureBox = new RoundedPictureBox();
            BoardDetailsLabel = new Label();
            GameStatusLabel = new Label();
            RemainingMinesLabel = new Label();
            StatusMineIconLabel = new Label();
            StartPanel.SuspendLayout();
            StatusPanel.SuspendLayout();
            DebugPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ProfilePictureBox).BeginInit();
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
            // MineFieldPanel
            // 
            MineFieldPanel.Dock = DockStyle.Fill;
            MineFieldPanel.Location = new Point(0, 0);
            MineFieldPanel.Margin = new Padding(0);
            MineFieldPanel.Name = "MineFieldPanel";
            MineFieldPanel.Size = new Size(1005, 1035);
            MineFieldPanel.TabIndex = 0;
            // 
            // StartPanel
            // 
            StartPanel.Controls.Add(StartButton);
            StartPanel.Location = new Point(344, 351);
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
            // StatusPanel
            // 
            StatusPanel.AccessibleDescription = resources.GetString("StatusPanel.AccessibleDescription");
            StatusPanel.Controls.Add(DebugPanel);
            StatusPanel.Controls.Add(UsernameLabel);
            StatusPanel.Controls.Add(ProfilePictureBox);
            StatusPanel.Controls.Add(BoardDetailsLabel);
            StatusPanel.Controls.Add(GameStatusLabel);
            StatusPanel.Controls.Add(RemainingMinesLabel);
            StatusPanel.Controls.Add(StatusMineIconLabel);
            StatusPanel.Controls.Add(TimerLabel);
            StatusPanel.Dock = DockStyle.Right;
            StatusPanel.Location = new Point(1005, 0);
            StatusPanel.Margin = new Padding(0);
            StatusPanel.Name = "StatusPanel";
            StatusPanel.Size = new Size(230, 1035);
            StatusPanel.TabIndex = 1;
            // 
            // DebugPanel
            // 
            DebugPanel.Controls.Add(DebugGroupButton5);
            DebugPanel.Controls.Add(DebugGroupButton9);
            DebugPanel.Controls.Add(DebugRevealedLabel);
            DebugPanel.Controls.Add(DebugGroupButton8);
            DebugPanel.Controls.Add(DebugMinesFlaggedLabel);
            DebugPanel.Controls.Add(DebugGroupButton7);
            DebugPanel.Controls.Add(DebugEventLabel);
            DebugPanel.Controls.Add(DebugGroupButton6);
            DebugPanel.Controls.Add(DebugGroupButton1);
            DebugPanel.Controls.Add(DebugGroupButton2);
            DebugPanel.Controls.Add(DebugGroupButton4);
            DebugPanel.Controls.Add(DebugGroupButton3);
            DebugPanel.Location = new Point(0, 475);
            DebugPanel.Name = "DebugPanel";
            DebugPanel.Size = new Size(224, 201);
            DebugPanel.TabIndex = 21;
            // 
            // DebugGroupButton5
            // 
            DebugGroupButton5.Enabled = false;
            DebugGroupButton5.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            DebugGroupButton5.Location = new Point(55, 115);
            DebugGroupButton5.Name = "DebugGroupButton5";
            DebugGroupButton5.Size = new Size(25, 25);
            DebugGroupButton5.TabIndex = 16;
            DebugGroupButton5.Text = "0";
            DebugGroupButton5.UseVisualStyleBackColor = true;
            // 
            // DebugGroupButton9
            // 
            DebugGroupButton9.Enabled = false;
            DebugGroupButton9.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            DebugGroupButton9.Location = new Point(86, 146);
            DebugGroupButton9.Name = "DebugGroupButton9";
            DebugGroupButton9.Size = new Size(25, 25);
            DebugGroupButton9.TabIndex = 20;
            DebugGroupButton9.Text = "0";
            DebugGroupButton9.UseVisualStyleBackColor = true;
            // 
            // DebugRevealedLabel
            // 
            DebugRevealedLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            DebugRevealedLabel.Location = new Point(21, 0);
            DebugRevealedLabel.Name = "DebugRevealedLabel";
            DebugRevealedLabel.Size = new Size(200, 26);
            DebugRevealedLabel.TabIndex = 9;
            DebugRevealedLabel.Text = "Revealed:";
            // 
            // DebugGroupButton8
            // 
            DebugGroupButton8.Enabled = false;
            DebugGroupButton8.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            DebugGroupButton8.Location = new Point(55, 146);
            DebugGroupButton8.Name = "DebugGroupButton8";
            DebugGroupButton8.Size = new Size(25, 25);
            DebugGroupButton8.TabIndex = 19;
            DebugGroupButton8.Text = "0";
            DebugGroupButton8.UseVisualStyleBackColor = true;
            // 
            // DebugMinesFlaggedLabel
            // 
            DebugMinesFlaggedLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            DebugMinesFlaggedLabel.Location = new Point(21, 23);
            DebugMinesFlaggedLabel.Name = "DebugMinesFlaggedLabel";
            DebugMinesFlaggedLabel.Size = new Size(197, 20);
            DebugMinesFlaggedLabel.TabIndex = 10;
            DebugMinesFlaggedLabel.Text = "Mines Flagged:";
            // 
            // DebugGroupButton7
            // 
            DebugGroupButton7.Enabled = false;
            DebugGroupButton7.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            DebugGroupButton7.Location = new Point(24, 146);
            DebugGroupButton7.Name = "DebugGroupButton7";
            DebugGroupButton7.Size = new Size(25, 25);
            DebugGroupButton7.TabIndex = 18;
            DebugGroupButton7.Text = "0";
            DebugGroupButton7.UseVisualStyleBackColor = true;
            // 
            // DebugEventLabel
            // 
            DebugEventLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            DebugEventLabel.Location = new Point(21, 46);
            DebugEventLabel.Name = "DebugEventLabel";
            DebugEventLabel.Size = new Size(197, 23);
            DebugEventLabel.TabIndex = 11;
            DebugEventLabel.Text = "Event:";
            // 
            // DebugGroupButton6
            // 
            DebugGroupButton6.Enabled = false;
            DebugGroupButton6.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            DebugGroupButton6.Location = new Point(86, 115);
            DebugGroupButton6.Name = "DebugGroupButton6";
            DebugGroupButton6.Size = new Size(25, 25);
            DebugGroupButton6.TabIndex = 17;
            DebugGroupButton6.Text = "0";
            DebugGroupButton6.UseVisualStyleBackColor = true;
            // 
            // DebugGroupButton1
            // 
            DebugGroupButton1.Enabled = false;
            DebugGroupButton1.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            DebugGroupButton1.Location = new Point(24, 84);
            DebugGroupButton1.Name = "DebugGroupButton1";
            DebugGroupButton1.Size = new Size(25, 25);
            DebugGroupButton1.TabIndex = 12;
            DebugGroupButton1.Text = "0";
            DebugGroupButton1.UseVisualStyleBackColor = true;
            // 
            // DebugGroupButton2
            // 
            DebugGroupButton2.Enabled = false;
            DebugGroupButton2.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            DebugGroupButton2.Location = new Point(55, 84);
            DebugGroupButton2.Name = "DebugGroupButton2";
            DebugGroupButton2.Size = new Size(25, 25);
            DebugGroupButton2.TabIndex = 13;
            DebugGroupButton2.Text = "0";
            DebugGroupButton2.UseVisualStyleBackColor = true;
            // 
            // DebugGroupButton4
            // 
            DebugGroupButton4.Enabled = false;
            DebugGroupButton4.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            DebugGroupButton4.Location = new Point(24, 115);
            DebugGroupButton4.Name = "DebugGroupButton4";
            DebugGroupButton4.Size = new Size(25, 25);
            DebugGroupButton4.TabIndex = 15;
            DebugGroupButton4.Text = "0";
            DebugGroupButton4.UseVisualStyleBackColor = true;
            // 
            // DebugGroupButton3
            // 
            DebugGroupButton3.Enabled = false;
            DebugGroupButton3.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            DebugGroupButton3.Location = new Point(86, 84);
            DebugGroupButton3.Name = "DebugGroupButton3";
            DebugGroupButton3.Size = new Size(25, 25);
            DebugGroupButton3.TabIndex = 14;
            DebugGroupButton3.Text = "0";
            DebugGroupButton3.UseVisualStyleBackColor = true;
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
            // BoardDetailsLabel
            // 
            BoardDetailsLabel.Dock = DockStyle.Bottom;
            BoardDetailsLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BoardDetailsLabel.Location = new Point(0, 997);
            BoardDetailsLabel.Name = "BoardDetailsLabel";
            BoardDetailsLabel.Size = new Size(230, 38);
            BoardDetailsLabel.TabIndex = 6;
            BoardDetailsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GameStatusLabel
            // 
            GameStatusLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            GameStatusLabel.Location = new Point(0, 351);
            GameStatusLabel.Margin = new Padding(0);
            GameStatusLabel.Name = "GameStatusLabel";
            GameStatusLabel.Padding = new Padding(5);
            GameStatusLabel.Size = new Size(230, 74);
            GameStatusLabel.TabIndex = 5;
            GameStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RemainingMinesLabel
            // 
            RemainingMinesLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            RemainingMinesLabel.Location = new Point(104, 262);
            RemainingMinesLabel.Margin = new Padding(0);
            RemainingMinesLabel.Name = "RemainingMinesLabel";
            RemainingMinesLabel.Size = new Size(126, 42);
            RemainingMinesLabel.TabIndex = 4;
            RemainingMinesLabel.Text = "0";
            RemainingMinesLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // StatusMineIconLabel
            // 
            StatusMineIconLabel.Image = Properties.Resources.mine_small;
            StatusMineIconLabel.Location = new Point(63, 267);
            StatusMineIconLabel.Name = "StatusMineIconLabel";
            StatusMineIconLabel.Size = new Size(40, 42);
            StatusMineIconLabel.TabIndex = 3;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1235, 1035);
            Controls.Add(StartPanel);
            Controls.Add(MineFieldPanel);
            Controls.Add(StatusPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Main";
            Text = "Mine Sweeper Pro";
            Load += Main_Load;
            Shown += Main_Shown;
            StartPanel.ResumeLayout(false);
            StatusPanel.ResumeLayout(false);
            DebugPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ProfilePictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label TimerLabel;
        private Panel MineFieldPanel;
        private Panel StatusPanel;
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
    }
}
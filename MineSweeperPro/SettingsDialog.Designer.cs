namespace MineSweeperPro
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SaveButton = new Button();
            CancelButton = new Button();
            DefaultWidthTextbox = new TextBox();
            DefaultWidthLabel = new Label();
            DefaultHeightLabel = new Label();
            DefaultHeightTextbox = new TextBox();
            DefaultMineCountLabel = new Label();
            DefaultMineCountTextbox = new TextBox();
            DefaultHintCountLabel = new Label();
            DefaultHintCountTextbox = new TextBox();
            ThemeComboBox = new ComboBox();
            label1 = new Label();
            DebugCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.White;
            SaveButton.FlatAppearance.BorderSize = 0;
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.Location = new Point(358, 288);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(112, 34);
            SaveButton.TabIndex = 0;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.BackColor = Color.White;
            CancelButton.FlatAppearance.BorderSize = 0;
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.Location = new Point(476, 288);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(112, 34);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = false;
            CancelButton.Click += CancelButton_Click;
            // 
            // DefaultWidthTextbox
            // 
            DefaultWidthTextbox.Location = new Point(188, 39);
            DefaultWidthTextbox.Name = "DefaultWidthTextbox";
            DefaultWidthTextbox.Size = new Size(59, 31);
            DefaultWidthTextbox.TabIndex = 10;
            DefaultWidthTextbox.KeyPress += DefaultWidthTextbox_KeyPress;
            // 
            // DefaultWidthLabel
            // 
            DefaultWidthLabel.AutoSize = true;
            DefaultWidthLabel.Location = new Point(12, 39);
            DefaultWidthLabel.Name = "DefaultWidthLabel";
            DefaultWidthLabel.Size = new Size(126, 25);
            DefaultWidthLabel.TabIndex = 11;
            DefaultWidthLabel.Text = "Default Width:";
            // 
            // DefaultHeightLabel
            // 
            DefaultHeightLabel.AutoSize = true;
            DefaultHeightLabel.Location = new Point(12, 83);
            DefaultHeightLabel.Name = "DefaultHeightLabel";
            DefaultHeightLabel.Size = new Size(131, 25);
            DefaultHeightLabel.TabIndex = 13;
            DefaultHeightLabel.Text = "Default Height:";
            // 
            // DefaultHeightTextbox
            // 
            DefaultHeightTextbox.Location = new Point(188, 83);
            DefaultHeightTextbox.Name = "DefaultHeightTextbox";
            DefaultHeightTextbox.Size = new Size(59, 31);
            DefaultHeightTextbox.TabIndex = 12;
            DefaultHeightTextbox.KeyPress += DefaultHeightTextbox_KeyPress;
            // 
            // DefaultMineCountLabel
            // 
            DefaultMineCountLabel.AutoSize = true;
            DefaultMineCountLabel.Location = new Point(12, 129);
            DefaultMineCountLabel.Name = "DefaultMineCountLabel";
            DefaultMineCountLabel.Size = new Size(170, 25);
            DefaultMineCountLabel.TabIndex = 15;
            DefaultMineCountLabel.Text = "Default Mine Count:";
            // 
            // DefaultMineCountTextbox
            // 
            DefaultMineCountTextbox.Location = new Point(188, 129);
            DefaultMineCountTextbox.Name = "DefaultMineCountTextbox";
            DefaultMineCountTextbox.Size = new Size(59, 31);
            DefaultMineCountTextbox.TabIndex = 14;
            DefaultMineCountTextbox.KeyPress += DefaultMineCountTextbox_KeyPress;
            // 
            // DefaultHintCountLabel
            // 
            DefaultHintCountLabel.AutoSize = true;
            DefaultHintCountLabel.Location = new Point(12, 178);
            DefaultHintCountLabel.Name = "DefaultHintCountLabel";
            DefaultHintCountLabel.Size = new Size(164, 25);
            DefaultHintCountLabel.TabIndex = 17;
            DefaultHintCountLabel.Text = "Default Hint Count:";
            // 
            // DefaultHintCountTextbox
            // 
            DefaultHintCountTextbox.Location = new Point(188, 175);
            DefaultHintCountTextbox.Name = "DefaultHintCountTextbox";
            DefaultHintCountTextbox.Size = new Size(59, 31);
            DefaultHintCountTextbox.TabIndex = 16;
            DefaultHintCountTextbox.KeyPress += DefaultHintCountTextbox_KeyPress;
            // 
            // ThemeComboBox
            // 
            ThemeComboBox.FormattingEnabled = true;
            ThemeComboBox.Location = new Point(397, 39);
            ThemeComboBox.Name = "ThemeComboBox";
            ThemeComboBox.Size = new Size(182, 33);
            ThemeComboBox.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(322, 39);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 20;
            label1.Text = "Theme:";
            // 
            // DebugCheckBox
            // 
            DebugCheckBox.AutoSize = true;
            DebugCheckBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            DebugCheckBox.Location = new Point(12, 288);
            DebugCheckBox.Name = "DebugCheckBox";
            DebugCheckBox.Size = new Size(125, 25);
            DebugCheckBox.TabIndex = 21;
            DebugCheckBox.Text = "Debug Mode";
            DebugCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            AcceptButton = SaveButton;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CausesValidation = false;
            ClientSize = new Size(600, 334);
            Controls.Add(DebugCheckBox);
            Controls.Add(label1);
            Controls.Add(ThemeComboBox);
            Controls.Add(DefaultHintCountLabel);
            Controls.Add(DefaultHintCountTextbox);
            Controls.Add(DefaultMineCountLabel);
            Controls.Add(DefaultMineCountTextbox);
            Controls.Add(DefaultHeightLabel);
            Controls.Add(DefaultHeightTextbox);
            Controls.Add(DefaultWidthLabel);
            Controls.Add(DefaultWidthTextbox);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Mine Sweeper Pro Settings";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveButton;
        private Button CancelButton;
        private TextBox DefaultWidthTextbox;
        private Label DefaultWidthLabel;
        private Label DefaultHeightLabel;
        private TextBox DefaultHeightTextbox;
        private Label DefaultMineCountLabel;
        private TextBox DefaultMineCountTextbox;
        private Label DefaultHintCountLabel;
        private TextBox DefaultHintCountTextbox;
        private ComboBox ThemeComboBox;
        private Label label1;
        private CheckBox DebugCheckBox;
    }
}
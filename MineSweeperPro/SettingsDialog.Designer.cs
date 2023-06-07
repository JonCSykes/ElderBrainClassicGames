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
            ThemeComboBox = new ComboBox();
            label1 = new Label();
            EnableSoundCheckBox = new CheckBox();
            ChordControlLabel = new Label();
            DefaultChordControlComboBox = new ComboBox();
            ShowGameOptionsCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.White;
            SaveButton.FlatAppearance.BorderSize = 0;
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.Location = new Point(219, 222);
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
            CancelButton.Location = new Point(347, 222);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(112, 34);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = false;
            CancelButton.Click += CancelButton_Click;
            // 
            // ThemeComboBox
            // 
            ThemeComboBox.FlatStyle = FlatStyle.Flat;
            ThemeComboBox.FormattingEnabled = true;
            ThemeComboBox.Location = new Point(30, 61);
            ThemeComboBox.Name = "ThemeComboBox";
            ThemeComboBox.Size = new Size(182, 33);
            ThemeComboBox.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 33);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 20;
            label1.Text = "Theme:";
            // 
            // EnableSoundCheckBox
            // 
            EnableSoundCheckBox.AutoSize = true;
            EnableSoundCheckBox.Checked = true;
            EnableSoundCheckBox.CheckState = CheckState.Checked;
            EnableSoundCheckBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            EnableSoundCheckBox.Location = new Point(263, 150);
            EnableSoundCheckBox.Name = "EnableSoundCheckBox";
            EnableSoundCheckBox.Size = new Size(131, 25);
            EnableSoundCheckBox.TabIndex = 21;
            EnableSoundCheckBox.Text = "Enable Sound";
            EnableSoundCheckBox.UseVisualStyleBackColor = true;
            // 
            // ChordControlLabel
            // 
            ChordControlLabel.Location = new Point(30, 113);
            ChordControlLabel.Margin = new Padding(0);
            ChordControlLabel.Name = "ChordControlLabel";
            ChordControlLabel.Size = new Size(207, 29);
            ChordControlLabel.TabIndex = 23;
            ChordControlLabel.Text = "Default Chord Control:";
            ChordControlLabel.TextAlign = ContentAlignment.MiddleLeft;
            ChordControlLabel.Click += ChordControlLabel_Click;
            // 
            // DefaultChordControlComboBox
            // 
            DefaultChordControlComboBox.FlatStyle = FlatStyle.Flat;
            DefaultChordControlComboBox.FormattingEnabled = true;
            DefaultChordControlComboBox.Location = new Point(30, 145);
            DefaultChordControlComboBox.Name = "DefaultChordControlComboBox";
            DefaultChordControlComboBox.Size = new Size(182, 33);
            DefaultChordControlComboBox.TabIndex = 22;
            // 
            // ShowGameOptionsCheckBox
            // 
            ShowGameOptionsCheckBox.AutoSize = true;
            ShowGameOptionsCheckBox.Enabled = false;
            ShowGameOptionsCheckBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            ShowGameOptionsCheckBox.Location = new Point(263, 69);
            ShowGameOptionsCheckBox.Name = "ShowGameOptionsCheckBox";
            ShowGameOptionsCheckBox.Size = new Size(178, 25);
            ShowGameOptionsCheckBox.TabIndex = 24;
            ShowGameOptionsCheckBox.Text = "Show Game Options";
            ShowGameOptionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            AcceptButton = SaveButton;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CausesValidation = false;
            ClientSize = new Size(481, 277);
            Controls.Add(ShowGameOptionsCheckBox);
            Controls.Add(ChordControlLabel);
            Controls.Add(DefaultChordControlComboBox);
            Controls.Add(EnableSoundCheckBox);
            Controls.Add(label1);
            Controls.Add(ThemeComboBox);
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
        private ComboBox ThemeComboBox;
        private Label label1;
        private CheckBox EnableSoundCheckBox;
        private Label ChordControlLabel;
        private ComboBox DefaultChordControlComboBox;
        private CheckBox ShowGameOptionsCheckBox;
    }
}
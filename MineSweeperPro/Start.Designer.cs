namespace MineSweeperPro
{
    partial class Start
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
            StartButton = new Button();
            svgImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)svgImage).BeginInit();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.Location = new Point(93, 132);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(112, 34);
            StartButton.TabIndex = 0;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += button1_Click;
            // 
            // svgImage
            // 
            svgImage.Location = new Point(71, 39);
            svgImage.Name = "svgImage";
            svgImage.Size = new Size(150, 75);
            svgImage.TabIndex = 1;
            svgImage.TabStop = false;
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(svgImage);
            Controls.Add(StartButton);
            Name = "Start";
            Text = "Start";
            ((System.ComponentModel.ISupportInitialize)svgImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button StartButton;
        private PictureBox svgImage;
    }
}
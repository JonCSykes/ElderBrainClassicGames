using MineSweeper.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;

namespace MineSweeper
{
    public partial class SettingsDialog : Form
    {
        private const int CS_DROPSHADOW = 0x20000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_NCCALCSIZE = 0x0083;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32.dll")]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        public delegate void SaveSettingsDelegate();
        public delegate void CreateNewGameDelegate();

        public event SaveSettingsDelegate SaveSettingsEvent;
        public event CreateNewGameDelegate CreateNewGameEvent;

        Theme ConfiguredTheme;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    IntPtr hdc = GetDC(m.HWnd);
                    using (Graphics g = Graphics.FromHdc(hdc))
                    {
                        Rectangle bounds = new Rectangle(0, 0, Width, Height);
                        ControlPaint.DrawBorder(g, bounds, Color.Black, ButtonBorderStyle.Solid);
                    }
                    ReleaseDC(m.HWnd, hdc);
                    break;

                case WM_NCCALCSIZE:
                    int style = GetWindowLong(Handle, -16);
                    if ((style & 0x00020000) != 0) // WS_SIZEBOX
                    {
                        style &= ~0x00020000; // Remove WS_SIZEBOX
                        SetWindowLong(Handle, -16, style);
                    }
                    base.WndProc(ref m);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        public SettingsDialog()
        {
            InitializeComponent();

            DefaultWidthTextbox.Text = Settings.Default.MineFieldWidth.ToString();
            DefaultHeightTextbox.Text = Settings.Default.MineFieldHeight.ToString();
            DefaultMineCountTextbox.Text = Settings.Default.MineCount.ToString();
            DefaultHintCountTextbox.Text = Settings.Default.HintCount.ToString();

            ThemeComboBox.DataSource = Theme.GetThemeNames();
            ThemeComboBox.SelectedItem = Settings.Default.Theme;

            DebugCheckBox.Checked = Settings.Default.Debug;

            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));

            ApplyTheme();
        }
        public void ApplyTheme()
        {
            ConfiguredTheme = new Theme();
            ConfiguredTheme.LoadTheme(Settings.Default.Theme);

            this.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.TextColor);
            this.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineFieldBackColor);

            int cornerRadius = 10;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(SaveButton.ClientRectangle.Left, SaveButton.ClientRectangle.Top, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(SaveButton.ClientRectangle.Right - cornerRadius, SaveButton.ClientRectangle.Top, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(SaveButton.ClientRectangle.Right - cornerRadius, SaveButton.ClientRectangle.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(SaveButton.ClientRectangle.Left, SaveButton.ClientRectangle.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();

            GraphicsPath cancelPath = new GraphicsPath();
            cancelPath.AddArc(CancelButton.ClientRectangle.Left, CancelButton.ClientRectangle.Top, cornerRadius, cornerRadius, 180, 90);
            cancelPath.AddArc(CancelButton.ClientRectangle.Right - cornerRadius, CancelButton.ClientRectangle.Top, cornerRadius, cornerRadius, 270, 90);
            cancelPath.AddArc(CancelButton.ClientRectangle.Right - cornerRadius, CancelButton.ClientRectangle.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            cancelPath.AddArc(CancelButton.ClientRectangle.Left, CancelButton.ClientRectangle.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            cancelPath.CloseFigure();

            SaveButton.Region = new Region(path);
            SaveButton.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellBackColor);
            SaveButton.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.TextColor);

            CancelButton.Region = new Region(path);
            CancelButton.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellBackColor);
            CancelButton.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.TextColor);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int defaultWidth = 0;
            int defaultHeight = 0;
            int defaultMineCount = 0;
            int defaultHintCount = 0;

            if (!int.TryParse(DefaultWidthTextbox.Text, out defaultWidth) || !int.TryParse(DefaultHeightTextbox.Text, out defaultHeight) || !int.TryParse(DefaultMineCountTextbox.Text, out defaultMineCount) || !int.TryParse(DefaultHintCountTextbox.Text, out defaultHintCount))
            {
                MessageBox.Show("Invalid input. Please enter a valid integers in provided fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (defaultWidth > 7 && defaultHeight > 7)
            {
                if (defaultWidth * defaultHeight >= 64 && defaultWidth * defaultHeight <= 1000)
                {
                    Settings.Default.MineFieldWidth = defaultWidth;
                    Settings.Default.MineFieldHeight = defaultHeight;
                }
                else
                {
                    MessageBox.Show("Your width and height must calculate to at least 64 blocks total and no greater that 500 blocks.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Your width and height must be 8 cells.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (defaultMineCount > 0)
            {
                if (defaultMineCount < defaultWidth * defaultHeight)
                {
                    Settings.Default.MineCount = defaultMineCount;
                }
                else
                {
                    MessageBox.Show("You must have less lines the total number of blocks in your mine field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Your mine count must be greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Settings.Default.HintCount = defaultHintCount;
            Settings.Default.Theme = ThemeComboBox.SelectedValue?.ToString();
            Settings.Default.Debug = DebugCheckBox.Checked;
            Settings.Default.Save();


            CreateNewGameEvent?.Invoke();

            SaveSettingsEvent?.Invoke();

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DefaultWidthTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press event
                e.Handled = true;
            }
        }

        private void DefaultHeightTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press event
                e.Handled = true;
            }
        }

        private void DefaultMineCountTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press event
                e.Handled = true;
            }
        }

        private void DefaultHintCountTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press event
                e.Handled = true;
            }
        }
    }
}

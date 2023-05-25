using MineSweeperPro.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperPro
{
    public class ThemedForm : Form
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

        public ThemedForm()
        {

            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
        }

        private List<Button> FindButtonControls(Control control)
        {
            List<Button> buttons = new List<Button>();

            foreach (Control childControl in control.Controls)
            {
                if (childControl is Button button)
                {
                    buttons.Add(button);
                }
                else if (childControl.HasChildren)
                {
                    buttons.AddRange(FindButtonControls(childControl));
                }
            }

            return buttons;
        }

        public void ApplyTheme(Control control)
        {
            ConfiguredTheme = new Theme();
            ConfiguredTheme.LoadTheme(Settings.Default.Theme);

            this.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.TextColor);
            this.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineFieldBackColor);
            int cornerRadius = 10;

            var buttons = FindButtonControls(control);

            foreach (Button button in buttons)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddArc(button.ClientRectangle.Left, button.ClientRectangle.Top, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(button.ClientRectangle.Right - cornerRadius, button.ClientRectangle.Top, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(button.ClientRectangle.Right - cornerRadius, button.ClientRectangle.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(button.ClientRectangle.Left, button.ClientRectangle.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();

                button.Region = new Region(path);
                button.BackColor = ColorTranslator.FromHtml(ConfiguredTheme.MineCellBackColor);
                button.ForeColor = ColorTranslator.FromHtml(ConfiguredTheme.TextColor);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0; 
            }

            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, 15, 15));

        }
    }
}

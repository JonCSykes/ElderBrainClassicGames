using MineSweeperPro.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MineSweeperPro
{
    public class ThemedForm : Form
    {
        #region P/Invoke

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // ThemedForm
            // 
            ClientSize = new Size(278, 244);
            Name = "ThemedForm";
            ResumeLayout(false);
        }

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        private const int WM_NCHITTEST = 0x0084;
        private const int HTLEFT = 0x0A;
        private const int HTRIGHT = 0x0B;
        private const int HTTOP = 0x0C;
        private const int HTTOPLEFT = 0x0D;
        private const int HTTOPRIGHT = 0x0E;
        private const int HTBOTTOM = 0x0F;
        private const int HTBOTTOMLEFT = 0x10;
        private const int HTBOTTOMRIGHT = 0x11;

        private const int CAPTION_HEIGHT = 40;
        private const int WINDOW_RESIZE_THICKNESS = 2;
        private const int CONTAINER_BORDER_THICKNESS = 10;

        private Panel ContainerPanel;
        private Panel ToolbarPanel;
        private Panel ClientPanel;
        private Panel ButtonPanel;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.Button MaximizeButton;
        private System.Windows.Forms.Button CloseButton;
        private Label TitleLabel;

        Theme SelectedTheme;

        public string Title { set { TitleLabel.Text = value; } }
        public ThemedForm()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            InitializeCustomWindow();
            ApplyTheme();
        }


        private void InitializeCustomWindow()
        {
            ContainerPanel = new Panel();
            ToolbarPanel = new Panel();
            ClientPanel = new Panel();

            MinimumSize = new Size(1274, 1024);
            ToolbarPanel.MouseDown += ToolbarOnMouseDown;

            TitleLabel = new Label()
            {
                Font = new Font(Font.FontFamily, 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Size = new Size(250, 30),
                Location = new Point(CONTAINER_BORDER_THICKNESS, (CAPTION_HEIGHT - 30) / 2)
            };

            TitleLabel.MouseDown += ToolbarOnMouseDown;

            MinimizeButton = CreateCaptionButton("");
            MaximizeButton = CreateCaptionButton("");
            CloseButton = CreateCaptionButton("");

            MinimizeButton.Click += (sender, e) => WindowState = FormWindowState.Minimized;
            MaximizeButton.Click += (sender, e) => ToggleMaximize();
            CloseButton.Click += (sender, e) => Close();

            ToolbarPanel.Controls.Add(TitleLabel);
            ToolbarPanel.Controls.Add(MinimizeButton);
            ToolbarPanel.Controls.Add(MaximizeButton);
            ToolbarPanel.Controls.Add(CloseButton);

            Controls.Add(ToolbarPanel);
            ContainerPanel.Controls.Add(ClientPanel);
            Controls.Add(ContainerPanel);

            ResizeForm();
        }

        private void ToolbarOnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)

            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCHITTEST, 0, 0);

                if (Cursor == Cursors.Default)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 0xA1, 0x2, 0);
                }
            }
        }

        public void AddControl(Control control)
        {
            ClientPanel.Controls.Add(control);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);

                if (pos.X <= WINDOW_RESIZE_THICKNESS)

                {
                    if (pos.Y <= WINDOW_RESIZE_THICKNESS)
                        m.Result = (IntPtr)HTTOPLEFT;
                    else if (pos.Y >= ClientSize.Height - WINDOW_RESIZE_THICKNESS)
                        m.Result = (IntPtr)HTBOTTOMLEFT;
                    else
                        m.Result = (IntPtr)HTLEFT;
                }
                else if (pos.X >= ClientSize.Width - WINDOW_RESIZE_THICKNESS)
                {
                    if (pos.Y <= WINDOW_RESIZE_THICKNESS)
                        m.Result = (IntPtr)HTTOPRIGHT;
                    else if (pos.Y >= ClientSize.Height - WINDOW_RESIZE_THICKNESS)
                        m.Result = (IntPtr)HTBOTTOMRIGHT;
                    else
                        m.Result = (IntPtr)HTRIGHT;
                }
                else if (pos.Y <= WINDOW_RESIZE_THICKNESS)
                {
                    m.Result = (IntPtr)HTTOP;
                }
                else if (pos.Y >= ClientSize.Height - WINDOW_RESIZE_THICKNESS)
                {
                    m.Result = (IntPtr)HTBOTTOM;
                }
            }

        }

        private void ToggleMaximize()
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                MaximizeButton.Image = SelectedTheme.MaximizeOnImage;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                MaximizeButton.Image = SelectedTheme.MaximizeOffImage;
            }
        }

        private System.Windows.Forms.Button CreateCaptionButton(string text)
        {
            return new System.Windows.Forms.Button()
            {
                Text = text,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Width = CAPTION_HEIGHT,
                Height = CAPTION_HEIGHT,
                Dock = DockStyle.Right
            };
        }

        public void ApplyTheme()
        {
            SelectedTheme = new Theme(Settings.Default.Theme);

            ForeColor = SelectedTheme.TextColor;
            BackColor = ColorTranslator.FromHtml("#3c3c3c");

            TitleLabel.ForeColor = SelectedTheme.TextColor;
            ToolbarPanel.BackColor = SelectedTheme.BackColor;
            ContainerPanel.BackColor = SelectedTheme.BackColor;
            ClientPanel.BackColor = SelectedTheme.MineFieldBackColor;

            MinimizeButton.Image = SelectedTheme.MinimizeImage;

            if (WindowState == FormWindowState.Maximized)
            {
                MaximizeButton.Image = SelectedTheme.MaximizeOnImage;
            }
            else
            {
                MaximizeButton.Image = SelectedTheme.MaximizeOffImage;
            }

            CloseButton.Image = SelectedTheme.CloseImage;

            PerformLayout();
        }

        protected virtual void ResizeForm()
        {
            SuspendLayout();

            ContainerPanel.Size = new Size(Size.Width - (WINDOW_RESIZE_THICKNESS * 2), Size.Height - CAPTION_HEIGHT - (WINDOW_RESIZE_THICKNESS * 2));
            ContainerPanel.Location = new Point(WINDOW_RESIZE_THICKNESS, CAPTION_HEIGHT + WINDOW_RESIZE_THICKNESS);

            ClientPanel.Size = new Size(Size.Width - (CONTAINER_BORDER_THICKNESS * 2) - (WINDOW_RESIZE_THICKNESS * 2), Size.Height - CAPTION_HEIGHT - (CONTAINER_BORDER_THICKNESS * 2) - (WINDOW_RESIZE_THICKNESS * 2));
            ClientPanel.Location = new Point(CONTAINER_BORDER_THICKNESS, CONTAINER_BORDER_THICKNESS);

            ToolbarPanel.Size = new Size(Size.Width - (WINDOW_RESIZE_THICKNESS * 2), CAPTION_HEIGHT);
            ToolbarPanel.Location = new Point(WINDOW_RESIZE_THICKNESS, WINDOW_RESIZE_THICKNESS);

            CenterPanels(ToolbarPanel, TitleLabel, false, true);

            ResumeLayout();
        }

        private void CenterPanels(Control parentPanel, Control childPanel, bool includeX, bool includeY)
        {
            if (parentPanel == null || childPanel == null) { return; }

            int centeredX = childPanel.Location.X;

            if (includeX)
                centeredX = (parentPanel.ClientSize.Width - childPanel.ClientSize.Width) / 2;

            int centeredY = childPanel.Location.Y;

            if (includeY)
                centeredY = (parentPanel.ClientSize.Height - childPanel.ClientSize.Height) / 2;

            childPanel.Location = new Point(centeredX, centeredY);
        }

        protected override void OnResize(EventArgs e)
        {
            ResizeForm();
        }
    }
}

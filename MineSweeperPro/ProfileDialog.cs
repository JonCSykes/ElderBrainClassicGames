using MineSweeperPro.Properties;
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
using System.Reflection;

namespace MineSweeperPro
{
    public partial class ProfileDialog : Form
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


        public delegate void LoadProfileDelegate();

        public event LoadProfileDelegate LoadProfileEvent;

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

        Player CurrentPlayer;

        public ProfileDialog(Player currentPlayer)
        {
            InitializeComponent();

            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));

            int profilePictureSize = 150;

            ProfilePictureBox1.Image = ResizeProfileImage(Properties.Resources.profile_boy, profilePictureSize, profilePictureSize);
            ProfilePictureBox2.Image = ResizeProfileImage(Properties.Resources.profile_girl, profilePictureSize, profilePictureSize);
            ProfilePictureBox3.Image = ResizeProfileImage(Properties.Resources.profile_monkey, profilePictureSize, profilePictureSize);
            ProfilePictureBox4.Image = ResizeProfileImage(Properties.Resources.profile_dragon, profilePictureSize, profilePictureSize);
            ProfilePictureBox5.Image = ResizeProfileImage(Properties.Resources.profile_blue_dragon, profilePictureSize, profilePictureSize);
            ProfilePictureBox6.Image = ResizeProfileImage(Properties.Resources.profile_dog, profilePictureSize, profilePictureSize);

            ApplyTheme();

            
            CurrentPlayer = currentPlayer;

            if (CurrentPlayer.ProfileExists())
            {
                CurrentPlayer.GetSettings();

                UsernameTextBox.Text = CurrentPlayer.Username;

                SelectCurrentPortrait(CurrentPlayer.PortraitName);
            }
            
        }

        private System.Drawing.Image ResizeProfileImage(System.Drawing.Image profileImage, int width, int height)
        {
            System.Drawing.Image resizedImage = profileImage.GetThumbnailImage(width, height, null, IntPtr.Zero);

            profileImage.Dispose();

            return resizedImage;
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

        private void SelectCurrentPortrait(string portraitName)
        {
            if (portraitName == GetImageName(Properties.Resources.profile_boy))
            {
                TogglePictureBox(ProfilePictureBox1);
            } 
            else if (portraitName == GetImageName(Properties.Resources.profile_girl))
            {
                TogglePictureBox(ProfilePictureBox2);
            } 
            else if (portraitName == GetImageName(Properties.Resources.profile_monkey))
            {
                TogglePictureBox(ProfilePictureBox3);
            } 
            else if (portraitName == GetImageName(Properties.Resources.profile_dragon))
            {
                TogglePictureBox(ProfilePictureBox4);
            } 
            else if (portraitName == GetImageName(Properties.Resources.profile_blue_dragon))
            {
                TogglePictureBox(ProfilePictureBox5);
            } 
            else if (portraitName == GetImageName(Properties.Resources.profile_dog))
            {
                TogglePictureBox(ProfilePictureBox6);
            }
        }

        private void TogglePictureBox(BorderPictureBox pictureBox)
        {
            foreach (var control in Controls)
            {
                if (control is BorderPictureBox customPictureBox)
                {
                    customPictureBox.BorderColor = Color.Black;
                    customPictureBox.BorderThickness = 2;
                }
            }

            pictureBox.BorderColor = Color.Blue;
            pictureBox.BorderThickness = 5;
        }

        public static string GetImageName(Bitmap image)
        {
            Type resourcesType = typeof(Properties.Resources);

            PropertyInfo[] properties = resourcesType.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(null) is Bitmap bitmap && AreBitmapsEqual(bitmap,image))
                {
                    return property.Name; 
                }
            }
            return null; 
        }

        private static bool AreBitmapsEqual(Bitmap bitmap1, Bitmap bitmap2)
        {
            if (bitmap1.Width != bitmap2.Width || bitmap1.Height != bitmap2.Height)
                return false;

            for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    Color pixel1 = bitmap1.GetPixel(x, y);
                    Color pixel2 = bitmap2.GetPixel(x, y);

                    if (pixel1 != pixel2)
                        return false;
                }
            }

            return true;
        }

        private System.Drawing.Image ResizePortrait(System.Drawing.Image image)
        {
            int targetSize = 150;

            System.Drawing.Image resizedImage = image.GetThumbnailImage(targetSize, targetSize, null, IntPtr.Zero);

            image.Dispose();

            return resizedImage;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            CurrentPlayer.Username = UsernameTextBox.Text;
            CurrentPlayer.UpdateSettings();

            LoadProfileEvent?.Invoke();

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProfilePictureBox1_Click(object sender, EventArgs e)
        {
            BorderPictureBox pictureBox = (BorderPictureBox)sender;
            TogglePictureBox(pictureBox);

            CurrentPlayer.Portrait = ResizePortrait(Properties.Resources.profile_boy);
            CurrentPlayer.PortraitName = GetImageName(Properties.Resources.profile_boy);
        }

        private void ProfilePictureBox2_Click(object sender, EventArgs e)
        {
            BorderPictureBox pictureBox = (BorderPictureBox)sender;
            TogglePictureBox(pictureBox);

            CurrentPlayer.Portrait = ResizePortrait(Properties.Resources.profile_girl);
            CurrentPlayer.PortraitName = GetImageName(Properties.Resources.profile_girl);
        }

        private void ProfilePictureBox3_Click(object sender, EventArgs e)
        {
            BorderPictureBox pictureBox = (BorderPictureBox)sender;
            TogglePictureBox(pictureBox);

            CurrentPlayer.Portrait = ResizePortrait(Properties.Resources.profile_monkey);
            CurrentPlayer.PortraitName = GetImageName(Properties.Resources.profile_monkey);
        }

        private void ProfilePictureBox4_Click(object sender, EventArgs e)
        {
            BorderPictureBox pictureBox = (BorderPictureBox)sender;
            TogglePictureBox(pictureBox);

            CurrentPlayer.Portrait = ResizePortrait(Properties.Resources.profile_dragon);
            CurrentPlayer.PortraitName = GetImageName(Properties.Resources.profile_dragon);
        }

        private void ProfilePictureBox5_Click(object sender, EventArgs e)
        {
            BorderPictureBox pictureBox = (BorderPictureBox)sender;
            TogglePictureBox(pictureBox);

            CurrentPlayer.Portrait = ResizePortrait(Properties.Resources.profile_blue_dragon);
            CurrentPlayer.PortraitName = GetImageName(Properties.Resources.profile_blue_dragon);
        }

        private void ProfilePictureBox6_Click(object sender, EventArgs e)
        {
            BorderPictureBox pictureBox = (BorderPictureBox)sender;
            TogglePictureBox(pictureBox);

            CurrentPlayer.Portrait = ResizePortrait(Properties.Resources.profile_dog);
            CurrentPlayer.PortraitName = GetImageName(Properties.Resources.profile_dog);
        }
    }
}

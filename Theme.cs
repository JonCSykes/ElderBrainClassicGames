using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public class Theme
    {
        const string THEME_PATH = "Themes";
        const string IMAGE_PATH = "Images";
        const string THEME_FILE_NAME = "theme.json";

        public string TextColor { get; set; }
        public string MineFieldBackColor { get; set; }
        
        public string StatusPanelBackColor { get; set; }
        public string StatusPanelTextColor { get; set; }

        public string MenuBackColor { get; set; }
        public string MenuTextColor { get; set; }
        public string MenuHoverBackgroundColor { get; set; }
        public string MenuHoverTextColor { get; set; }

        public string MineCellBackColor { get; set; }
        public string MineCellActivatedBackColor { get; set; }
        public string MineCellFlaggedBackColor { get; set; }
        public string MineCellExplodedBackColor { get; set; }

        public string MineCellNumberColor0 { get; set; }
        public string MineCellNumberColor1 { get; set; }
        public string MineCellNumberColor2 { get; set; }
        public string MineCellNumberColor3 { get; set; }
        public string MineCellNumberColor4 { get; set; }
        public string MineCellNumberColor5 { get; set; }
        public string MineCellNumberColor6 { get; set; }
        public string MineCellNumberColor7 { get; set; }
        public string MineCellNumberColor8 { get; set; }

        public string MineImage { get; set; }
        public string FlagImage { get; set; }


        public static List<string> GetThemeNames()
        {
            List<string> directoriesWithValidTheme = new List<string>();

            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            if (!string.IsNullOrEmpty(assemblyPath))
            {
                string? execPath = Path.GetDirectoryName(assemblyPath);
                if (execPath != null)
                {
                    string themePath = Path.Combine(execPath, THEME_PATH);
                    string[] directories = Directory.GetDirectories(themePath);

                    foreach (string directory in directories)
                    {
                        string themeFilePath = Path.Combine(directory, THEME_FILE_NAME);

                        if (File.Exists(themeFilePath))
                        {
                            try
                            {
                                string json = File.ReadAllText(themeFilePath);
                                var theme = JsonConvert.DeserializeObject<Theme>(json);

                                if (theme != null)
                                {
                                    directoriesWithValidTheme.Add(Path.GetFileName(directory));
                                }
                            }
                            catch (JsonException)
                            {
                                continue;
                            }
                        }
                    }
                }
            }

            return directoriesWithValidTheme;
        }
        public static bool ThemeExists(string themeName)
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            if (!string.IsNullOrEmpty(assemblyPath))
            {
                string? execPath = Path.GetDirectoryName(assemblyPath);
                if (execPath != null)
                {
                    string themePath = Path.Combine(execPath, THEME_PATH, themeName);

                    if (Directory.Exists(themePath) && File.Exists(Path.Combine(themePath, THEME_FILE_NAME)))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        public void LoadTheme(string themeName)
        {
            if (!string.IsNullOrEmpty(themeName))
            {
                try
                {
                    string assemblyPath = Assembly.GetExecutingAssembly().Location;
                    if (!string.IsNullOrEmpty(assemblyPath)) {
                        string? execPath = Path.GetDirectoryName(assemblyPath);
                        if (execPath != null)
                        {
                            string themePath = Path.Combine(execPath, THEME_PATH, themeName);
                            if (Directory.Exists(themePath) && File.Exists(Path.Combine(themePath, THEME_FILE_NAME)))
                            {
                                string json = File.ReadAllText(Path.Combine(themePath, THEME_FILE_NAME));
                                var theme = JsonConvert.DeserializeObject<Theme>(json);

                                if (theme != null)
                                {
                                    ApplyTheme(theme, themePath);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading theme: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ApplyTheme(Theme theme, string themePath)
        {
            TextColor = theme.TextColor;
            MineFieldBackColor = theme.MineFieldBackColor;
            StatusPanelBackColor = theme.StatusPanelBackColor;
            StatusPanelTextColor = theme.StatusPanelTextColor;
            MenuBackColor = theme.MenuBackColor;
            MenuTextColor = theme.MenuTextColor;
            MenuHoverBackgroundColor = theme.MenuHoverBackgroundColor;
            MenuHoverTextColor = theme.MenuHoverTextColor;
            MineCellBackColor = theme.MineCellBackColor;
            MineCellActivatedBackColor = theme.MineCellActivatedBackColor;
            MineCellFlaggedBackColor = theme.MineCellFlaggedBackColor;
            MineCellExplodedBackColor = theme.MineCellExplodedBackColor;

            MineCellNumberColor0 = theme.MineCellNumberColor0;
            MineCellNumberColor1 = theme.MineCellNumberColor1;
            MineCellNumberColor2 = theme.MineCellNumberColor2;
            MineCellNumberColor3 = theme.MineCellNumberColor3;
            MineCellNumberColor4 = theme.MineCellNumberColor4;
            MineCellNumberColor5 = theme.MineCellNumberColor5;
            MineCellNumberColor6 = theme.MineCellNumberColor6;
            MineCellNumberColor7 = theme.MineCellNumberColor7;
            MineCellNumberColor8 = theme.MineCellNumberColor8;

            string imagePath = Path.Combine(themePath, IMAGE_PATH);
            if (Directory.Exists(imagePath))
            {
                if (File.Exists(Path.Combine(imagePath, theme.MineImage)))
                { 
                    var mineImagePath = Path.Combine(imagePath, theme.MineImage);
                    MineImage = mineImagePath;
                }

                if (File.Exists(Path.Combine(imagePath, theme.FlagImage)))
                {
                    var flagImagePath = Path.Combine(imagePath, theme.FlagImage);
                    FlagImage = flagImagePath;
                }
            }
        }

        public static void SetRoundedCorners(Control control)
        {
            int cornerRadius = 15;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(control.ClientRectangle.Left, control.ClientRectangle.Top, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(control.ClientRectangle.Right - cornerRadius, control.ClientRectangle.Top, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(control.ClientRectangle.Right - cornerRadius, control.ClientRectangle.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(control.ClientRectangle.Left, control.ClientRectangle.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }
    }
}

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

namespace MineSweeperPro
{
    public class ThemeConfig
    {
        const string THEME_PATH = "Themes";
        const string IMAGE_PATH = "Images";
        const string THEME_FILE_NAME = "theme.json";

        public string TextColor { get; set; }
        public string BackColor { get; set; }
        public string FlagColor { get; set; }
        public string FlagInvalidColor { get; set; }
        public string FlagValidColor { get; set; }
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

        public int RoundedCornerRadius { get; set; }
        public string MineImage { get; set; }
        public string FlagImage { get; set; }
        public string FlagInvalidImage { get; set; }
        public string FlagValidImage { get; set; }
        public string CloseImage { get; set; }
        public string MinimizeImage { get; set; }
        public string MaximizeOnImage { get; set; }
        public string MaximizeOffImage { get; set; }
        public string NewGameImage { get; set; }
        public string HintImage { get; set; }
        public string ShareImage { get; set; }
        public string SettingsImage { get; set; }



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
                                var theme = JsonConvert.DeserializeObject<ThemeConfig>(json);

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
                                var theme = JsonConvert.DeserializeObject<ThemeConfig>(json);

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

        private void ApplyTheme(ThemeConfig themeConfig, string themePath)
        {
            TextColor = themeConfig.TextColor;
            BackColor = themeConfig.BackColor;
            FlagColor = themeConfig.FlagColor;
            FlagInvalidColor = themeConfig.FlagInvalidColor;
            FlagValidColor = themeConfig.FlagValidColor;
            MineFieldBackColor = themeConfig.MineFieldBackColor;
            StatusPanelBackColor = themeConfig.StatusPanelBackColor;
            StatusPanelTextColor = themeConfig.StatusPanelTextColor;
            MenuBackColor = themeConfig.MenuBackColor;
            MenuTextColor = themeConfig.MenuTextColor;
            MenuHoverBackgroundColor = themeConfig.MenuHoverBackgroundColor;
            MenuHoverTextColor = themeConfig.MenuHoverTextColor;
            MineCellBackColor = themeConfig.MineCellBackColor;
            MineCellActivatedBackColor = themeConfig.MineCellActivatedBackColor;
            MineCellFlaggedBackColor = themeConfig.MineCellFlaggedBackColor;
            MineCellExplodedBackColor = themeConfig.MineCellExplodedBackColor;

            MineCellNumberColor0 = themeConfig.MineCellNumberColor0;
            MineCellNumberColor1 = themeConfig.MineCellNumberColor1;
            MineCellNumberColor2 = themeConfig.MineCellNumberColor2;
            MineCellNumberColor3 = themeConfig.MineCellNumberColor3;
            MineCellNumberColor4 = themeConfig.MineCellNumberColor4;
            MineCellNumberColor5 = themeConfig.MineCellNumberColor5;
            MineCellNumberColor6 = themeConfig.MineCellNumberColor6;
            MineCellNumberColor7 = themeConfig.MineCellNumberColor7;
            MineCellNumberColor8 = themeConfig.MineCellNumberColor8;

            RoundedCornerRadius = themeConfig.RoundedCornerRadius;

            string imagePath = Path.Combine(themePath, IMAGE_PATH);
            if (Directory.Exists(imagePath))
            {
                if (File.Exists(Path.Combine(imagePath, themeConfig.MineImage)))
                { 
                    var mineImagePath = Path.Combine(imagePath, themeConfig.MineImage);
                    MineImage = mineImagePath;
                }

                if (File.Exists(Path.Combine(imagePath, themeConfig.FlagImage)))
                {
                    var flagImagePath = Path.Combine(imagePath, themeConfig.FlagImage);
                    FlagImage = flagImagePath;
                }

                if (File.Exists(Path.Combine(imagePath, themeConfig.FlagInvalidImage)))
                {
                    var flagImagePath = Path.Combine(imagePath, themeConfig.FlagInvalidImage);
                    FlagInvalidImage = flagImagePath;
                }

                if (File.Exists(Path.Combine(imagePath, themeConfig.FlagValidImage)))
                {
                    var flagImagePath = Path.Combine(imagePath, themeConfig.FlagValidImage);
                    FlagValidImage = flagImagePath;
                }

                if (File.Exists(Path.Combine(imagePath, themeConfig.CloseImage)))
                {
                    var closeImagePath = Path.Combine(imagePath, themeConfig.CloseImage);
                    CloseImage = closeImagePath;
                }

                if (File.Exists(Path.Combine(imagePath, themeConfig.FlagImage)))
                {
                    var minimizeImage = Path.Combine(imagePath, themeConfig.MinimizeImage);
                    MinimizeImage = minimizeImage;
                }

                if (File.Exists(Path.Combine(imagePath, themeConfig.MaximizeOnImage)))
                {
                    var maximizeOnImage = Path.Combine(imagePath, themeConfig.MaximizeOnImage);
                    MaximizeOnImage = maximizeOnImage;
                }

                if (File.Exists(Path.Combine(imagePath, themeConfig.MaximizeOffImage)))
                {
                    var maximizeOffImage = Path.Combine(imagePath, themeConfig.MaximizeOffImage);
                    MaximizeOffImage = maximizeOffImage;
                }

                if (File.Exists(Path.Combine(imagePath, themeConfig.NewGameImage)))
                {
                    var newGameImage = Path.Combine(imagePath, themeConfig.NewGameImage);
                    NewGameImage = newGameImage;
                }

                if (File.Exists(Path.Combine(imagePath, themeConfig.HintImage)))
                {
                    var hintImage = Path.Combine(imagePath, themeConfig.HintImage);
                    HintImage = hintImage;
                }

                if (File.Exists(Path.Combine(imagePath, themeConfig.ShareImage)))
                {
                    var shareImage = Path.Combine(imagePath, themeConfig.ShareImage);
                    ShareImage = shareImage;
                }

                if (File.Exists(Path.Combine(imagePath, themeConfig.SettingsImage)))
                {
                    var settingsImage = Path.Combine(imagePath, themeConfig.SettingsImage);
                    SettingsImage = settingsImage;
                }
            }
        }
    }
}

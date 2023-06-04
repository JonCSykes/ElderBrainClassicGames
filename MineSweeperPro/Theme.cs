using MineSweeperPro.Properties;
using Newtonsoft.Json;
using Svg;
using Svg.FilterEffects;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MineSweeperPro
{
    public class Theme
    {
        public Color TextColor { get; set; }
        public Color BackColor { get; set; }
        public Color FlagColor { get; set; }
        public Color FlagInvalidColor { get; set; }
        public Color FlagValidColor { get; set; }
        public Color MineFieldBackColor { get; set; }
        
        public Color StatusPanelBackColor { get; set; }
        public Color StatusPanelTextColor { get; set; }

        public Color MineCellBackColor { get; set; }
        public Color MineCellActivatedBackColor { get; set; }
        public Color MineCellFlaggedBackColor { get; set; }
        public Color MineCellExplodedBackColor { get; set; }

        public Color MineCellNumberColor0 { get; set; }
        public Color MineCellNumberColor1 { get; set; }
        public Color MineCellNumberColor2 { get; set; }
        public Color MineCellNumberColor3 { get; set; }
        public Color MineCellNumberColor4 { get; set; }
        public Color MineCellNumberColor5 { get; set; }
        public Color MineCellNumberColor6 { get; set; }
        public Color MineCellNumberColor7 { get; set; }
        public Color MineCellNumberColor8 { get; set; }

        public int RoundedCornerRadius { get; set; }
        public Image MineImage { get; set; }
        public Image FlagImage { get; set; }
        public Image FlagInvalidImage { get; set; }
        public Image FlagValidImage { get; set; }
        public Image CloseImage { get; set; }
        public Image MinimizeImage { get; set; }
        public Image MaximizeOnImage { get; set; }
        public Image MaximizeOffImage { get; set; }
        public Image NewGameImage { get; set; }
        public Image HintImage { get; set; }
        public Image ShareImage { get; set; }
        public Image SettingsImage { get; set; }

        public Theme(string themeName)
        {
            var themeConfig = new ThemeConfig();
            themeConfig.LoadTheme(themeName);

            TextColor = ColorTranslator.FromHtml(themeConfig.TextColor);
            BackColor = ColorTranslator.FromHtml(themeConfig.BackColor);
            FlagColor = ColorTranslator.FromHtml(themeConfig.FlagColor);
            FlagInvalidColor = ColorTranslator.FromHtml(themeConfig.FlagInvalidColor);
            FlagValidColor = ColorTranslator.FromHtml(themeConfig.FlagValidColor);
            MineFieldBackColor = ColorTranslator.FromHtml(themeConfig.MineFieldBackColor);
            StatusPanelBackColor = ColorTranslator.FromHtml(themeConfig.StatusPanelBackColor);
            StatusPanelTextColor = ColorTranslator.FromHtml(themeConfig.StatusPanelTextColor);
            MineCellBackColor = ColorTranslator.FromHtml(themeConfig.MineCellBackColor);
            MineCellActivatedBackColor = ColorTranslator.FromHtml(themeConfig.MineCellActivatedBackColor);
            MineCellFlaggedBackColor = ColorTranslator.FromHtml(themeConfig.MineCellFlaggedBackColor);
            MineCellExplodedBackColor = ColorTranslator.FromHtml(themeConfig.MineCellExplodedBackColor);
            MineCellNumberColor0 = ColorTranslator.FromHtml(themeConfig.MineCellNumberColor0);
            MineCellNumberColor1 = ColorTranslator.FromHtml(themeConfig.MineCellNumberColor1);
            MineCellNumberColor2 = ColorTranslator.FromHtml(themeConfig.MineCellNumberColor2);
            MineCellNumberColor3 = ColorTranslator.FromHtml(themeConfig.MineCellNumberColor3);
            MineCellNumberColor4 = ColorTranslator.FromHtml(themeConfig.MineCellNumberColor4);
            MineCellNumberColor5 = ColorTranslator.FromHtml(themeConfig.MineCellNumberColor5);
            MineCellNumberColor6 = ColorTranslator.FromHtml(themeConfig.MineCellNumberColor6);
            MineCellNumberColor7 = ColorTranslator.FromHtml(themeConfig.MineCellNumberColor7);
            MineCellNumberColor8 = ColorTranslator.FromHtml(themeConfig.MineCellNumberColor8);      
            
            RoundedCornerRadius = themeConfig.RoundedCornerRadius;

            if (!string.IsNullOrEmpty(themeConfig.MineImage))
            {
                using (FileStream stream = new FileStream(themeConfig.MineImage, FileMode.Open))
                {
                    Image mineImage = Image.FromStream(stream);

                    MineImage = mineImage;
                }
            }
            else
            {
                MineImage = ConvertSVG(Properties.Resources.land_mine_on_solid, themeConfig.TextColor, 40, 40);
            }

            if (!string.IsNullOrEmpty(themeConfig.FlagImage))
            {
                using (FileStream stream = new FileStream(themeConfig.FlagImage, FileMode.Open))
                {
                    Image flagImage = Image.FromStream(stream);

                    FlagImage = flagImage;
                }
            }
            else
            {
                FlagImage = ConvertSVG(Properties.Resources.flag_solid, themeConfig.FlagColor, 25, 25);
            }

            if (!string.IsNullOrEmpty(themeConfig.FlagInvalidImage))
            {
                using (FileStream stream = new FileStream(themeConfig.FlagInvalidImage, FileMode.Open))
                {
                    Image flagInvalidImage = Image.FromStream(stream);

                    FlagInvalidImage = flagInvalidImage;
                }
            }
            else
            {
                FlagInvalidImage = ConvertSVG(Properties.Resources.flag_solid, themeConfig.FlagInvalidColor, 25, 25);
            }

            if (!string.IsNullOrEmpty(themeConfig.FlagValidImage))
            {
                using (FileStream stream = new FileStream(themeConfig.FlagValidImage, FileMode.Open))
                {
                    Image flagValidImage = Image.FromStream(stream);

                    FlagValidImage = flagValidImage;
                }
            }
            else
            {
                FlagValidImage = ConvertSVG(Properties.Resources.flag_solid, themeConfig.FlagValidColor, 25, 25);
            }

            if (!string.IsNullOrEmpty(themeConfig.CloseImage))
            {
                using (FileStream stream = new FileStream(themeConfig.CloseImage, FileMode.Open))
                {
                    Image closeImage = Image.FromStream(stream);

                    CloseImage = closeImage;
                }
            }
            else
            {
                CloseImage = ConvertSVG(Properties.Resources.xmark_solid, themeConfig.TextColor, 30, 30);
            }

            if (!string.IsNullOrEmpty(themeConfig.MinimizeImage))
            {
                using (FileStream stream = new FileStream(themeConfig.MinimizeImage, FileMode.Open))
                {
                    Image minimizeImage = Image.FromStream(stream);

                    MinimizeImage = minimizeImage;
                }
            }
            else
            {
                MinimizeImage = ConvertSVG(Properties.Resources.window_minimize_solid, themeConfig.TextColor, 25, 25);
            }

            if (!string.IsNullOrEmpty(themeConfig.MaximizeOnImage))
            {
                using (FileStream stream = new FileStream(themeConfig.MaximizeOnImage, FileMode.Open))
                {
                    Image maximizeOnImage = Image.FromStream(stream);

                    MaximizeOnImage = maximizeOnImage;
                }
            }
            else
            {
                MaximizeOnImage = ConvertSVG(Properties.Resources.window_maximize_regular, themeConfig.TextColor, 25, 25);
            }

            if (!string.IsNullOrEmpty(themeConfig.MaximizeOffImage))
            {
                using (FileStream stream = new FileStream(themeConfig.MaximizeOffImage, FileMode.Open))
                {
                    Image maximizeOffImage = Image.FromStream(stream);

                    MaximizeOffImage = maximizeOffImage;
                }
            }
            else
            {
                MaximizeOffImage = ConvertSVG(Properties.Resources.window_maximize_regular, themeConfig.TextColor, 25, 25);
            }

            if (!string.IsNullOrEmpty(themeConfig.NewGameImage))
            {
                using (FileStream stream = new FileStream(themeConfig.NewGameImage, FileMode.Open))
                {
                    Image newGameImage = Image.FromStream(stream);

                    NewGameImage = newGameImage;
                }
            }
            else
            {
                NewGameImage = ConvertSVG(Properties.Resources.circle_play_solid, themeConfig.TextColor, 30, 30);
            }

            if (!string.IsNullOrEmpty(themeConfig.HintImage))
            {
                using (FileStream stream = new FileStream(themeConfig.HintImage, FileMode.Open))
                {
                    Image hintImage = Image.FromStream(stream);

                    HintImage = hintImage;
                }
            }
            else
            {
                HintImage = ConvertSVG(Properties.Resources.life_ring_solid, themeConfig.TextColor, 30, 30);
            }

            if (!string.IsNullOrEmpty(themeConfig.ShareImage))
            {
                using (FileStream stream = new FileStream(themeConfig.ShareImage, FileMode.Open))
                {
                    Image shareImage = Image.FromStream(stream);

                    ShareImage = shareImage;
                }
            }
            else
            {
                ShareImage = ConvertSVG(Properties.Resources.share_nodes_solid, themeConfig.TextColor, 30, 30);
            }

            if (!string.IsNullOrEmpty(themeConfig.SettingsImage))
            {
                using (FileStream stream = new FileStream(themeConfig.SettingsImage, FileMode.Open))
                {
                    Image settingsImage = Image.FromStream(stream);

                    SettingsImage = settingsImage;
                }
            }
            else
            {
                SettingsImage = ConvertSVG(Properties.Resources.sliders_solid, themeConfig.TextColor, 30, 30);
            }
        }

        public void SetRoundedCorners(Control control)
        {
            if (RoundedCornerRadius > 0)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddArc(control.ClientRectangle.Left, control.ClientRectangle.Top, RoundedCornerRadius, RoundedCornerRadius, 180, 90);
                path.AddArc(control.ClientRectangle.Right - RoundedCornerRadius, control.ClientRectangle.Top, RoundedCornerRadius, RoundedCornerRadius, 270, 90);
                path.AddArc(control.ClientRectangle.Right - RoundedCornerRadius, control.ClientRectangle.Bottom - RoundedCornerRadius, RoundedCornerRadius, RoundedCornerRadius, 0, 90);
                path.AddArc(control.ClientRectangle.Left, control.ClientRectangle.Bottom - RoundedCornerRadius, RoundedCornerRadius, RoundedCornerRadius, 90, 90);
                path.CloseFigure();

                control.Region = new Region(path);
            }
        }

        public Image ConvertSVG(byte[] svgResource, string color, int width, int height)
        {
            using (MemoryStream inputStream = new MemoryStream(svgResource))
            {
                using (StreamReader reader = new StreamReader(inputStream))
                {
                    string content = reader.ReadToEnd();

                    string modifiedContent = content.Replace(".st0{fill:#FF00CF;}", ".st0{fill:" + color + ";}");
                    inputStream.Position = 0;

                    using (StreamWriter writer = new StreamWriter(inputStream))
                    {
                        writer.Write(modifiedContent);
                        writer.Flush();

                        using (MemoryStream outputStream = new MemoryStream(Encoding.UTF8.GetBytes(modifiedContent))) 
                        { 
                            var svgDoc = SvgDocument.Open<SvgDocument>(outputStream);
                            svgDoc.Height = height;
                            svgDoc.Width = width;

                            return svgDoc.Draw();
                            }
                    }
                }
            }
        }

    }
}


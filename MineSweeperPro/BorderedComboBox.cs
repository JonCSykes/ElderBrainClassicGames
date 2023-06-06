using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperPro
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class BorderedComboBox : ComboBox
    {
        private Color borderColor = Color.Red; // Change the desired border color here

        public BorderedComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 40;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index >= 0)
            {
                string itemText = Items[e.Index].ToString();

                Font itemFont = new Font(Font, FontStyle.Bold);
                Color itemForeColor = Color.White;
                Color itemBackColor = e.BackColor;

                if (e.State == DrawItemState.HotLight)
                {
                    // Change the highlight color of the selected item
                    itemBackColor = Color.Yellow;
                }

                using (Brush foreBrush = new SolidBrush(itemForeColor))
                using (Brush backBrush = new SolidBrush(itemBackColor))
                {
                    e.Graphics.FillRectangle(backBrush, e.Bounds);
                    e.Graphics.DrawString(itemText, itemFont, foreBrush, e.Bounds);
                }
            }

            base.OnDrawItem(e);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_PAINT = 0xF;
            const int WM_NC_PAINT = 0x85;

            if (m.Msg == WM_PAINT || m.Msg == WM_NC_PAINT)
            {
                using (var g = Graphics.FromHwnd(Handle))
                {
                    using (var pen = new Pen(borderColor, 2))
                    {
                        g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
                    }
                }
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class RoundedPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(new RectangleF(0, 0, Width - 1, Height - 1));

            Region = new Region(path);

            base.OnPaint(e);
        }
    }
}

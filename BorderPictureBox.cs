using MineSweeper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class BorderPictureBox : PictureBox
    {
        private Color borderColor = Color.Black;
        private int borderThickness = 2;

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();  // Redraw the control
            }
        }

        public int BorderThickness
        {
            get { return borderThickness; }
            set
            {
                borderThickness = value;
                Invalidate();  // Redraw the control
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the border using the specified color and thickness
            using (Pen borderPen = new Pen(borderColor, borderThickness))
            {
                Rectangle borderRect = new Rectangle(0, 0, Width - 1, Height - 1);
                e.Graphics.DrawRectangle(borderPen, borderRect);
            }
        }
    }
}

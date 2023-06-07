using System.Drawing.Drawing2D;

namespace MineSweeperPro
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

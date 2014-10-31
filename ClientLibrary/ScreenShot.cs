using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientLibrary
{
    public class ScreenShot
    {
        public Bitmap CaptureScreen()
        {
            Size screenSize = Screen.PrimaryScreen.Bounds.Size;

            Bitmap bitmap = new Bitmap(screenSize.Width, screenSize.Height);

            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), screenSize);

            return GetReduceImage(bitmap,(int) (1920/2.5), (int)(1080/2.5));
        }

        private Bitmap GetReduceImage(Image image, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format16bppRgb555);

            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Transparent);
            graphics.DrawImage(image, new Rectangle(0, 0, width, height));
            return bitmap;
        }
    }
}

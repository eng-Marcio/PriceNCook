using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceNCook
{
    class ImageProcessing
    {
        public ImageProcessing()
        {
            
        }
        public static string ProcessImages(string src)
        {
            try
            {
                int num = 0;
                while (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "pictures", "P" + num + ".png")))
                {
                    num++;
                }
                string name = "P" + num + ".png";
                string path = Path.Combine(Directory.GetCurrentDirectory(), "pictures", name);


                Image image = GetImage(src);
                Rectangle rec = getCroppDimension(image);
                Image croppedImage = cropImage(image, rec);

                Resize(croppedImage, 300, 300).Save(path);
                Resize(croppedImage, 30, 30).Save(Path.Combine(Directory.GetCurrentDirectory(), "pictures_small", name));

                return name;
            } 
            catch
            {
                return null;
            }
            
        }
        public static Image GetImage(string path)
        {
            try
            {
                Image img;
                using (var bmpTemp = new Bitmap(path))
                {
                    img = new Bitmap(bmpTemp);
                }
                return img;
            }
            catch
            {
                return null;
            }
        }
        public static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        public static Rectangle getCroppDimension(Image img)
        {
            Size size = img.Size;
            int cuttingSize = Math.Min(size.Width, size.Height);
            int x_pos = (size.Width - cuttingSize) / 2;
            int y_pos = (size.Height - cuttingSize) / 2;
            return new Rectangle(x_pos, y_pos, cuttingSize, cuttingSize);
        }
        public static Image Resize(Image originalImage, int w, int h)
        {
            //Original Image attributes
            int originalWidth = originalImage.Width;
            int originalHeight = originalImage.Height;

            // Figure out the ratio
            double ratioX = (double)w / (double)originalWidth;
            double ratioY = (double)h / (double)originalHeight;
            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(originalHeight * ratio);
            int newWidth = Convert.ToInt32(originalWidth * ratio);

            Image thumbnail = new Bitmap(newWidth, newHeight);
            Graphics graphic = Graphics.FromImage(thumbnail);

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            graphic.Clear(Color.Transparent);
            graphic.DrawImage(originalImage, 0, 0, newWidth, newHeight);

            return thumbnail;
        }
    }
}

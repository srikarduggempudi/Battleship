using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace GameLibrary
{
    public class ImageUtil
    {
        private static Image blastImage;
        private static Image missImage;

        public static Image[] ChopShipImage(string imageName, Direction direction, int size)
        {
            Image image = GetEmbeddedImage(imageName);
            int numImages = image.Size.Height / size;
            Image[] choppedImage = new Image[numImages];

            for (int i = 0; i < numImages; i++)
            {
                Rectangle sourceRect = new Rectangle(0, i * size, size, size);
                Bitmap newBitmap = new Bitmap(size, size);
                using (Graphics g = Graphics.FromImage(newBitmap))
                {
                    g.DrawImage(image, 0, 0, sourceRect, GraphicsUnit.Pixel);
                    // Input image is vertical. So, we need to rotate
                    // if we are asked for ship images to be horizontal
                    if (direction == Direction.Horizontal)
                    {
                        choppedImage[i] = RotateImage(newBitmap, -90);
                    }
                    else
                    {
                        choppedImage[i] = newBitmap;
                    }
                }
            }

            return choppedImage;
        }

        /// <summary>
        /// Rotate an image either clockwise or counter-clockwise
        /// </summary>
        /// <param name="img">the image to be rotated</param>
        /// <param name="rotationAngle">the angle (in degrees).
        /// NOTE: 
        /// Positive values will rotate clockwise
        /// negative values will rotate counter-clockwise
        /// </param>
        /// <returns></returns>
        public static Image RotateImage(Image img, float rotationAngle)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                //now we set the rotation point to the center of our image
                g.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

                //now rotate the image
                g.RotateTransform(rotationAngle);

                g.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

                //set the InterpolationMode to HighQualityBicubic so to ensure a high
                //quality image once it is transformed to the specified size
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(img, new Point(0, 0));
            }

            return bmp;
        }

        public static void DrawBlast(Graphics g, Control control)
        {
            if (blastImage == null)
            {
                blastImage = GetEmbeddedImage("Images.Blast.png");
            }

            int cellWidth = control.ClientRectangle.Width;
            int cellHeight = control.ClientRectangle.Height;
            int blastWidth = blastImage.Size.Width;
            int blastHeight = blastImage.Size.Height;
            int deltaWidth = cellWidth / 2 - blastWidth / 2;
            int deltaHeight = cellHeight / 2 - blastHeight / 2;
            Point pt = new Point(control.ClientRectangle.X + deltaWidth,
                                    control.ClientRectangle.Y + deltaHeight);
            g.DrawImage(blastImage, pt);
        }

        public static void DrawMiss(Graphics g, Control control)
        {
            if (missImage == null)
            {
                missImage = GetEmbeddedImage("Images.Miss.png");
            }

            int cellWidth = control.ClientRectangle.Width;
            int cellHeight = control.ClientRectangle.Height;
            int blastWidth = missImage.Size.Width;
            int blastHeight = missImage.Size.Height;
            int deltaWidth = cellWidth / 2 - blastWidth / 2;
            int deltaHeight = cellHeight / 2 - blastHeight / 2;
            Point pt = new Point(control.ClientRectangle.X + deltaWidth,
                                    control.ClientRectangle.Y + deltaHeight);
            g.DrawImage(missImage, pt);
        }

        /// <summary>
        /// Get the embedded image
        /// </summary>
        /// <param name="imageName">name of the embedded resource image file name</param>
        /// <returns>the image that is embedded</returns>
        public static Image GetEmbeddedImage(string imageName)
        {
            Assembly thisAssembly = Assembly.GetEntryAssembly(); // Assembly.GetExecutingAssembly();
            Stream imageFile = thisAssembly.GetManifestResourceStream(Assembly.GetEntryAssembly().GetName().Name + "." + imageName);
            if (imageFile == null)
            {
                thisAssembly = Assembly.GetExecutingAssembly();
                imageFile = thisAssembly.GetManifestResourceStream(Assembly.GetExecutingAssembly().GetName().Name + "." + imageName);
            }
            return Image.FromStream(imageFile);
        }

        /// <summary>
        /// Get the embedded icon
        /// </summary>
        /// <param name="iconName">name of the embedded resource icon file name</param>
        /// <returns>the icon that is embedded</returns>
        public static Icon GetEmbeddedIcon(string iconName)
        {
            Assembly thisAssembly = Assembly.GetEntryAssembly(); // Assembly.GetExecutingAssembly();
            Stream imageFile = thisAssembly.GetManifestResourceStream(Assembly.GetEntryAssembly().GetName().Name + "." + iconName);
            return new Icon(imageFile);
        }
    }
}

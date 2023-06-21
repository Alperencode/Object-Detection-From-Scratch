using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CoinDotDetection
{
    internal class DetectCoins
    {
        public Bitmap DetecCoinsInImage(Bitmap image)
        {
            Color lastPixel = image.GetPixel(0, 0);

            Bitmap debugImage = (Bitmap)image.Clone();

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color currentPixel = image.GetPixel(x, y);
                    double similarity = PixelColorSimilarity(lastPixel, currentPixel);
                    double graySimilarity = PixelColorSimilarity(currentPixel, Color.DarkGray);

                    if (similarity > 20 && graySimilarity > 125)
                    {
                        debugImage.SetPixel(x, y, Color.Red);
                    }

                    lastPixel = currentPixel;
                }
            }

            return debugImage;

        }

        public double PixelColorSimilarity(Color pixel1, Color pixel2)
        {
            // Color similarity formula (range 0-20 is similar, 50-100 or >100 is not similar)
            double distance = Math.Sqrt(Math.Pow(pixel1.R - pixel2.R, 2) + Math.Pow(pixel1.G - pixel2.G, 2) + Math.Pow(pixel1.B - pixel2.B, 2));

            return distance;
        }
    }
}

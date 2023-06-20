using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection
{
    internal class Compare
    {


        public double CompareImages(Bitmap image1, Bitmap image2)
        {
            int minWidth = Math.Min(image1.Width, image2.Width);
            int minHeight = Math.Min(image1.Height, image2.Height);

            double mse = 0;

            for (int y = 0; y < minHeight; y++)
            {
                for (int x = 0; x < minWidth; x++)
                {
                    Color pixel1 = image1.GetPixel(x, y);
                    Color pixel2 = image2.GetPixel(x, y);

                    double deltaR = pixel1.R - pixel2.R;
                    double deltaG = pixel1.G - pixel2.G;
                    double deltaB = pixel1.B - pixel2.B;

                    mse += (deltaR * deltaR) + (deltaG * deltaG) + (deltaB * deltaB);
                }
            }

            int totalPixels = minWidth * minHeight;
            mse /= (totalPixels * 3);

            return 100 - ((mse / (minHeight*minWidth)) * 100);
            
        }

    }
}

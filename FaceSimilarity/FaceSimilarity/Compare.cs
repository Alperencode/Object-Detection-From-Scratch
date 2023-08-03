namespace FaceDetection
{
    internal class Compare
    {


        public double CompareImages(Bitmap image1, Bitmap image2)
        {

            int averageWidth = (image1.Width + image2.Width) / 2;
            int averageHeigth = (image1.Height + image2.Height) / 2;

            image1 = ResizeImage(image1, averageWidth, averageHeigth);
            image2 = ResizeImage(image2, averageWidth, averageHeigth);

            double mse = 0;

            for (int y = 0; y < averageHeigth; y++)
            {
                for (int x = 0; x < averageWidth; x++)
                {
                    Color pixel1 = image1.GetPixel(x, y);
                    Color pixel2 = image2.GetPixel(x, y);

                    double deltaR = pixel1.R - pixel2.R;
                    double deltaG = pixel1.G - pixel2.G;
                    double deltaB = pixel1.B - pixel2.B;

                    mse += (deltaR * deltaR) + (deltaG * deltaG) + (deltaB * deltaB);
                }
            }

            int totalPixels = averageWidth * averageHeigth;
            mse /= (totalPixels * 3);

            return 100 - (mse / totalPixels * 100);

        }


        private Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            var resizedImage = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }

    }
}

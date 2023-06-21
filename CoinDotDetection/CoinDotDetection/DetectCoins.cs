namespace CoinDotDetection
{
    internal class DetectCoins
    {
        public void DetecCoinsInImage(Bitmap image, Form form)
        {
            // var debugLabel = form.Controls.Find("debugLabel", true).FirstOrDefault();

            int[] coin1X = FindCoinXValues(image, 0, 0);
            int[] coin2X = FindCoinXValues(image, coin1X[1]+1, 0);
        }

        public double PixelColorSimilarity(Color pixel1, Color pixel2)
        {
            // Color similarity formula (range 0-20 is similar, 50-100 or >100 is not similar)
            double distance = Math.Sqrt(Math.Pow(pixel1.R - pixel2.R, 2) + Math.Pow(pixel1.G - pixel2.G, 2) + Math.Pow(pixel1.B - pixel2.B, 2));

            return distance;
        }

        public int FindEndOfCoin(Bitmap image, int startX, int startY)
        {
            for (int i = startX; i < image.Width; i++)
            {
                // If pixel is similar with DarkGray, means end of the coin
                if (PixelColorSimilarity(image.GetPixel(i, startY), Color.DarkGray) < 25)
                {
                    /* Red line for end of coin (DEBUG)
                    for (int j = 0; j < image.Height; j++)
                    {
                        image.SetPixel(i, j, Color.Red);
                    }
                    */
                    return i;
                }
            }
            return -1;
        }

        public int[] FindCoinXValues(Bitmap image, int argX, int argY)
        {
            Color lastPixel = image.GetPixel(argX, argY);

            int startX = -1;
            int endX = -1;

            for (int x = argX; x < image.Width; x++)
            {
                for (int y = argY; y < image.Height; y++)
                {
                    Color currentPixel = image.GetPixel(x, y);

                    double similarity = PixelColorSimilarity(lastPixel, currentPixel);
                    double graySimilarity = PixelColorSimilarity(currentPixel, Color.DarkGray);

                    // If not similar with gray, means found the coin
                    if (graySimilarity > 125)
                    {
                        /* Painting coin to red (DEBUG)
                        image.SetPixel(x, y, Color.Red);
                        */

                        // First coin startX
                        startX = x;
                        endX = FindEndOfCoin(image, x, y);

                        /* Red Line for end of coin (DEBUG)
                        for (int i = 0; i < image.Height; i++)
                        {
                            image.SetPixel(x, i, Color.Red);
                        }
                        */

                        return new int[] { startX, endX };
                    }

                    lastPixel = currentPixel;
                }
            }

            return new int[] { startX, endX };
        }
    }
}

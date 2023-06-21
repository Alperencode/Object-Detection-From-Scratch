namespace CoinDotDetection
{
    internal class DetectCoins
    {
        public void DetecCoinsInImage(Bitmap image, Form form)
        {
            // var debugLabel = form.Controls.Find("debugLabel", true).FirstOrDefault();

            int[] coin1X = FindCoinAxis(image, 0, 0, FindWidth:true);
            int[] coin2X = FindCoinAxis(image, coin1X[1]+1, 0, FindWidth: true);

            int[] coin1Y = FindCoinAxis(image, 0, 0, FindWidth: false);
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
                    return i;
                }
            }
            return -1;
        }

        public int[] FindCoinAxis(Bitmap image, int argX, int argY, bool FindWidth)
        {
            Color lastPixel = image.GetPixel(argX, argY);

            int start = -1;
            int end = -1;

            for (int i = (FindWidth ? argX : argY); i < (FindWidth ? image.Width : image.Height); i++)
            {
                for (int j = (FindWidth ? argY : argX); j < (FindWidth ? image.Height : image.Width); j++)
                {

                    Color currentPixel = image.GetPixel((FindWidth ? i : j), (FindWidth ? j : i));

                    double graySimilarity = PixelColorSimilarity(currentPixel, Color.DarkGray);

                    // If not similar with gray, means found the coin
                    if (graySimilarity > 125)
                    {
                        /* Painting coin to red (DEBUG)
                        image.SetPixel(i, j, Color.Red);
                        */

                        if (FindWidth)
                        {
                            // First coin start
                            start = i;
                            end = FindEndOfCoin(image, i, j);

                            // Drawing red lines on coin
                            Pen blackPen = new Pen(Color.Red, 5);
                            using (var graphics = Graphics.FromImage(image))
                            {
                                graphics.DrawLine(blackPen, start, j, end, j);
                            }

                            return new int[] { start, end };
                        }
                        else
                        {
                            // Implement here
                        };

                    }

                    lastPixel = currentPixel;
                }
            }

            return new int[] { start, end };
        }
    }
}

namespace CoinDotDetection
{
    internal class DetectCoins
    {
        public List<Rectangle> DetectCoinsInImage(Bitmap image)
        {
            Coin coin1 = new();
            Coin coin2 = new();


            FindCoinAxis(image, coin1, 0, 0, FindWidth: true);
            FindCoinAxis(image, coin2, (coin1.xEnd + 1), 0, FindWidth: true);

            /* 
             * Need to match widths and heights with the right coin
             * Currently it's not implemented and causes logic bugs
             */
            FindCoinAxis(image, coin1, 0, 0, FindWidth: false);
            FindCoinAxis(image, coin2, 0, (coin1.yEnd + 1), FindWidth: false);

            return new List<Rectangle>() {
                coin1.GetRectangle(),
                coin2.GetRectangle(),
            };
        }

        public double PixelColorSimilarity(Color pixel1, Color pixel2)
        {
            // Color similarity formula (range 0-20 is similar, 50-100 or >100 is not similar)
            double distance = Math.Sqrt(Math.Pow(pixel1.R - pixel2.R, 2) + Math.Pow(pixel1.G - pixel2.G, 2) + Math.Pow(pixel1.B - pixel2.B, 2));
            return distance;
        }

        public int FindEndOfCoin(Bitmap image, int startX, int startY, bool FindWidth, Color backgroundColor)
        {
            if(FindWidth)
            {
                for (int i = startX; i < image.Width; i++)
                {
                    // If pixel is similar with backgroundColor, means end of the coin
                    if (PixelColorSimilarity(image.GetPixel(i, startY), backgroundColor) < 25)
                        return i;
                }
            }
            else
            {
                int tolerance = 0;
                for (int i = startY; i < image.Height; i++)
                {
                    Color currentPixel = image.GetPixel(startX, i);

                    // If pixel is similar with backgroundColor, means end of the coin
                    if (PixelColorSimilarity(currentPixel, backgroundColor) < 50)
                    {
                        if(tolerance > 5)
                            return i;
                        tolerance += 1;
                    }
                }
            }
            // throw new Exception("Gray not found");
            return -1;
        }

        public void FindCoinAxis(Bitmap image, Coin coin, int argX, int argY, bool FindWidth)
        {
            /* Finding x or y axis of the object (start and end) according to FindWidth argument */

            // Color lastPixel = image.GetPixel(argX, argY);
            Color currentPixel;

            Color backgroundColor = FindBackgroundColor(image);

            for (int i = argX; i < (FindWidth ? image.Width : image.Height); i++)
            {
                for (int j = argY; j < (FindWidth ? image.Height : image.Width); j++)
                {
                    currentPixel = image.GetPixel((FindWidth ? i : j), (FindWidth ? j : i));
                    double backgroundSimilarity = PixelColorSimilarity(currentPixel, backgroundColor);
                    Pen redPen = new Pen(Color.Red, 3);

                    // If not similar with gray, means found the coin
                    if (backgroundSimilarity > 150)
                    {
                        if (FindWidth)
                        {
                            /* Painting coin to red (DEBUG)
                            image.SetPixel(i, j, Color.Red);
                            */

                            // First coin start
                            coin.xStart = i;
                            coin.xEnd = FindEndOfCoin(image, i, j, FindWidth, backgroundColor);

                            // Drawing red lines on coin
                            using var graphics = Graphics.FromImage(image);
                            graphics.DrawLine(redPen, coin.xStart, j, coin.xEnd, j);

                            return;
                            // lastPixel = currentPixel;
                            // return new int[] { start, end };
                        }
                        else
                        {
                            coin.yStart = i;
                            coin.yEnd = FindEndOfCoin(image, j, i, FindWidth, backgroundColor);

                            // Drawing red lines on coin
                            using var graphics = Graphics.FromImage(image);
                            graphics.DrawLine(redPen, j, coin.yStart, j, coin.yEnd);

                            return;
                            // lastPixel = currentPixel;
                            // return new int[] { start, end , j};
                        }
                    }
                }
            }

            // return new int[] { start, end };
        }
    
        public static Color FindBackgroundColor(Bitmap image)
        {
            /* Detecting background color by scanning small part of the image and returning average RGB */

            // Using %40 of the image to scan the background
            int smallWidth = (int)(image.Width * 0.4);
            int smallHeight = (int)(image.Height * 0.4);

            int totalR = 0, totalG = 0, totalB = 0;
            for (int i = 0; i < smallWidth; i++)
            {
                for (int j = 0; j < smallHeight; j++)
                {
                    Color currentPixel = image.GetPixel(i, j);
                    totalR += currentPixel.R;
                    totalG += currentPixel.G;
                    totalB += currentPixel.B;
                }
            }
            
            // Returning average of the total rgb
            int totalPixel = smallHeight * smallWidth;
            return Color.FromArgb(
                totalR / totalPixel,
                totalG / totalPixel,
                totalB / totalPixel
            );
        }

    }
}

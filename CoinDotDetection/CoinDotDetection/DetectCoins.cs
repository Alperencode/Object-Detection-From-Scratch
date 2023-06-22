namespace CoinDotDetection
{
    internal class DetectCoins
    {
        public List<Rectangle> DetecCoinsInImage(Bitmap image)
        {
            int[] coin1X = FindCoinAxis(image, 0, 0, FindWidth: true);
            int[] coin2X = FindCoinAxis(image, coin1X[1]+1, 0, FindWidth: true);

            int[] coin1Y = FindCoinAxis(image, 0, 0, FindWidth: false);
            int[] coin2Y = FindCoinAxis(image, 0, coin1Y[0] + 1, FindWidth: false);

            return new List<Rectangle>() {
                new Rectangle(coin1X[0], coin1Y[0], coin1X[1]-coin1X[0], coin1Y[1]-coin1Y[0]),
                new Rectangle(coin2X[0], coin2Y[0], coin2X[1]-coin2X[0], coin2Y[1]-coin2Y[0]),
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
                    {
                        return i;
                    }
                }
            }
            else
            {
                int counter = 0;
                for (int i = startY+5; i < image.Height; i++)
                {
                    Color currentPixel = image.GetPixel(startX, i);

                    // If pixel is similar with backgroundColor, means end of the coin
                    if (PixelColorSimilarity(currentPixel, backgroundColor) < 50)
                    {
                        if(counter > 5)
                            return i;
                        counter += 1;
                    }
                }
            }
            // throw new Exception("Gray not found");
            return -1;
        }

        public int[] FindCoinAxis(Bitmap image, int argX, int argY, bool FindWidth)
        {
            // Color lastPixel = image.GetPixel(argX, argY);
            Color currentPixel;

            int start = -1;
            int end = -1;

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
                            start = i;
                            end = FindEndOfCoin(image, i, j, FindWidth, backgroundColor);

                            // Drawing red lines on coin
                            using (var graphics = Graphics.FromImage(image))
                            {
                                graphics.DrawLine(redPen, start, j, end, j);
                            }

                            // lastPixel = currentPixel;
                            return new int[] { start, end };
                        }
                        else
                        {
                            start = i;
                            end = FindEndOfCoin(image, j, i, FindWidth, backgroundColor);

                            // Drawing red lines on coin
                            using (var graphics = Graphics.FromImage(image))
                            {
                                graphics.DrawLine(redPen, j, start, j, end);
                            }

                            // lastPixel = currentPixel;
                            return new int[] { start, end };
                        }
                    }
                }
            }

            return new int[] { start, end };
        }
    
        public Color FindBackgroundColor(Bitmap image)
        {
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

            int totalPixel = smallHeight * smallWidth;

            return Color.FromArgb(
                totalR / totalPixel,
                totalG / totalPixel,
                totalB / totalPixel
            );
        }

    }
}

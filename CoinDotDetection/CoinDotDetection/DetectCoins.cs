namespace CoinDotDetection
{
    internal class DetectCoins
    {
        public Form1 form { get; set; }

        // Constructer with form
        public DetectCoins(Form1 form) {
            this.form = form;
        }

        // Constructer override
        public DetectCoins() { }

        public List<Rectangle> DetectCoinsInImage(Bitmap image)
        {
            Coin coin1 = new();
            Coin coin2 = new();

            FindCoinAxis(image, coin1, 0, 0, FindWidth: true);
            FindCoinAxis(image, coin2, (coin1.xEnd + 1), 0, FindWidth: true);

            // Logic for matching the right coin
            /*
             * Logic: 
             * 1) Find the first coin both Y axis and store the temporary X axis when find them
             * 2) If statement to determine which coin's X axis is closer to temporary X
             * 3) This statement matches the right coin
             * 3.1) If coin2 is closer to temporary X that means first Y axis is for coin2, then swap the values and proceed for coin1
             * 3.2) Else coin1 is the right coin for Y axis, proceed for coin2
             */
            FindCoinAxis(image, coin1, 0, 0, FindWidth: false);
            if (Math.Abs(coin1.tempX - coin1.xStart) > Math.Abs(coin1.tempX - coin2.xStart))
            {
                // Swap axis to match the right coin
                coin2.yStart = coin1.yStart;
                coin2.yEnd = coin1.yEnd;
                FindCoinAxis(image, coin1, 0, (coin2.yEnd + 1), FindWidth: false);
            }
            else
                FindCoinAxis(image, coin2, 0, (coin1.yEnd + 1), FindWidth: false);

            return new List<Rectangle>() {
                coin1.GetRectangle(),
                coin2.GetRectangle(),
            };
        }

        public double PixelColorSimilarity(Color pixel1, Color pixel2)
        {
            // Color similarity formula (range 0-20 is similar, 50-100 or >100 is not similar)
            return Math.Sqrt(Math.Pow(pixel1.R - pixel2.R, 2) + Math.Pow(pixel1.G - pixel2.G, 2) + Math.Pow(pixel1.B - pixel2.B, 2));
        }

        public int FindEndOfCoin(Bitmap image, int startX, int startY, bool FindWidth, Color backgroundColor)
        {
            int tolerance = 0;

            if (FindWidth)
            {
                for (int i = startX; i < image.Width; i++)
                {
                    // If pixel is similar with backgroundColor, means end of the coin
                    if (PixelColorSimilarity(image.GetPixel(i, startY), backgroundColor) < form.GetBSWValue)
                    {
                        if (tolerance > form.GetPixelTolerance)
                            return i;
                        tolerance += 1;
                    }
                }
            }
            else
            {
                for (int i = startY; i < image.Height; i++)
                {
                    Color currentPixel = image.GetPixel(startX, i);

                    // If pixel is similar with backgroundColor, means end of the coin
                    if (PixelColorSimilarity(currentPixel, backgroundColor) < form.GetBSHValue)
                    {
                        if(tolerance > form.GetPixelTolerance)
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
                    Pen redPen = new(Color.Red, 3);

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
                            coin.tempX = j;
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

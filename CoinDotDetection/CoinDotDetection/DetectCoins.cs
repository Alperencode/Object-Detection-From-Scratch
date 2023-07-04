namespace CoinDotDetection
{
    internal class DetectCoins
    {
        public Form1 form { get; set; }
        public Color backgroundColor { get; set; }

        /// <summary>
        /// Constructer with form and background color
        /// </summary>
        /// <param name="image"> Bitmap of image to find background color </param>
        /// <param name="form"> Form  object to use components </param>
        public DetectCoins(Bitmap image, Form1 form) {
            this.form = form;
            backgroundColor = FindBackgroundColor(image);
        }

        /// <summary>
        /// Constructer with no arguments, initializes DetectCoins
        /// </summary>
        public DetectCoins() { }

        /// <summary>
        /// Detects two coins in given image
        /// </summary>
        /// <param name="image"> Bitmap of image to detect coins </param>
        public List<Rectangle> DetectCoinsInImage(Bitmap image)
        {
            // Initializing Coin instances
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

            // Check if coins are not detected (Width or Height below zero)
            if (coin1.CheckCoin() || coin2.CheckCoin())
            {
                // If coins not detected, change label and return empty list
                form.ChangeDetectLabel("Coins not Detected", Color.Red);
                return new List<Rectangle>();
            }

            // Else change label and return Rectangle list
            form.ChangeDetectLabel("Coins Detected", Color.Green);
            return new List<Rectangle>() {
                coin1.GetRectangle(),
                coin2.GetRectangle(),
            };
        }

        /// <summary>
        /// Calculates similarity score between two given pixels
        /// </summary>
        /// <param name="pixel1"> First pixel </param>
        /// <param name="pixel2"> Second pixel </param>
        /// <returns> Similarity score as double </returns>
        public double PixelColorSimilarity(Color pixel1, Color pixel2) =>
            Math.Sqrt(Math.Pow(pixel1.R - pixel2.R, 2) + Math.Pow(pixel1.G - pixel2.G, 2) + Math.Pow(pixel1.B - pixel2.B, 2));

        /// <summary>
        /// Finds end of the coin axis using given image and start value
        /// </summary>
        /// <param name="image"> Bitmap of image </param>
        /// <param name="startX"> X axis to start scanning </param>
        /// <param name="startY"> Y axis to start scanning </param>
        /// <param name="FindWidth"> Boolean to determine finding width or height </param>
        /// <returns> Returns integer value of found axis </returns>
        public int FindEndOfCoin(Bitmap image, int startX, int startY, bool FindWidth)
        {
            int tolerance = 0;
            /* 
             * If FindWidth is true:
             * - Start from startX until image.Width and current pixel is (i, startY)
             * Else:
             * - Start from startY until image.Height and current pixel is (startX, i)
             */
            for (int i = (FindWidth ? startX : startY); i < (FindWidth ? image.Width : image.Height); i++)
            {
                Color currentPixel = image.GetPixel((FindWidth ? i : startX), (FindWidth ? startY : i));
                // If pixel is similar with backgroundColor, means end of the coin
                if (PixelColorSimilarity(currentPixel, backgroundColor) < (FindWidth ? form.GetBSWValue : form.GetBSHValue))
                {
                    if (tolerance > form.GetPixelTolerance)
                        return i;
                    tolerance += 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// Finds coin's both axis (`X` or `Y` according to FindWidth) and sets values for given coin
        /// </summary>
        /// <param name="image"> Bitmap of image </param>
        /// <param name="coin"> Coin object to set values </param>
        /// <param name="argX"> Determines initial X axis to start scaning </param>
        /// <param name="argY"> Determines initial Y axis to start scaning </param>
        /// <param name="FindWidth"> Boolean to determine finding X axis or Y axis </param>
        public void FindCoinAxis(Bitmap image, Coin coin, int argX, int argY, bool FindWidth)
        {
            /* Finding x or y axis of the object (start and end) according to FindWidth argument */
            Color currentPixel;

            /* If FindWidth is true:
             * - Start from argX until image.Width and current pixel is (i, j)
             * Else:
             * - Start from argX until image.Height and current pixel is (j, i)
             */

            for (int i = argX; i < (FindWidth ? image.Width : image.Height); i++)
            {
                for (int j = argY; j < (FindWidth ? image.Height : image.Width); j++)
                {
                    currentPixel = image.GetPixel((FindWidth ? i : j), (FindWidth ? j : i));
                    double backgroundSimilarity = PixelColorSimilarity(currentPixel, backgroundColor);

                    // If not similar with background, means found the coin
                    if (backgroundSimilarity > form.GetBSValue)
                    {
                        if (FindWidth)
                        {
                            // Assign current to xStart
                            coin.xStart = i;

                            // Finding xEnd using FindEndOfCoin method
                            coin.xEnd = FindEndOfCoin(image, i, j, FindWidth);

                            return;
                        }
                        else
                        {
                            // Assign current to yStart
                            coin.yStart = i;
                            coin.tempX = j;

                            // Finding yEnd using FindEndOfCoin method
                            coin.yEnd = FindEndOfCoin(image, j, i, FindWidth);

                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Finds background color by calculating average RGB of given image
        /// </summary>
        /// <param name="image"> Bitmap of image </param>
        /// <returns> Returns Color object with calculated background RGB </returns>
        public Color FindBackgroundColor(Bitmap image)
        {
            /* Detecting background color by scanning small part of the image and returning average RGB */

            // Using %40 of the image to scan the background
            int smallWidth = (int)(image.Width * form.GetBackgroundScan * 0.01);
            int smallHeight = (int)(image.Height * form.GetBackgroundScan * 0.01);

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

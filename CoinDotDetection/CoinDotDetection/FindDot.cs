namespace CoinDotDetection
{
    internal class FindDot
    {
        public Bitmap FindCoinWithDot(Bitmap coin1, Bitmap coin2) {

            // Selecting smaller width and height
            int width = Math.Min(coin1.Width, coin2.Width);
            int height = Math.Min(coin1.Height, coin2.Height);

            // Initializing DetectCoins instance to use PixelColorSimilarity
            DetectCoins detection = new DetectCoins();

            // Counter for both coins to count dots
            int coin1Dots = 0;
            int coin2Dots = 0;

            // Traversing image using pixels
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Assigning current pixels
                    Color coin1Current = coin1.GetPixel(x, y);
                    Color coin2Current = coin2.GetPixel(x, y);

                    // Increasing counter using color similarity with `Black` color
                    if (detection.PixelColorSimilarity(coin1Current, Color.Black) < 3)
                        coin1Dots++;
                    if(detection.PixelColorSimilarity(coin2Current, Color.Black) < 3)
                        coin2Dots++;
                }
            }

            // Returning coin with dot using counters
            return (coin1Dots > coin2Dots ? coin1 : coin2);

        }

        public Rectangle FindCoinWithDot(Bitmap image, List<Rectangle> coins)
        {
            // Converting both coins to bitmap
            Bitmap coin1Bitmap = image.Clone(coins[0], image.PixelFormat);
            Bitmap coin2Bitmap = image.Clone(coins[1], image.PixelFormat);

            // Calling FindCoinWithDot function using bitmap versions
            Bitmap coinWithDot = FindCoinWithDot(coin1Bitmap, coin2Bitmap);

            // Returning rectangle of coin with dot using bitmaps
            return (coinWithDot == coin1Bitmap ? coins[0] : coins[1]);
        }
    }
}

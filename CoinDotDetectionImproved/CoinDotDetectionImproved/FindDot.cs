namespace CoinDotDetectionImproved
{
    internal class FindDot
    {
        /// <summary>
        /// Calculates dot number on given coins and returns coin with dot
        /// </summary>
        /// <param name="coin1Bmp"> First coin bitmap </param>
        /// <param name="coin2Bmp"> Second coin bitmap </param>
        /// <returns> Returns coin with dot as Bitmap </returns>
        public static Bitmap FindCoinWithDot(Bitmap coin1Bmp, Bitmap coin2Bmp)
        {

            // Selecting smaller width and height
            byte[]
            coin1 = Methods.BitmapToBytes(coin1Bmp),
            coin2 = Methods.BitmapToBytes(coin2Bmp);

            // Counter for both coins to count dots
            int coin1Dots = 0, coin2Dots = 0;

            // Traversing image
            int i = 0;
            for (; i < Math.Min(coin1.Length, coin2.Length) - 2; i += 3)
            {
                if (coin1[i] < 15 && coin1[i + 1] < 15 && coin1[i + 2] < 15)
                    coin1Dots++;

                if (coin2[i] < 15 && coin2[i + 1] < 15 && coin2[i + 2] < 15)
                    coin2Dots++;
            }

            // Finish traversing bigger image
            if (coin1.Length > coin2.Length)
            {
                for (; i < coin1.Length - 2; i+=3)
                {
                    if (coin1[i] < 15 && coin1[i + 1] < 15 && coin1[i + 2] < 15)
                        coin1Dots++;
                }
            }
            else
            {
                for (; i < coin2.Length - 2; i+=3)
                {
                    if (coin2[i] < 15 && coin2[i + 1] < 15 && coin2[i + 2] < 15)
                        coin2Dots++;
                }
            }

            // Returning coin with dot using counters
            return (coin1Dots > coin2Dots ? coin1Bmp : coin2Bmp);

        }
    }
}

namespace CoinDotDetection
{
    internal class FindDot
    {
        public Bitmap FindCoinWithDot(Bitmap coin1, Bitmap coin2) {

            int width = Math.Min(coin1.Width, coin2.Width);
            int height = Math.Min(coin1.Height, coin2.Height);

            DetectCoins detection = new();

            int coin1Dots = 0;
            int coin2Dots = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color coin1Current = coin1.GetPixel(x, y);
                    Color coin2Current = coin2.GetPixel(x, y);
                    if (detection.PixelColorSimilarity(coin1Current, Color.Black) < 3)
                    {
                        coin1Dots++;
                    }else if(detection.PixelColorSimilarity(coin2Current, Color.Black) < 3)
                    {
                        coin2Dots++;
                    }
                }
            }

            return (coin1Dots > coin2Dots ? coin1 : coin2);

        }

        public Rectangle FindCoinWithDot(Bitmap image, Rectangle coin1, Rectangle coin2)
        {
            Bitmap coin1Bitmap = image.Clone(coin1, image.PixelFormat);
            Bitmap coin2Bitmap = image.Clone(coin2, image.PixelFormat);

            Bitmap coinWithDot = FindCoinWithDot(coin1Bitmap, coin2Bitmap);

            return (coinWithDot == coin1Bitmap ? coin1 : coin2);
        }
    }
}

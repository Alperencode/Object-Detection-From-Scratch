using System.Drawing.Imaging;

namespace CoinDotDetectionUnsafePointer
{
    internal class Methods
    {
        unsafe
        public static void DetectCoins(Bitmap image, BitmapData bmpdata)
        {
            Coin
            coin1 = new(),
            coin2 = new();

            FindCoin(image, bmpdata, coin1);
        }

        private static void FindCoin(Bitmap image, BitmapData bmpdata, Coin coin)
        {
            Rectangle rec = new(0, 0, image.Width, image.Height);
            unsafe
            {
                // Gets the address of the first pixel data in the bitmap
                byte* ptr = (byte*)bmpdata.Scan0;

                bool flag = false;
                for (int i = 0; i < bmpdata.Height; i++)
                {
                    for (int j = 0; j < bmpdata.Width; j++)
                    {
                        if (ptr[0] == 0 && ptr[1] == 0 && ptr[2] == 0)
                        {
                            coin.XStart = ptr;
                            Methods.FindCoinEnd(image, coin, ptr+3, j, bmpdata);
                            flag = true;
                            break;
                        }
                        ptr += 3;
                    }
                    if (flag) break;
                }

                // stride the blank area
                ptr += bmpdata.Stride - bmpdata.Width * 3;
            }
        }

        unsafe
        public static void FindCoinEnd(Bitmap image, Coin coin, byte* startPtr, int startIndex, BitmapData bmpdata)
        {
            int tolerance = 0;
            unsafe
            {
                for (int j = startIndex; j < bmpdata.Width; j++)
                {
                    if (startPtr[0] == 0 && startPtr[1] == 0 && startPtr[2] == 0)
                    {
                        coin.XEnd = startPtr;
                        return;
                    }

                    startPtr += 3;
                }

                // stride the blank area
                startPtr += bmpdata.Stride - bmpdata.Width * 3;
            }
        }
    }
}

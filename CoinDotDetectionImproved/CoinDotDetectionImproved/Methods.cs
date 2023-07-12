using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace CoinDotDetectionImproved
{
    internal class Methods
    {
        public Form1? Form { get; set; }
        public Methods(Form1 form) { Form = form; }
        public Methods() { }

        public static List<Coin> DetectCoins(byte[] source, int imageWidth)
        {
            Coin coin1 = new(imageWidth), coin2 = new(imageWidth);

            FindCoin(source, coin1, 0, true);
            FindCoin(source, coin2, coin1.EndX, false);

            return new List<Coin>() {
                coin1,
                coin2
            };
        }

        private static void FindCoin(byte[] source, Coin coin, int startIndex, bool findFirst)
        {
            for (int i = startIndex; i < source.Length; i += 3)
            {
                if (source[i] == 255 && source[i + 1] == 255 & source[i + 2] == 255)
                {
                    if (findFirst)
                    {
                        /* If found the white pixel, its the coin's upper top point */

                        // Assign upper top point to StartY
                        coin.StartY = i;

                        // Find height of the coin
                        coin.Height = FindHeight(source, coin, i);

                        // Find the width using Y coordinates
                        coin.Width = FindWidth(source, coin);

                        // Break the loop
                        return;
                    }
                    else
                    {
                        /* If found the white pixel, its the second coin's middle left */

                        // Assign middle left to StartX
                        coin.StartX = i;

                        // Find width if the coin
                        coin.Width = FindWidth(source, coin, i);

                        // Find height using X coordinates
                        coin.Height = FindHeight(source, coin);

                        // Break the loop
                        return;
                    }
                }
            }
        }

        private static int FindHeight(byte[] source, Coin coin, int startIndex)
        {
            int i = 1, height = 0, tolerance = 0;
            int currentByte;

            do
            {
                i++;

                // Iterating to vertically next byte
                currentByte = startIndex + (i * coin.ImageWidth * 3);

                // If found a black pixel, means its end of the coin
                if (source[currentByte] == 0 && source[currentByte + 1] == 0 && source[currentByte + 2] == 0)
                {
                    if (tolerance > 50)
                    {
                        coin.EndY = currentByte;
                        return height;
                    }
                    tolerance++;
                }

                // Else, increase the height
                height++;

            } while (true);

        }

        private static int FindHeight(byte[] source, Coin coin)
        {
            int currentByte, height = 0, i = 0;
            int middle = coin.EndX - ((coin.Width / 2) * 3);

            do
            {
                i++;

                // Iterating to vertically next byte, starting from middle of the width of the coin
                currentByte = middle + (i * coin.ImageWidth * 3);

                if (source[currentByte] == 0 && source[currentByte + 1] == 0 && source[currentByte + 2] == 0)
                {
                    coin.EndY = currentByte;
                    coin.StartY = coin.EndY - (i * coin.ImageWidth * 3) * 2;
                    return height;
                }

                // Increasing by two because its starting from half way
                height += 2;
            } while (true);

        }

        private static int FindWidth(byte[] source, Coin coin)
        {
            int currentByte, width = 0, i = 0;
            int middle = coin.EndY - ((coin.Height / 2) * coin.ImageWidth * 3);

            do
            {
                i++;

                currentByte = middle + (i * 3);

                if (source[currentByte] == 0 && source[currentByte + 1] == 0 && source[currentByte + 2] == 0)
                {
                    coin.EndX = currentByte;
                    coin.StartX = coin.EndX - width * 3;
                    return width;
                }

                // Increasing by two because its starting from half way
                width += 2;
            } while (true);

        }

        private static int FindWidth(byte[] source, Coin coin, int startIndex)
        {
            int i = 1, width = 0;
            int currentByte;

            do
            {
                i++;

                // Iterating to horizontally next byte
                currentByte = startIndex + (i * 3);

                // If found a black pixel, means its end of the coin
                if (source[currentByte] == 0 && source[currentByte + 1] == 0 && source[currentByte + 2] == 0)
                {
                    coin.EndX = currentByte;
                    return width;
                }

                // Else, increase the width
                width++;
            } while (true);

        }

        public static bool BlackSequenceHorizontal(byte[] source, int startIndex, int length)
        {
            int currentByte, counter = 0;

            // Iterate length times but start from 1 to don't count the init pixel
            for (int i = 1; i < length + 1; i++)
            {
                // Iterate through horizontally next byte
                currentByte = startIndex + (i * 3);

                // If image ends, break the loop
                if (currentByte > source.Length - 3) break;

                // If current pixel is black, increase the counter
                if (source[currentByte] == 0 && source[currentByte + 1] == 0 && source[currentByte + 2] == 0)
                    counter++;
            }

            // If black byte number is >= to lenght, means there is black sequence
            return counter >= length / 1.5;
        }

        public static bool BlackSequenceVertical(byte[] source, int startIndex, int length, int width)
        {
            int counter = 0;
            int currentByte;

            // Iterate length times but start from 1 to don't count the init pixel
            for (int i = 1; i <= length + 1; i++)
            {
                // Iterate through vertically next byte
                currentByte = startIndex + (i * width * 3);

                // If image ends, break the loop
                if (currentByte > source.Length) break;

                // If current byte is black, increase the counter
                if (source[currentByte] == 0 && source[currentByte + 1] == 0 && source[currentByte + 2] == 0)
                    counter++;
            }

            // If black pixel number is >= to lenght, means there is black pixels sequence
            return counter >= length;
        }

        /// <summary>
        /// Converting bitmap to byte array
        /// </summary>
        /// <param name="bitmap"> Bitmap source to copy </param>
        /// <returns> Byte array of the bitmap </returns>
        public static byte[] BitmapToBytes(Bitmap bitmap)
        {
            // Creating rectangle using bitmap's width and height
            Rectangle rect = new(0, 0, bitmap.Width, bitmap.Height);

            // Locking the bitmap bits
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            // Calculating byte array size using stride and height
            // Stride: number of bytes which are stored in a single row of the bitmap (width+padding)
            int byteCount = bitmapData.Stride * bitmap.Height;

            // Creating byte array
            byte[] bytes = new byte[byteCount];

            // Copying bitmap data to byte array using its address
            // Scan0: Beginning address of bitmapData
            Marshal.Copy(bitmapData.Scan0, bytes, 0, byteCount);

            // Unlocking bits
            bitmap.UnlockBits(bitmapData);

            // Returning byte array
            return bytes;
        }

        /// <summary>
        /// Converting byte array to Bitmap object
        /// </summary>
        /// <param name="bytes"> Byte array source </param>
        /// <param name="bmpFormat"> Bitmap pixel format </param>
        /// <param name="width"> Bitmap image width </param>
        /// <param name="height"> Bitmap image height </param>
        /// <returns> Bitmap object with given byte array source </returns>
        public static Bitmap ByteToBitmap(byte[] bytes, PixelFormat bmpFormat, int width, int height)
        {

            // Initializing bitmap and rectangle
            Bitmap bmp = new(width, height, bmpFormat);
            Rectangle rect = new Rectangle(0, 0, width, height);

            // Locking bitmap bits
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmpFormat);

            // Copying byte array into bitmap
            Marshal.Copy(bytes, 0, bmpData.Scan0, bytes.Length);

            // Unlocking bits
            bmp.UnlockBits(bmpData);

            // Returning bitmap object
            return bmp;
        }

        public static List<byte> FindBackground(byte[] source, int length)
        {
            // Implemented correctly, but not works properly / as expected
            int totalR = 0, totalG = 0, totalB = 0;

            for (int i = 0; i < length; i += 3)
            {
                totalR += source[i];
                totalG += source[i + 1];
                totalB += source[i + 2];
            }

            return new List<byte> {
                (byte)(source[0]/2),
                (byte)(source[1]/2),
                (byte)(source[2]/2)
            };

        }

        public static int[] GetCoordinate(int x, int width)
            => new int[] { (x / 3) % width, (x / 3) / width };
    }
}

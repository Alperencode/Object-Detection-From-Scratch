using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace CoinDotDetectionImproved
{
    internal class Methods
    {
        public static int HeightTolerance { get; set; }
        public static int WidthTolerance { get; set; }
        /// <summary>
        /// Detecting coins in given image
        /// </summary>
        /// <param name="source"> Byte array that represents image </param>
        /// <param name="imageWidth"> Image's width </param>
        /// <returns> List of coins in image as Coin object </returns>
        public static List<Coin> DetectCoins(byte[] source, Bitmap image)
        {
            // Initializing two Coin instance
            Coin
            coin1 = new(image.Width),
            coin2 = new(image.Width);

            // Calling FindCoin method for both instances
            FindCoin(source, coin1, 0, true);
            FindCoin(source, coin2, coin1.EndX, false);

            // Drawing rectangles for both coins
            coin1.DrawRectangle(image);
            coin2.DrawRectangle(image);

            // Drawing width and height lines for both coins
            coin1.DrawWidthAndHeightLines(image);
            coin2.DrawWidthAndHeightLines(image);

            // Returning Coin list
            return new List<Coin>() {
                coin1,
                coin2
            };
        }

        /// <summary>
        /// Finds one coin in image
        /// </summary>
        /// <param name="source"> Byte array that represents image </param>
        /// <param name="coin"> Coin object to assign found values </param>
        /// <param name="startIndex"> Beginning index to start scanning given byte array </param>
        /// <param name="findFirst"> Bool that determines if the coin is the first one or not </param>
        private static void FindCoin(byte[] source, Coin coin, int startIndex, bool findFirst)
        {
            // Traversing byte array
            for (int i = startIndex; i < source.Length; i += 3)
            {
                // If find any white pixel, means found the coin
                if (source[i] == 255 && source[i + 1] == 255 & source[i + 2] == 255)
                {
                    if (findFirst)
                    {
                        /* If found the white pixel for first coin, its the coin's upper top point */

                        // Assign upper top point to StartY
                        coin.StartY = i;

                        // Find height of the coin
                        coin.Height = FindHeight(source, coin, i);

                        // Find the width using height
                        coin.Width = FindWidth(source, coin);

                        // Break the loop
                        return;
                    }
                    else
                    {
                        /* If found the white pixel for second coin, its the second coin's middle left */

                        // Assign middle left to StartX
                        coin.StartX = i;

                        // Find width if the coin
                        coin.Width = FindWidth(source, coin, i);

                        // Find height using width
                        coin.Height = FindHeight(source, coin);

                        // Break the loop
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Finding height using given startIndex
        /// </summary>
        /// <param name="source"> Byte array that represents image </param>
        /// <param name="coin"> Coin object to assign found values </param>
        /// <param name="startIndex"> Beginning index to start scanning given byte array </param>
        /// <returns> Height of the coin </returns>
        private static int FindHeight(byte[] source, Coin coin, int startIndex)
        {
            // Initializing current byte, i for while loop, height counter and pixel tolerance
            int currentByte, i = 1,
            height = 0, tolerance = 0;

            do
            {
                i++;

                // Iterating to vertically next byte
                currentByte = startIndex + (i * coin.ImageWidth * 3);

                // If found a black pixel, means its end of the coin
                if (source[currentByte] == 0 && source[currentByte + 1] == 0 && source[currentByte + 2] == 0)
                {
                    // If tolerance limit is exceeds the limit
                    if (tolerance > Methods.HeightTolerance)
                    {
                        // Assign values and return height
                        coin.EndY = currentByte;
                        return height;
                    }
                    // Else increase tolerance counter
                    tolerance++;
                }

                // Otherwise, means still on white pixel so increase the height
                height++;

            } while (true);

        }

        /// <summary>
        /// Finding height starting from middle of the coin's width
        /// </summary>
        /// <param name="source"> Byte array that represents image </param>
        /// <param name="coin"> Coin object to assign found values </param>
        /// <returns> Height of the coin </returns>
        private static int FindHeight(byte[] source, Coin coin)
        {
            // Initializing current byte, i for while loop and height counter
            int currentByte, i = 0, height = 0;

            // Calculating middle of width
            int middle = coin.EndX - ((coin.Width / 2) * 3);

            do
            {
                i++;

                // Iterating to vertically next byte, starting from middle of the width
                currentByte = middle + (i * coin.ImageWidth * 3);

                // If pixel is black, means its the end of the coin
                if (source[currentByte] == 0 && source[currentByte + 1] == 0 && source[currentByte + 2] == 0)
                {
                    // Assign values and return height
                    coin.EndY = currentByte;
                    coin.StartY = coin.EndY - (i * coin.ImageWidth * 3) * 2;
                    return height;
                }

                // Increasing by two because its starting from half way
                height += 2;
            } while (true);

        }

        /// <summary>
        /// Finding width using given startIndex
        /// </summary>
        /// <param name="source"> Byte array that represents image </param>
        /// <param name="coin"> Coin object to assign found values </param>
        /// <param name="startIndex"> Beginning index to start scanning given byte array </param>
        /// <returns> Width of the coin </returns>
        private static int FindWidth(byte[] source, Coin coin, int startIndex)
        {
            int currentByte, i = 1, width = 0, tolerance = 0;

            do
            {
                i++;

                // Iterating to horizontally next byte
                currentByte = startIndex + (i * 3);

                // If found a black pixel, means its end of the coin
                if (source[currentByte] == 0 && source[currentByte + 1] == 0 && source[currentByte + 2] == 0)
                {
                    // If tolerance limit is exceeds the limit
                    if (tolerance > Methods.WidthTolerance)
                    {
                        // Assigning values and return width
                        coin.EndX = currentByte;
                        return width;
                    }
                    // Else increase tolerance counter
                    tolerance++;
                }

                // Else, increase the width
                width++;
            } while (true);

        }

        /// <summary>
        /// Finding width starting from middle of the coin's height
        /// </summary>
        /// <param name="source"> Byte array that represents image </param>
        /// <param name="coin"> Coin object to assign found values </param>
        /// <returns> Width of the coin </returns>
        private static int FindWidth(byte[] source, Coin coin)
        {
            // Initializing current byte, i for while loop and height counter
            int currentByte, i = 0, width = 0;

            // Calculating middle of height
            int middle = coin.EndY - ((coin.Height / 2) * coin.ImageWidth * 3);

            do
            {
                i++;

                // Iterating to horizontally next byte
                currentByte = middle + (i * 3);

                // If found a black pixel, means its end of the coin
                if (source[currentByte] == 0 && source[currentByte + 1] == 0 && source[currentByte + 2] == 0)
                {
                    // Assign values and return width
                    coin.EndX = currentByte;
                    coin.StartX = coin.EndX - width * 3;
                    return width;
                }

                // Increasing by two because its starting from half way
                width += 2;
            } while (true);

        }

        /// <summary>
        /// Checks if there is any black pixel sequence in given length in horizontal axis
        /// </summary>
        /// <param name="source"> Byte array that represents image </param>
        /// <param name="startIndex"> Coin object to assign found values </param>
        /// <param name="length"> Length of black sequence </param>
        /// <returns> True if there is black sequence of pixel, otherwise false </returns>
        public static bool BlackSequenceHorizontal(byte[] source, int startIndex, int length)
        {
            // Initializing current byte and counter to count down black pixels
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

        /// <summary>
        /// Checks if there is any black pixel sequence in given length in vertical axis
        /// </summary>
        /// <param name="source"> Byte array that represents image </param>
        /// <param name="startIndex"> Coin object to assign found values </param>
        /// <param name="length"> Length of black sequence </param>
        /// <returns> True if there is black sequence of pixel, otherwise false </returns>
        public static bool BlackSequenceVertical(byte[] source, int startIndex, int length, int width)
        {
            int currentByte, counter = 0;

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
            return counter >= length / 1.5;
        }

        /// <summary>
        /// Converts bitmap to byte array
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
        /// Converts byte array to Bitmap object
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

        /// <summary>
        /// Calcualates average RGB of given byte array by scanning array's given length
        /// </summary>
        /// <param name="source"> Byte array that represents image </param>
        /// <param name="length"> Length of bytes to scan </param>
        /// <returns> Byte array that represents the average of background RGB, respectively. </returns>
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

        /// <summary>
        /// X and Y coordinates of given byte array index
        /// </summary>
        /// <param name="index"> Index of the byte </param>
        /// <param name="width"> Image width for calculation </param>
        /// <returns> Integer array that respectively represents x and y axis </returns>
        public static int[] GetCoordinate(int index, int width)
            => new int[] { (index / 3) % width, (index / 3) / width };
    }
}

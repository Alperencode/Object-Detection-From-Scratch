using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace CoinDotDetectionImproved
{
    internal class ByteArrayMethods
    {
        public Form1? form { get; set; }
        public ByteArrayMethods(Form1 form)
        {
            this.form = form;
        }
        public ByteArrayMethods() { }

        public int FindHeight(byte[] source, int startIndex, int width)
        {
            int currentByte, currentHeight;
            int maxHeight = -1;

            for (int i = startIndex; ; i++)
            {
                // Iterating to vertically next byte
                currentByte = startIndex + (i * width * 3);

            }

            return 0;
        }

        public int FindWidth(byte[] source, int startIndex, int height)
        {
            /*
            int currentWidth, current;
            int maxWidth = 0;

            for (int i = 0; ; i++)
            {
                current = startIndex + (i * width * 3);
            }
            */
            return 0;
        }

        public bool BlackSequenceHorizontal(byte[] source, int startIndex, int length)
        {
            int counter = 0;
            int currentByte;

            // Iterate length times but start from 1 to don't count the init pixel
            for (int i = 1; i <= length + 1; i++)
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
            return counter >= length / 1.5 ;
        }

        public bool BlackSequenceVertical(byte[] source, int startIndex, int length, int width)
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
        public byte[] BitmapToBytes(Bitmap bitmap)
        {
            // Creating rectangle using bitmap's width and height
            Rectangle rect = new(0, 0, bitmap.Width, bitmap.Height);

            // Locking the bitmap bits
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            // Calculating byte array size using stride and height
            // Stride: number of bytes which are stored in a single row of the bitma (width+padding)
            int byteCount = bitmapData.Stride * bitmap.Height;

            // Creating byte array
            byte[] bytes = new byte[byteCount];

            // Copying bitmap data to byte array using its address
            // Scan0: Address of bitmapData
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
        public Bitmap ByteToBitmap(byte[] bytes, PixelFormat bmpFormat, int width, int height)
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

        public Color FindBackground(byte[] source, int length)
        {
            int totalR = 0;
            int totalG = 0;
            int totalB = 0;

            for (int i = 0; i < length - 2; i += 3)
                (totalR, totalG, totalB) = (source[i], source[i + 1], source[i + 2]);

            return Color.FromArgb(totalR / 2, totalG / 2, totalB / 2);
        }
    }
}

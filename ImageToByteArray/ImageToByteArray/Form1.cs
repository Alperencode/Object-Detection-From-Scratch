using System.Collections;
using System.Drawing.Imaging;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ImageToByteArray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // AllocConsole();

            // Coins: 2ms
            // CoinsLarge: 4ms
            // byte[] file2 = ConvertToByteArrayChunked("Coins.jpeg");

            // Coins: 1ms
            // CoinsLarge: 2ms
            // byte[] FileByteArray = File.ReadAllBytes("Coins.jpeg");

            Bitmap image = new("Coins2.jpeg");

            byte[] byteArr = BitmapToBytes(image);

            for (int i = 0; i < byteArr.Length; i++)
            {
                // If byte value is bigger than 100: set to max
                if (byteArr[i] > 200)
                    byteArr[i] = 255;
                // Else: set to min
                else
                    byteArr[i] = 0;
            }

            Bitmap newImage = BitmapFromBytes(byteArr, image.PixelFormat, image.Width, image.Height);

            // MemoryStream ms = new(FileByteArray);
            // Image imageFromMs = Image.FromStream(ms);
            picture.Image = newImage;
        }

        // Allocating Console to Debug
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        

        // Converting file to byte array using chunks
        public static byte[] ConvertToByteArrayChunked(string filePath)
        {
            // Chunk size is set to 2048 bytes
            const int MaxChunkSizeInBytes = 2048;

            // Initializing total bytes and byte array
            var totalBytes = 0;
            byte[] fileByteArray;

            // Creating chunk array using chunk size
            var fileByteArrayChunk = new byte[MaxChunkSizeInBytes];

            // Opening file
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int bytesRead;

                /* Read Document
                 * Read(byte[], int, int)
                 * Respectively: buffer, offset, count
                 */

                // Buffer is: fileByteArrayChunk, offset is: 0, count is: fileByteArrayChunk.Length
                // Reads until end of the stream has been reached
                while ((bytesRead = stream.Read(fileByteArrayChunk, 0, fileByteArrayChunk.Length)) > 0)
                    // Adding current byte to total bytes
                    totalBytes += bytesRead;

                // Assigning total bytes to fileBiteArray
                fileByteArray = new byte[totalBytes];

                // Reseting the position of the stream
                // Because we added each chunk to the end of the array
                stream.Seek(0, SeekOrigin.Begin);

                // Reading bytes from fileByteArray, starting from 0, length of totalBytes
                stream.Read(fileByteArray, 0, totalBytes);
            }
            return fileByteArray;
        }

        //  Converting bitmap to byte array
        public static byte[] BitmapToBytes(Bitmap bmp)
        {
            // Creating rectangle using bitmap's width and height
            Rectangle rect = new(0, 0, bmp.Width, bmp.Height);

            // Locking the bitmap bits
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);

            // Calculating byte array size using stride and height
            int byteCount = Math.Abs(bmpData.Stride) * bmp.Height;

            // Creating byte array
            byte[] bytes = new byte[byteCount];

            // Copying bitmap to byte array
            Marshal.Copy(bmpData.Scan0, bytes, 0, byteCount);

            // Unlocking bits
            bmp.UnlockBits(bmpData);

            // Returning byte array
            return bytes;
        }

        // Converting byte array to bitmap
        public static Bitmap BitmapFromBytes(byte[] bytes, PixelFormat bmpFormat, int width, int height)
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
    }
}
using System.Runtime.InteropServices;

namespace CoinDotDetectionImproved
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            // Initialize methods object
            ByteArrayMethods methods = new();

            // Load image as bitmap
            // 6ms
            Bitmap image = new("Coins.jpeg");

            // Convert image's bitmap to byte array
            // 2ms
            byte[] byteArr = methods.BitmapToBytes(image);

            Color backgroundColor = methods.FindBackground(byteArr, byteArr.Length/10);

            int stride = byteArr.Length - (image.Height * image.Width * 3);
            // Convert image to black and white
            // 10 ms
            for (int i = 0; i < byteArr.Length - 2; i += 3)
            {
                // If byte value is bigger than 100: set to min
                if (byteArr[i] >= backgroundColor.R && byteArr[i + 1] >= backgroundColor.G && byteArr[i + 2] >= backgroundColor.B)
                {
                    for (int j = 0; j < 3; j++)
                        byteArr[i + j] = 0;
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                        byteArr[i + j] = 255;
                }
            }

            /*
            for (int i = 0; i < byteArr.Length - 2; i+=3)
            {
                // If pixel is white and there is no black sequence, turn next sequence white and iterate through next sequence's pixel
                if (byteArr[i] == 0 && byteArr[i + 1] == 0 && byteArr[i + 2] == 0)
                    if (!methods.BlackSequenceHorizontal(byteArr, i, 50))
                        (byteArr[i], byteArr[i+1], byteArr[i+2]) = (255,255,255);

                // If any of bytes are max but there is black sequence, set byte to min
                if (byteArr[i] == 255 && byteArr[i + 1] == 255 && byteArr[i + 2] == 255)
                    if (methods.BlackSequenceHorizontal(byteArr, i, 50))
                        (byteArr[i], byteArr[i + 1], byteArr[i + 2]) = (0, 0, 0);
            }
            */

            /*
            int height = 0;
            for (int i = 0; i < byteArr.Length - 2; i+=3)
            {
                if (byteArr[i] > 0 && byteArr[i + 1] > 0 && byteArr[i + 2] > 0)
                {
                    
                    if (!methods.BlackSequenceVertical(byteArr, i, 30, image.Width))
                    {
                        // Found the coin
                        height = i;
                        break;
                    }
                }
            }
            */

            // AllocConsole();
            // Console.WriteLine(height);

            // 2ms
            Bitmap newImage = methods.ByteToBitmap(byteArr, image.PixelFormat, image.Width, image.Height);

            picture.Image = newImage;
        }

        // Allocating Console to Debug
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
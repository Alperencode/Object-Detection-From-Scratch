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
            Bitmap image = new("CoinsLarge.jpeg");

            int Width = image.Width;

            // Convert image's bitmap to byte array
            // 2ms
            byte[] source = methods.BitmapToBytes(image);

            Color backgroundColor = methods.FindBackground(source, source.Length / 10);

            // Convert image to black and white
            // 10 ms
            for (int i = 0; i < source.Length - 2; i += 3)
            {

                // Making background black
                // If byte value is bigger than background RGB: set next RGB to min
                if (source[i] >= backgroundColor.R && source[i + 1] >= backgroundColor.G && source[i + 2] >= backgroundColor.B)
                    for (int j = 0; j < 3; j++)
                        source[i + j] = 0;

                // Making coins white
                // Else, set next RGB to max
                else
                    for (int j = 0; j < 3; j++)
                        source[i + j] = 255;
            }

            // Clearing out the pixels
            // 85-90ms
            for (int i = 0; i < source.Length - 2; i += 3)
            {
                // If the pixel is black but there is no black sequence, turn pixel to white
                if (source[i] == 0 && source[i + 1] == 0 && source[i + 2] == 0)
                    if (!methods.BlackSequenceHorizontal(source, i, 100))
                        (source[i], source[i + 1], source[i + 2]) = (255, 255, 255);

                // If any of bytes are max but there is black sequence, set byte to min
                if (source[i] == 255 || source[i + 1] == 255 || source[i + 2] == 255)
                    if (methods.BlackSequenceHorizontal(source, i, 100))
                        (source[i], source[i + 1], source[i + 2]) = (0, 0, 0);
            }

            List<Coin> coins = methods.DetectCoins(source, Width);

            /* DEBUG SECTION */
            AllocConsole();
            int[] C1X1 = coins[0].GetCoordinateXStart();
            int[] C2X1 = coins[1].GetCoordinateXStart();

            int[] C1X2 = coins[0].GetCoordinateXEnd();
            int[] C2X2 = coins[1].GetCoordinateXEnd();
                
            int[] C1Y1 = coins[0].GetCoordinateYStart();
            int[] C2Y1 = coins[1].GetCoordinateYStart();

            int[] C1Y2 = coins[0].GetCoordinateYEnd();
            int[] C2Y2 = coins[1].GetCoordinateYEnd();

            Pen pen = new(Color.Red, 30), pen2 = new(Color.Green, 30);

            using (var graphics = Graphics.FromImage(image))
            {
                graphics.DrawLine(pen, C1X1[0], C1X1[1], C1X2[0], C1X2[1]);
                graphics.DrawLine(pen2, C2X1[0], C2X1[1], C2X2[0], C2X2[1]);

                graphics.DrawLine(pen, C1Y1[0], C1Y1[1], C1Y2[0], C1Y2[1]);
                graphics.DrawLine(pen2, C2Y1[0], C2Y1[1], C2Y2[0], C2Y2[1]);
            }

            picture2.Image = image;
            /* DEBUG SECTION END */

            // 2ms
            Bitmap newImage = methods.ByteToBitmap(source, image.PixelFormat, image.Width, image.Height);

            picture.Image = newImage;
        }

        // Allocating Console to Debug
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
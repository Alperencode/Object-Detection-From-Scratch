namespace CoinDotDetectionImproved
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) => Main();

        private void Main()
        {

            // Load image as bitmap
            // 6ms
            Bitmap image = new("CoinsLarge.jpeg");

            int Width = image.Width;

            // Convert image's bitmap to byte array
            // 2ms
            byte[] source = Methods.BitmapToBytes(image);

            Color backgroundColor = Methods.FindBackground(source, source.Length / 10);

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
                    if (!Methods.BlackSequenceHorizontal(source, i, 35))
                        (source[i], source[i + 1], source[i + 2]) = (255, 255, 255);

                // If any of bytes are max but there is black sequence, set byte to min
                if (source[i] == 255 || source[i + 1] == 255 || source[i + 2] == 255)
                    if (Methods.BlackSequenceHorizontal(source, i, 35))
                        (source[i], source[i + 1], source[i + 2]) = (0, 0, 0);
            }

            List<Coin> coins = Methods.DetectCoins(source, Width);

            /* DEBUG SECTION */

            Pen pen = new(Color.Red, 25);

            // Draw rectangles
            using (var graphics = Graphics.FromImage(image))
            {
                graphics.DrawRectangle(pen, coins[0].GetRectangle());
                graphics.DrawRectangle(pen, coins[1].GetRectangle());
            }

            // Draw width and height lines for both coins
            coins[0].DrawWidthLine(image);
            coins[0].DrawHeightLine(image);

            coins[1].DrawWidthLine(image);
            coins[1].DrawHeightLine(image);

            // Place the debug image
            picture2.Image = image;
            /* DEBUG SECTION END */

            // 2ms
            Bitmap newImage = Methods.ByteToBitmap(source, image.PixelFormat, image.Width, image.Height);

            picture.Image = newImage;
        }
    }
}
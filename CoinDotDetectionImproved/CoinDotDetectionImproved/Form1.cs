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
            // Ms timings wrote for 750x1000 image

            // Load image as bitmap
            // 6ms
            Bitmap image = new("CoinsLarge.jpeg");
            Bitmap originalImage = new("CoinsLarge.jpeg");

            // Assigning image width to local variable
            int Width = image.Width;

            // Convert image's bitmap to byte array
            // 2ms
            byte[] source = Methods.BitmapToBytes(image);

            // Assigning first 3 bytes as background color (Can change later)
            // 1ms
            List<byte> backgroundColor = new() {
                (byte)(source[0]/2),
                (byte)(source[1]/2),
                (byte)(source[2]/2)
            };

            // Convert image to black and white
            // 10 ms
            for (int i = 0; i < source.Length - 2; i += 3)
            {

                // If byte value is bigger than background RGB: set next RGB to min
                // Making background black
                if (source[i] >= backgroundColor[0] && source[i + 1] >= backgroundColor[1] && source[i + 2] >= backgroundColor[2])
                    for (int j = 0; j < 3; j++)
                        source[i + j] = 0;

                // Else, set next RGB to max
                // Making everything else white (coins)
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

            // Drawing rectangles for both coins
            coins[0].DrawRectangle(image);
            coins[1].DrawRectangle(image);

            // Drawing width and height lines for both coins
            coins[0].DrawWidthAndHeightLines(image);
            coins[1].DrawWidthAndHeightLines(image);

            Bitmap
            coin1 = coins[0].CropCoinFromImage(originalImage),
            coin2 = coins[1].CropCoinFromImage(originalImage);

            Bitmap coinWithdot = FindDot.FindCoinWithDot(coin1, coin2);

            // Place the image with drawings
            Picture2.Image = image;
            Coin1Picture.Image = coin1;
            Coin2Picture.Image = coin2;
            CoinWithDotPicture.Image = coinWithdot;


            // 2ms
            Bitmap newImage = Methods.ByteToBitmap(source, image.PixelFormat, image.Width, image.Height);

            Picture1.Image = newImage;
        }

        private void newSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.Show();
        }
    }
}
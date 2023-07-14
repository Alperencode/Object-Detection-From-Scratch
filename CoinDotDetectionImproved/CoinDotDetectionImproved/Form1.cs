using System.Runtime.Versioning;

namespace CoinDotDetectionImproved
{
    public partial class Form1 : Form
    {
        public int BlackSequenceLength { get; set; }
        public int HeightTolerance { get; set; }
        public int WidthTolerance { get; set; }
        public string FilePath { get; set; }

        public Form1()
        {
            InitializeComponent();

            // Assignin optimal initial values
            BlackSequenceLength = 25;
            Methods.HeightTolerance = 50;
            Methods.WidthTolerance = 0;
            FilePath = "CoinsLarge.jpeg";
        }

        private void Form1_Load(object sender, EventArgs e) => Main(FilePath);

        [SupportedOSPlatform("windows")]
        public void Main(string filePath)
        {
            // Ms timings wrote for 750x1000 image

            // Load image as bitmap
            // 6ms (87ms for 3024x4032 image)
            Bitmap image = new(filePath);
            Bitmap originalImage = new(filePath);

            // Assigning image width to local variable
            int Width = image.Width;

            // Convert image's bitmap to byte array
            // 2ms (11ms for 3024x4032 image)
            byte[] source = Methods.BitmapToBytes(image);

            // Assigning first 3 bytes as background color (Can change later)
            // 1ms
            List<byte> backgroundColor = new() {
                (byte)(source[0]/2),
                (byte)(source[1]/2),
                (byte)(source[2]/2)
            };

            // Convert image to black and white
            // 10 ms (135 - 145ms for 3024x4032 image)
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
            // 99ms (1.5k ms for 3024x4032 image)
            for (int i = 0; i < source.Length - 2; i += 3)
            {
                // If the pixel is black but there is no black sequence, turn pixel to white
                if (source[i] == 0 && source[i + 1] == 0 && source[i + 2] == 0)
                    if (!Methods.BlackSequenceHorizontal(source, i, BlackSequenceLength))
                        (source[i], source[i + 1], source[i + 2]) = (255, 255, 255);

                // If any of bytes are max but there is black sequence, set byte to min
                if (source[i] == 255 && source[i + 1] == 255 && source[i + 2] == 255)
                    if (Methods.BlackSequenceHorizontal(source, i, BlackSequenceLength))
                        (source[i], source[i + 1], source[i + 2]) = (0, 0, 0);
            }

            // Detecting coins and assigning them to Coin list
            // 5ms (12ms for 3024x4032 image)
            List<Coin> coins = Methods.DetectCoins(source, image);

            // Creating cropped bitmaps for both coin
            // 12ms (96ms for 3024x4032 image)
            Bitmap
            coin1 = coins[0].CropCoinFromImage(originalImage),
            coin2 = coins[1].CropCoinFromImage(originalImage);

            // 2ms
            ChangeDetectLabel(coin1, coin2, originalImage);

            // 5ms (8ms for 3024x4032 image)
            Bitmap coinWithdot = FindDot.FindCoinWithDot(coin1, coin2);

            // Place the image with drawings
            // 1ms
            Picture2.Image = image;
            Coin1Picture.Image = coin1;
            Coin2Picture.Image = coin2;
            CoinWithDotPicture.Image = coinWithdot;

            // 2ms
            Bitmap newImage = Methods.ByteToBitmap(source, image.PixelFormat, image.Width, image.Height);

            Picture1.Image = newImage;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this, FilePath);
            form.Show();
        }

        private void selectImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new();

            if (file.ShowDialog() == DialogResult.OK)
            {
                FilePath = file.FileName;
                Main(FilePath);
            }

        }

        private void ChangeDetectLabel(Bitmap coin1, Bitmap coin2, Bitmap image)
        {
            if (coin1.Width == image.Width || coin2.Width == image.Width)
            {
                DetectLabel.Text = "Coins not detected";
                DetectLabel.ForeColor = Color.Red;
            }
            else
            {
                DetectLabel.Text = "Coins detected";
                DetectLabel.ForeColor = Color.Green;
            }
        }
    }
}
using System.Drawing;
using static CoinDotDetection.DetectCoins;
using static System.Net.Mime.MediaTypeNames;

namespace CoinDotDetection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadImage()
        {
            Bitmap originalImage = new Bitmap("Coins.jpeg");
            Bitmap image = new Bitmap("Coins.jpeg");

            DetectCoins detectCoins = new DetectCoins();

            List<Rectangle> coins = detectCoins.DetecCoinsInImage(image);

            Pen redPen = new Pen(Color.Red, 3);
            foreach (Rectangle coin in coins)
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    // graphics.DrawRectangle(redPen, coin);
                }
            }

            Bitmap coin1 = originalImage.Clone(coins[0], originalImage.PixelFormat);
            Bitmap coin2 = originalImage.Clone(coins[1], originalImage.PixelFormat);

            FindDot findDot = new FindDot();

            Bitmap coinWithDot = findDot.FindCoinWithDot(coin1, coin2);

            CoinWithDotPictureBox.Image= coinWithDot;
            originalPictureBox.Image = image;
            coin1PictureBox.Image = coin1;
            coin2PictureBox.Image = coin2;

            Pen greenPen = new Pen(Color.Green, 15);
            foreach (Rectangle coin in coins)
            {
                using (var graphics = Graphics.FromImage(originalImage))
                {
                    graphics.DrawEllipse(greenPen, findDot.FindCoinWithDot(originalImage, coins[0], coins[1]));
                }
            }

            CoinComparePictureBox.Image = originalImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadImage();
        }
    }
}

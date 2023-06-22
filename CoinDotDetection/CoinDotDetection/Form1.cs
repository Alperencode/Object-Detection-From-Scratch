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
            Bitmap image = new Bitmap("Coins.jpeg");

            DetectCoins detectCoins = new DetectCoins();

            List<Rectangle> coins = detectCoins.DetecCoinsInImage(image);

            Pen pen = new Pen(Color.Red, 3);
            foreach (Rectangle coin in coins)
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    graphics.DrawRectangle(pen, coin);
                }
            }

            pictureBox.Image = image;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadImage();
        }
    }
}

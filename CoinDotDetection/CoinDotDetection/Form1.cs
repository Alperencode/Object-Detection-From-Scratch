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

            detectCoins.DetecCoinsInImage(image, this);

            pictureBox.Image = image;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadImage();
        }
    }
}

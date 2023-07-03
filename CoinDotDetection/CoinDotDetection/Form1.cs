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
            // Creating image bitmaps
            Bitmap originalImage = new("CoinsFlipped.jpeg");
            Bitmap image = new("CoinsFlipped.jpeg");

            // Initializing pens
            Pen redPen = new(Color.Red, 3);
            Pen greenPen = new(Color.Green, 15);

            // Creating DetectCoins instance
            DetectCoins detectCoins = new();

            // Calling DetectCoinsInImage function to detect coins and return Rectangle list
            List<Rectangle> coins = detectCoins.DetectCoinsInImage(image);

            // Drawing rectangle using coins
            var graphics = Graphics.FromImage(image);
            foreach (Rectangle coin in coins)
                graphics.DrawRectangle(redPen, coin);

            // Creating coin bitmaps using coins list
            Bitmap coin1 = originalImage.Clone(coins[0], originalImage.PixelFormat);
            Bitmap coin2 = originalImage.Clone(coins[1], originalImage.PixelFormat);

            // Creating findDot instance
            FindDot findDot = new();

            // Calling FindCoinWithDot and assigning it to bitmap var
            Bitmap coinWithDot = findDot.FindCoinWithDot(coin1, coin2);

            // Placing Picture Boxes
            CoinWithDotPictureBox.Image= coinWithDot;
            originalPictureBox.Image = image;
            coin1PictureBox.Image = coin1;
            coin2PictureBox.Image = coin2;

            // Drawing elipse to coin with dot
            graphics = Graphics.FromImage(originalImage);

            // Calling overrided FindCoinWithDot function to return Rectangle instance
            graphics.DrawEllipse(greenPen, findDot.FindCoinWithDot(originalImage, coins));

            // Placing coin with elipse image to picture box
            CoinComparePictureBox.Image = originalImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadImage();
        }
    }
}

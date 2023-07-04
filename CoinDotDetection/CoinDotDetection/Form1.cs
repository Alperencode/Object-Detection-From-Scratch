using System.Reflection.Metadata.Ecma335;

namespace CoinDotDetection
{
    public partial class Form1 : Form
    {

        // Initializing pens
        Pen redPen = new(Color.Red, 3);
        Pen greenPen = new(Color.Green, 10);

        public Form1()
        {
            InitializeComponent();
        }

        public void Main()
        {
            // Creating image bitmaps
            Bitmap originalImage = new("Coins.jpeg");
            Bitmap image = new("Coins.jpeg");

            // Creating DetectCoins instance
            DetectCoins detectCoins = new DetectCoins(image, this);

            // Calling DetectCoinsInImage function to detect coins and return Rectangle list
            List<Rectangle> coins = detectCoins.DetectCoinsInImage(image);

            // If there is no coin found, return (Error Handling)
            if(!coins.Any())
                return;

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
            CoinWithDotPictureBox.Image = coinWithDot;
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
            // Call Main function when Form loads
            Main();
        }

        // Update Trackbars value labels
        private void BSWTrackbar_Scroll(object sender, EventArgs e) => BSWTrackbarLabel.Text = BSWTrackbar.Value.ToString();
        private void BSHTrackbar_Scroll(object sender, EventArgs e) => BSHTrackbarLabel.Text = BSHTrackbar.Value.ToString();
        private void BSTrackbar_Scroll(object sender, EventArgs e) => BSTrackbarLabel.Text = BSTrackbar.Value.ToString();

        private void runButton_Click(object sender, EventArgs e)
        {
            // Call Main function when run button clicked
            Main();
        }

        public void ChangeDetectLabel(string text, Color color)
        {
            detectLabel.Text = text;
            detectLabel.ForeColor = color;
        }

        public int GetBSValue { get { return BSTrackbar.Value; } }
        public int GetBSWValue { get { return BSWTrackbar.Value; } }
        public int GetBSHValue { get { return BSHTrackbar.Value; } }
        public int GetPixelTolerance { get { return (int)pixelToleranceInput.Value; } }
        public int GetBackgroundScan { get { return (int)BackgroundScanInput.Value; } }
        
    }
}

using System.Drawing.Imaging;

namespace CoinDotDetectionUnsafePointer
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private void Main()
        {
            Bitmap image = new("CoinsLarge.jpeg");
            Bitmap originalImage = new("CoinsLarge.jpeg");
            Rectangle rec = new(0, 0, image.Width, image.Height);

            // Locking bits
            // BGR
            BitmapData bmpdata = image.LockBits(rec, ImageLockMode.ReadWrite, image.PixelFormat);

            // 4ms for 750x1000
            // 49ms for 3024x4032
            unsafe
            {
                // Gets the address of the first pixel data in the bitmap
                byte* ptr = (byte*)bmpdata.Scan0;

                for (int i = 0; i < bmpdata.Height; i++)
                    for (int j = 0; j < bmpdata.Width; j++)
                    {
                        if (ptr[0] > 100 && ptr[1] > 100 && ptr[2] > 100)
                            (ptr[0], ptr[1], ptr[2]) = (255, 255, 255);
                        else
                            (ptr[0], ptr[1], ptr[2]) = (0, 0, 0);
                        
                        // Iterate to next pixel
                        ptr += 3;
                    }

                // stride the blank area
                ptr += bmpdata.Stride - bmpdata.Width * 3;
            }

            Methods.DetectCoins(image, bmpdata);

            image.UnlockBits(bmpdata);

            picture1.Image = originalImage;
            picture2.Image = image;
        }

        private void Form1_Load_1(object sender, EventArgs e) => Main();
    }
}
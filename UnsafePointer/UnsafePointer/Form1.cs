using System.Drawing.Imaging;

namespace UnsafePointer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Main()
        {
            Bitmap image = new("CoinsLarge.jpeg");
            Bitmap originalImage = new("CoinsLarge.jpeg");
            Rectangle rec = new(0, 0, image.Width, image.Height);

            // Locking bits
            BitmapData bmpdata = image.LockBits(rec, ImageLockMode.ReadWrite, image.PixelFormat);

            // 4ms for 750x1000
            // 49ms for 3024x4032
            unsafe
            {
                // Gets the address of the first pixel data in the bitmap
                byte* ptr = (byte*)(bmpdata.Scan0);

                for (int i = 0; i < bmpdata.Height; i++)
                    for (int j = 0; j < bmpdata.Width; j++)
                    {
                        if (ptr[0] > 100 && ptr[1] > 100 && ptr[2] > 100)
                        {
                            ptr[0] = 255;
                            ptr[1] = 255;
                            ptr[2] = 255;
                        }
                        else
                        {
                            ptr[0] = 0;
                            ptr[1] = 0;
                            ptr[2] = 0;
                        }
                        ptr += 3;
                    }

                // stride the blank area
                ptr += bmpdata.Stride - bmpdata.Width * 3;
            }

            image.UnlockBits(bmpdata);
            picture1.Image = originalImage;
            picture2.Image = image;
        }

        private void Form1_Load(object sender, EventArgs e)
            => Main();
    }
}
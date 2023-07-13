using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace CoinDotDetectionImproved
{
    internal class Coin
    {
        private readonly Pen pen = new(Color.Green, 25);

        public Coin(Color color, int width)
        { 
            this.pen = new(color, 8);
            ImageWidth = width;
        }

        public Coin(int width) { ImageWidth = width; }

        public int ImageWidth { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }


        // Get x and y axis coordinates for properties
        public int[] GetCoordinateXStart() => Methods.GetCoordinate(StartX, ImageWidth);
        public int[] GetCoordinateXEnd() => Methods.GetCoordinate(EndX, ImageWidth);
        public int[] GetCoordinateYStart() => Methods.GetCoordinate(StartY, ImageWidth);
        public int[] GetCoordinateYEnd() => Methods.GetCoordinate(EndY, ImageWidth);

        public void DrawWidthLine(Bitmap image)
        {
            using var graphics = Graphics.FromImage(image);
            graphics.DrawLine(pen,
                GetCoordinateXStart()[0], GetCoordinateXStart()[1],
                GetCoordinateXEnd()[0], GetCoordinateXEnd()[1]
            );
        }

        public Rectangle GetRectangle() =>
            new(
                GetCoordinateXStart()[0],
                GetCoordinateYStart()[1],
                Width,
                Height
            );

        public Bitmap CropCoinFromImage(Bitmap image)
        {
            try
            {
                return image.Clone(GetRectangle(), image.PixelFormat);
            }
            catch(Exception)
            {
                return new Bitmap(image);
            }
        }

        public void DrawHeightLine(Bitmap image)
        {
            using var graphics = Graphics.FromImage(image);
            graphics.DrawLine(pen,
                GetCoordinateYStart()[0], GetCoordinateYStart()[1],
                GetCoordinateYEnd()[0], GetCoordinateYEnd()[1]
            );
        }

        public void DrawWidthAndHeightLines(Bitmap image)
        {
            DrawWidthLine(image);
            DrawHeightLine(image);
        }

        public void DrawRectangle(Bitmap image)
        {
            var graphics = Graphics.FromImage(image);
            graphics.DrawRectangle(pen, GetRectangle());
        }
    }
}

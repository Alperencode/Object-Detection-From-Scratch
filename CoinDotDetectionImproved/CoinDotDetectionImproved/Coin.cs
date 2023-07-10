using System.Drawing;

namespace CoinDotDetectionImproved
{
    internal class Coin
    {
        public Coin() { }
        public Coin(int width) { ImageWidth = width; }

        public int ImageWidth { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private readonly Pen pen = new(Color.Green, 15);


        // This section can be simplify
        public int[] GetCoordinateXStart() => Methods.GetCoordinate(StartX, ImageWidth);
        public int[] GetCoordinateXEnd() => Methods.GetCoordinate(EndX, ImageWidth);
        public int[] GetCoordinateYStart() => Methods.GetCoordinate(StartY, ImageWidth);
        public int[] GetCoordinateYEnd() => Methods.GetCoordinate(EndY, ImageWidth);

        /// <summary>
        /// Summary
        /// </summary>
        public void DrawWidthLine(Bitmap image)
        {
            using var graphics = Graphics.FromImage(image);
            graphics.DrawLine(pen,
                GetCoordinateXStart()[0], GetCoordinateXStart()[1],
                GetCoordinateXEnd()[0], GetCoordinateXEnd()[1]
            );
        }

        /// <summary>
        /// Summary
        /// </summary>
        public void DrawHeightLine(Bitmap image)
        {
            using var graphics = Graphics.FromImage(image);
            graphics.DrawLine(pen,
                GetCoordinateYStart()[0], GetCoordinateYStart()[1], 
                GetCoordinateYEnd()[0], GetCoordinateYEnd()[1]
            );
        }

        /// <summary>
        /// Summary
        /// </summary>
        public Rectangle GetRectangle() =>
            new(
                GetCoordinateXStart()[0],
                GetCoordinateYStart()[1],
                Width,
                Height
            );
    }
}

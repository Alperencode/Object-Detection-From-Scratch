namespace CoinDotDetectionImproved
{
    internal class Coin
    {
        public Coin() { }
        public Coin(int width) { imageWidth = width; }

        public int imageWidth { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        

        public int[] GetCoordinateXStart() => ByteArrayMethods.GetCoordinate(StartX, imageWidth);
        public int[] GetCoordinateXEnd() => ByteArrayMethods.GetCoordinate(EndX, imageWidth);
        public int[] GetCoordinateYStart() => ByteArrayMethods.GetCoordinate(StartY, imageWidth);
        public int[] GetCoordinateYEnd() => ByteArrayMethods.GetCoordinate(EndY, imageWidth);

        public Rectangle GetRectangle() =>
            new(
                GetCoordinateXStart()[0],
                GetCoordinateYStart()[1],
                Width,
                Height
            );
    }
}

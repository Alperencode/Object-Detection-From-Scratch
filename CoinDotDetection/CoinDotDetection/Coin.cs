namespace CoinDotDetection
{
    internal class Coin
    {
        public int xStart { get; set; }
        public int xEnd { get; set; }
        public int yStart { get; set; }
        public int yEnd { get; set; }
        public int tempX { get; set; }

        public Rectangle GetRectangle()
        {
            // Rectangle: x start, y start, width, height
            return new Rectangle(xStart, yStart, xEnd - xStart, yEnd - yStart);
        }

    }
}

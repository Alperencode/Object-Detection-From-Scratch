using System.Reflection;
using System.Runtime.CompilerServices;

namespace CoinDotDetection
{
    internal class Coin
    {
        public int xStart { get; set; }
        public int xEnd { get; set; }
        public int yStart { get; set; }
        public int yEnd { get; set; }
        public int tempX { get; set; }

        private int GetWidth() => xEnd - xStart;
        private int GetHeight() => yEnd - yStart;
        public bool CheckCoin()
        {
            if (GetWidth() <= 0 || GetHeight() <= 0)
                return true;
            return false;
        }

        public Rectangle GetRectangle()
        {
            // Rectangle: x start, y start, width, height
            return new Rectangle(xStart, yStart, GetWidth(), GetHeight());
        }

    }
}

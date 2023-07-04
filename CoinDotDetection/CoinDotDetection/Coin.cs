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

        /// <summary>
        /// Checks if width or height is negative to determine coin is valid or not
        /// </summary>
        /// <returns> True if coin is not valid, False if coin is valid </returns>
        public bool CheckCoin()
        {
            if (GetWidth() <= 0 || GetHeight() <= 0)
                return true;
            return false;
        }

        /// <summary>
        /// Rectangle of the coin
        /// </summary>
        /// <returns> Returns Rectangle object by calculating Width and Height </returns>
        public Rectangle GetRectangle()
        {
            // Rectangle: x start, y start, width, height
            return new Rectangle(xStart, yStart, GetWidth(), GetHeight());
        }

    }
}

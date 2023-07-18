namespace CoinDotDetectionUnsafePointer
{

    unsafe
    internal class Coin
    {
        public byte* XStart { get; set; }
        public byte* XEnd { get; set; }
        public byte* YStart { get; set; }
        public byte* YEnd { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}

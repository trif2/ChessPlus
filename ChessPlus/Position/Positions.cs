namespace ChessPlus.Positions
{
    internal abstract class Position 
    { 
        public int X { get; set; }
        public int Y { get; set; }
        public int Q { get; set; }
        public int R { get; set; }
        public int S { get; set; }
    }
    internal class HexPosition(int q = 0, int r = 0, int s = 0) : Position
    {
        public int Q { get; set; } = q;
        public int R { get; set; } = r;
        public int S { get; set; } = s;
    }
    internal class ClassicPosition(int x, int y) : Position
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
    }
}

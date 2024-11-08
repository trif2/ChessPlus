namespace ChessPlus.Coordinate
{
    internal abstract class Position {}
    internal class HexPosition(int q = 0, int r = 0, int s = 0) : Position
    {
        public int Q { get; set; } = q;
        public int R { get; set; } = r;
        public int S { get; set; } = s;

        
    }
    internal class SquarePosition(int x, int y) : Position
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
    }
}

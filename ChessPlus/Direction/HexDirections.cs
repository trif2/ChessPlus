using ChessPlus.Positions;

namespace ChessPlus.Direction
{
    internal static class HexDirections
    {
        public static readonly (int Q, int R, int S) Up = (0, 1, -1);
        public static readonly (int Q, int R, int S) Down = (0, -1, 1);
        public static readonly (int Q, int R, int S) UpLeft = (-1, 1, 0);
        public static readonly (int Q, int R, int S) DownRight = (1, -1, 0);
        public static readonly (int Q, int R, int S) UpRight = (1, 0, -1);
        public static readonly (int Q, int R, int S) DownLeft = (-1, 0, 1);
    }
}
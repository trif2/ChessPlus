namespace ChessPlus.Constants
{
    internal static class Directions
    {
        public static readonly Tuple<int, int, int> Up = new Tuple<int, int, int>(0, 1, -1);
        public static readonly Tuple<int, int, int> Down = new Tuple<int, int, int>(0, -1, 1);
        public static readonly Tuple<int, int, int> UpLeft = new Tuple<int, int, int>(-1, 1, 0);
        public static readonly Tuple<int, int, int> DownRight = new Tuple<int, int, int>(1, -1, 0);
        public static readonly Tuple<int, int, int> UpRight = new Tuple<int, int, int>(1, 0, -1);
        public static readonly Tuple<int, int, int> DownLeft = new Tuple<int, int, int>(-1, 0, 1);

    }
}

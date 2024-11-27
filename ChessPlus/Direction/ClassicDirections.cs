namespace ChessPlus.Direction
{
    static class ClassicDirections
    {
        public static readonly (int Y, int X) Up = (-1, 0);
        public static readonly (int Y, int X) Down = (1, 0);
        public static readonly (int Y, int X) Left = (0, -1);
        public static readonly (int Y, int X) Right = (0, 1);
        public static readonly (int Y, int X) UpLeft = (-1, -1);
        public static readonly (int Y, int X) UpRight = (-1, 1);
        public static readonly (int Y, int X) DownLeft = (1, -1);
        public static readonly (int Y, int X) DownRight = (1, 1);
    }
}

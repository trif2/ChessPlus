namespace ChessPlus.Direction
{
    static class HexDirections
    {
        public static readonly (int Q, int R, int S) Up = (0, -1, 1);
        public static readonly (int Q, int R, int S) Down = (0, 1, -1);
        public static readonly (int Q, int R, int S) UpLeft = (-1, 0, 1);
        public static readonly (int Q, int R, int S) UpRight = (1, -1, 0);
        public static readonly (int Q, int R, int S) DownRight = (1, 0, -1);
        public static readonly (int Q, int R, int S) DownLeft = (-1, 1, 0);

        public static readonly (int Q, int R, int S) DiagLeft = (-2, 1, 1);
        public static readonly (int Q, int R, int S) DiagRight = (2, -1, -1);
        public static readonly (int Q, int R, int S) DiagUpLeft = (-1, -1, 2);
        public static readonly (int Q, int R, int S) DiagUpRight = (1, -2, 1);
        public static readonly (int Q, int R, int S) DiagDownLeft = (1, 1, -2);
        public static readonly (int Q, int R, int S) DiagDownRight = (-1, 2, -1);

        public static readonly (int Q, int R, int S) KnightUTwoULOne = (-1, -2, 3);
        public static readonly (int Q, int R, int S) KnightUTwoUROne = (1, -3, 2);
        public static readonly (int Q, int R, int S) KnightURTwoUOne = (2, -3, 1);
        public static readonly (int Q, int R, int S) KnightURTwoDROne = (3, -2, -1);
        public static readonly (int Q, int R, int S) KnightDRTwoUROne = (3, -1, -2);
        public static readonly (int Q, int R, int S) KnightDRTwoDOne = (2, 1, -3);
        public static readonly (int Q, int R, int S) KnightDTwoDROne = (1, 2, -3);
        public static readonly (int Q, int R, int S) KnightDTwoDLOne = (-1, 3, -2);
        public static readonly (int Q, int R, int S) KnightDLTwoDOne = (2, 3, -1);
        public static readonly (int Q, int R, int S) KnightDLTwoULOne = (-3, 2, 1);
        public static readonly (int Q, int R, int S) KnightULTwoDLOne = (-3, 1, 2);
        public static readonly (int Q, int R, int S) KnightULTwoUOne = (-2, -1, 3);
    }
}
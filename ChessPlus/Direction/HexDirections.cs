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

        public static (int Q, int R, int S) MultiplyDirection((int Q, int R, int S) direction, int scalar)
        {
            return (direction.Q * scalar, direction.R * scalar, direction.S * scalar);
        }
        public static HexPosition AddPos(HexPosition position, (int Q, int R, int S) direction)
        {
            HexPosition newPosition = new HexPosition(position.Q + direction.Q, position.R + direction.R, position.S + direction.S);
            return newPosition;
        }
    }
}
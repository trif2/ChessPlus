using ChessPlus.Board;
using ChessPlus.Movement;
using ChessPlus.Positions;

namespace ChessPlus.Pieces
{
    internal abstract class Piece
    {
        public bool Color { get; set; }
        public int Type { get; set; }
        public Piece(bool isWhite, int type)
        {
            Color = isWhite;
            Type = type;
        }
        // Returned moves may be illegal (validated in Board methods)
        public abstract List<Move> GetMoves(ClassicPosition pos);

        protected static bool IsInBounds(ClassicPosition pos)
        {
            int y = pos.Y;
            int x = pos.X;
            return y >= 0 && y < 8 && x >= 0 && x < 8;
        }
    }
}

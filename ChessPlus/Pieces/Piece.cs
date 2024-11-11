using ChessPlus.Board;
using ChessPlus.Movement;

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
        public abstract List<Move> GetMoves(IBoard board);
    }
}

using ChessPlus.Board;
using ChessPlus.Movement;
using ChessPlus.Positions;

namespace ChessPlus.Pieces
{
    public abstract class ClassicPiece : Piece
    {
        public ClassicPiece(bool isWhite, int type, bool hasMoved) : base(isWhite, type, hasMoved) { }
        // Returned moves may be illegal (validated in Board methods)
        public override abstract List<Move> GetMoves(IBoard board, Position pos);
    }
}

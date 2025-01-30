using ChessPlus.Board;
using ChessPlus.Board.Glinski;
using ChessPlus.Movement;
using ChessPlus.Positions;
namespace ChessPlus.Pieces.Glinski
{
    public abstract class HexPiece : Piece
    {
        public HexPiece(bool isWhite, int type, bool hasMoved) : base(isWhite, type, hasMoved) { }
        // Returned moves may be illegal (validated in Board methods)
        public override abstract List<Move> GetMoves(IBoard board, Position pos);
    }
}

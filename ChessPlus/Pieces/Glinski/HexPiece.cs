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
        protected static bool IsInBounds(Position pos)
        {
            int q = pos.Q;
            int r = pos.R;
            int s = pos.S;

            bool qIsValid = q >= -HexBoard.BoardSize && q <= HexBoard.BoardSize;
            bool rIsValid = r >= -HexBoard.BoardSize && r <= HexBoard.BoardSize;
            bool sIsValid = s >= -HexBoard.BoardSize && s <= HexBoard.BoardSize;
            return q + r + s == 0 && qIsValid && rIsValid && sIsValid;
        }
    }
}

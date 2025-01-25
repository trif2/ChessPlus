using ChessPlus.Board;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Glinski
{
    public class HexRook : HexPiece
    {
        public HexRook(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Rook;
        }

        public override List<Move> GetMoves(IBoard board, Position pos)
        {
            return [];
        }
    }
}

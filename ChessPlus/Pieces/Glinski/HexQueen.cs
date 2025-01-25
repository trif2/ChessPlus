using ChessPlus.Board;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Glinski
{
    public class HexQueen : HexPiece
    {
        public HexQueen(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Queen;
        }

        public override List<Move> GetMoves(IBoard board, Position pos)
        {
            return [];
        }
    }
}

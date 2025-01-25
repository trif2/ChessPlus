using ChessPlus.Board;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Glinski
{
    public class HexBishop : HexPiece
    {
        public HexBishop(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Bishop;
        }

        public override List<Move> GetMoves(IBoard board, Position pos)
        {
            return [];
        }
    }
}

using ChessPlus.Board;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Glinski
{
    public class HexKing : HexPiece
    {
        public HexKing(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.King;
        }

        public override List<Move> GetMoves(IBoard board, Position pos)
        {
            return [];
        }
    }
}

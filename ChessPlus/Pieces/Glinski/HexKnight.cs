using ChessPlus.Board;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Glinski
{
    public class HexKnight : HexPiece
    {
        public HexKnight(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Knight;
        }

        public override List<Move> GetMoves(IBoard board, Position pos)
        {
            return [];
        }
    }
}

using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Glinski
{
    public class HexKnight : HexPiece
    {
        public HexKnight(bool isWhite) : base(isWhite, 0)
        {
            Type = PieceType.Bishop;
        }

        public override List<Move> GetMoves(HexPosition pos)
        {
            return [];
        }
    }
}

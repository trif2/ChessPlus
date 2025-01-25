using ChessPlus.Board;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Glinski
{
    public class HexPawn : HexPiece
    {
        public HexPawn(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Pawn;
        }

        public override List<Move> GetMoves(IBoard board, Position pos)
        {
            return [];
        }
    }
}

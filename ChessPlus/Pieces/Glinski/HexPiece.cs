using ChessPlus.Movement;
using ChessPlus.Positions;
namespace ChessPlus.Pieces.Glinski
{
    public abstract class HexPiece
    {
        public bool Color { get; set; }
        public int Type { get; set; }
        public HexPiece(bool isWhite, int type)
        {
            Color = isWhite;
            Type = type;
        }
        // Returned moves may be illegal (validated in Board methods)
        public abstract List<Move> GetMoves(HexPosition pos);
    }
}

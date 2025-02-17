using ChessPlus.Board;
using ChessPlus.Movement;
using ChessPlus.Positions;

namespace ChessPlus.Pieces
{
    public abstract class Piece
    {
        public bool Color { get; set; }
        public int Type { get; set; }
        public bool HasMoved { get; set; } = false;
        public Piece(bool isWhite, int type, bool hasMoved)
        {
            Color = isWhite;
            Type = type;
            HasMoved = hasMoved;
        }
        // Returned moves may be illegal (validated in Board methods)
        public abstract List<Move> GetMoves(IBoard board, Position pos);
        public override string ToString()
        {
            switch (Type)
            {
                case 1:
                    return Color ? "P" : "p";
                case 2:
                    return Color ? "N" : "n";
                case 3:
                    return Color ? "B" : "b";
                case 4:
                    return Color ? "R" : "r";
                case 5:
                    return Color ? "Q" : "q";
                case 6:
                    return Color ? "K" : "k";
                default:
                    return "";
            }
        }
    }
}

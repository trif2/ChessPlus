using ChessPlus.Movement;
using ChessPlus.Pieces;
using ChessPlus.Positions;

namespace ChessPlus.Board
{
    public interface IBoard
    {
        // Exporting
        string ExportToFen();
        
        // Piece Management
        Piece? GetPiece(Position pos);
        Position GetPositionByPiece(Piece piece);
        void MovePiece(Move move, bool simulate = false);
        void UndoMove(Move move, Piece? capturedPiece);
        
        // Game State
        List<Move> GetLegalMoves();
        bool IsKingInCheck(bool whiteTurn);
        bool IsCheckmate();
        bool IsStalemate();
        bool IsInBounds(Position pos);
    }
}

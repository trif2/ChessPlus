using ChessPlus.Movement;
using ChessPlus.Pieces;
using ChessPlus.Positions;

namespace ChessPlus.Board
{
    internal interface IBoard
    {
        Piece? GetPiece(Position pos);
        void MovePiece(Move move);
        bool IsCheck(bool whiteTurn);
        bool IsCheckmate(bool whiteTurn);
        bool IsStalemate(bool whiteTurn);
    }
}

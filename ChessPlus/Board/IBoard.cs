using ChessPlus.Movement;
using ChessPlus.Pieces;
using ChessPlus.Positions;

namespace ChessPlus.Board
{
    interface IBoard
    {
        void MovePiece(Move move);
        bool IsCheck(bool whiteTurn);
        bool IsCheckmate(bool whiteTurn);
        bool IsStalemate(bool whiteTurn);
    }
}

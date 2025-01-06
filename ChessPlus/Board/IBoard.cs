using ChessPlus.Movement;

namespace ChessPlus.Board
{
    interface IBoard
    {
        void MovePiece(Move move, bool simulate = false);
        //bool IsKingInCheck(bool whiteTurn);
        bool IsCheckmate();
        bool IsStalemate();
    }
}

using ChessPlus.Movement;

namespace ChessPlus.Board
{
    interface IBoard
    {
        void MovePiece(Move move);
        //bool IsKingInCheck(bool whiteTurn);
        bool IsCheckmate();
        bool IsStalemate();
    }
}

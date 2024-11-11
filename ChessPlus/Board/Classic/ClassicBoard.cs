using ChessPlus.Movement;
using ChessPlus.Pieces;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Board.Classic
{
    internal class ClassicBoard : IBoard
    {
        private Piece?[,] board;
        public ClassicBoard()
        {
            board = new Piece?[8, 8];
            InitializeBoard();
        }
        private void InitializeBoard()
        {
            board[0, 0] = new Piece(false, PieceType.Rook);
            board[0, 1] = new Piece(false, PieceType.Knight);
            board[0, 2] = new Piece(false, PieceType.Bishop);
            board[0, 3] = new Piece(false, PieceType.Queen);
            board[0, 4] = new Piece(false, PieceType.King);
            board[0, 5] = new Piece(false, PieceType.Bishop);
            board[0, 6] = new Piece(false, PieceType.Knight);
            board[0, 7] = new Piece(false, PieceType.Rook);
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Piece(false, PieceType.Pawn);
                board[6, i] = new Piece(true, PieceType.Pawn);
            }
            board[7, 0] = new Piece(true, PieceType.Rook);
            board[7, 1] = new Piece(true, PieceType.Knight);
            board[7, 2] = new Piece(true, PieceType.Bishop);
            board[7, 3] = new Piece(true, PieceType.Queen);
            board[7, 4] = new Piece(true, PieceType.King);
            board[7, 5] = new Piece(true, PieceType.Bishop);
            board[7, 6] = new Piece(true, PieceType.Knight);
            board[7, 7] = new Piece(true, PieceType.Rook);
        }
        public Piece? GetPiece(Position pos)
        {
            return board[pos.Y, pos.X];
        }

        public void MovePiece(Move move)
        {
            board[move.To.Y, move.To.X] = board[move.From.Y, move.From.X];
            board[move.From.Y, move.From.X] = null;
        }

        public bool IsCheck(bool whiteTurn)
        {
            // Check if !whiteTurn pieces can attack whiteTurn king
            throw new NotImplementedException();
        }

        public bool IsCheckmate(bool whiteTurn)
        {
            // Simulate all possible moves for whiteTurn and check if any of them prevent check
            // If no moves prevent check, return true
            throw new NotImplementedException();
        }

        public bool IsStalemate(bool whiteTurn)
        {
            // Check for any legal moves for whiteTurn
            // If legal moves = [], return true
            throw new NotImplementedException();
        }
    }
}

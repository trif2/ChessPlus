using ChessPlus.Movement;
using ChessPlus.Pieces;
using ChessPlus.Pieces.Classic;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Board.Classic
{
    public class ClassicBoard : IBoard
    {
        private Piece?[,] board;
        public const int BoardSize = 8;
        public ClassicBoard()
        {
            board = new Piece?[BoardSize, BoardSize];
            InitializeBoard();
        }
        private void InitializeBoard()
        {
            board[0, 0] = new Rook(false);
            board[0, 1] = new Knight(false);
            board[0, 2] = new Bishop(false);
            board[0, 3] = new Queen(false);
            board[0, 4] = new King(false);
            board[0, 5] = new Bishop(false);
            board[0, 6] = new Knight(false);
            board[0, 7] = new Rook(false);
            for (int i = 0; i < BoardSize; i++)
            {
                board[1, i] = new Pawn(false);
                board[6, i] = new Pawn(true);
            }
            board[7, 0] = new Rook(true);
            board[7, 1] = new Knight(true);
            board[7, 2] = new Bishop(true);
            board[7, 3] = new Queen(true);
            board[7, 4] = new King(true);
            board[7, 5] = new Bishop(true);
            board[7, 6] = new Knight(true);
            board[7, 7] = new Rook(true);
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    result += board[i, j]?.ToString() ?? "-";
                    result += " ";
                }
                result = result.Substring(0, result.Length - 1);
                result += "\n";
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }
        public Piece? GetPiece(ClassicPosition pos)
        {
            return (pos.Y >= 0 && pos.Y < BoardSize && pos.X >= 0 && pos.X < BoardSize) ? board[pos.Y, pos.X] : null;
        }

        // Assumes move is legal
        public void MovePiece(Move move)
        {
            board[move.To.Y, move.To.X] = board[move.From.Y, move.From.X];
            board[move.From.Y, move.From.X] = null;
        }

        public ClassicPosition GetPositionByPiece(Piece piece)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == piece)
                    {
                        return new ClassicPosition(i, j);
                    }
                }
            }
            throw new ArgumentException("Piece not found on the board.");
        }
        public bool IsCheck()
        {
            // Check if !whiteTurn pieces can attack whiteTurn king
            throw new NotImplementedException();
        }

        public bool IsCheckmate()
        {
            // Simulate all possible moves for whiteTurn and check if any of them prevent check
            // If no moves prevent check, return true
            throw new NotImplementedException();
        }

        public bool IsStalemate()
        {
            // Check for any legal moves for whiteTurn
            // If legal moves = [], return true
            throw new NotImplementedException();
        }

        public List<Move> GetLegalMoves()
        {
            List<Move> moves = [];
            // For each Piece on the board, call GetMoves() and add to list
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Piece? piece = board[i, j];
                    if (piece != null)
                    {
                        ClassicPosition pos = new ClassicPosition(i, j);
                        moves.AddRange(piece.GetMoves(this, pos));
                    }
                }
            }

            return moves;
        }
    }
}

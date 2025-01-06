using ChessPlus.Movement;
using ChessPlus.Pieces;
using ChessPlus.Pieces.Classic;
using ChessPlus.Positions;
using ChessPlus.Util;
using System.Runtime.CompilerServices;

namespace ChessPlus.Board.Classic
{
    public class ClassicBoard : IBoard
    {
        private Piece?[,] board;
        private bool whiteToMove;
        private bool whiteKingCastle;
        private bool whiteQueenCastle;
        private bool blackKingCastle;
        private bool blackQueenCastle;
        private ClassicPosition? enPassantTarget;
        private int halfMoveClock;
        private int fullMoveNumber;

        public const int BoardSize = 8;
        private const string DefaultBoard = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        public ClassicBoard(string fen = DefaultBoard)
        {
            string[] fields = fen.Split(" ");
            board = new Piece?[BoardSize, BoardSize];
            InitializeBoardPieces(fields[0]);

            whiteToMove = fields[1] == "w";

            whiteKingCastle = fields[2].Contains('K');
            whiteQueenCastle = fields[2].Contains('Q');
            blackKingCastle = fields[2].Contains('k');
            blackQueenCastle = fields[2].Contains('q');

            enPassantTarget = fields[3] == "-" ? null : ClassicPosition.StringToPosition(fields[3]);

            halfMoveClock = int.Parse(fields[4]);

            fullMoveNumber = int.Parse(fields[5]);
        }

        private void InitializeBoardPieces(string fen)
        {
            string[] rows = fen.Split("/");
            int i = 0;
            foreach(string row in rows)
            {
                int j = 0;
                for (int k = 0; k < row.Length; k++)
                {
                    char c = row[k];
                    if (char.IsDigit(c))
                    {
                        j += int.Parse(c.ToString());
                    } else
                    {
                        board[i, j] = PieceFen.CreatePiece(c);
                        j++;
                    }
                }
                i++;
            }
        }
        public string ExportToFen()
        {
            string fen = "";
            for (int i = 0; i < BoardSize; i++)
            {
                int gap = 0;
                for (int j = 0; j < BoardSize; j++)
                {
                    if (board[i, j] != null)
                    {
                        if (gap > 0)
                        {
                            fen += gap.ToString();
                        }
                        fen += PieceFen.GetAbbrev(board[i, j]!);
                    }
                    else
                    {
                        gap++;
                    }
                }
                if (gap > 0)
                {
                    fen += gap.ToString();
                }
                if (i < BoardSize - 1)
                {
                    fen += "/";
                }
            }
            fen += " ";
            fen += whiteToMove ? "w" : "b";
            fen += " ";
            if (whiteKingCastle || whiteQueenCastle || blackKingCastle || blackQueenCastle)
            {
                fen += whiteKingCastle ? "K" : "";
                fen += whiteQueenCastle ? "Q" : "";
                fen += blackKingCastle ? "k" : "";
                fen += blackQueenCastle ? "q" : "";
            }
            else
            {
                fen += "-";
            }
            fen += " ";
            fen += enPassantTarget == null ? "-" : enPassantTarget.ToString();
            fen += " ";
            fen += halfMoveClock.ToString() + " " + fullMoveNumber.ToString();

            return fen;
        }
        public Piece? GetPiece(ClassicPosition pos)
        {
            return (pos.Y >= 0 && pos.Y < BoardSize && pos.X >= 0 && pos.X < BoardSize) ? board[pos.Y, pos.X] : null;
        }
        public ClassicPosition GetPositionByPiece(Piece piece)
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (board[i, j] == piece)
                    {
                        return new ClassicPosition(i, j);
                    }
                }
            }
            throw new ArgumentException("Piece not found on the board.");
        }
        // Assumes move is legal
        public void MovePiece(Move move)
        {
            board[move.To.Y, move.To.X] = board[move.From.Y, move.From.X];
            board[move.From.Y, move.From.X] = null;
        }
        public void UndoMove(Move move, Piece? capturedPiece)
        {
            board[move.From.Y, move.From.X] = board[move.To.Y, move.To.X];
            board[move.To.Y, move.To.X] = capturedPiece;
        }
        public List<Move> GetLegalMoves()
        {
            List<Move> moves = GetAllPotentialMoves(whiteToMove);


            for (int i = moves.Count - 1; i >= 0; i--)
            {
                Move move = moves[i];
                Piece? prevCapture = GetPiece((ClassicPosition) move.To);
                // Simulate move
                MovePiece(move);
                if (IsKingInCheck(whiteToMove))
                {
                    moves.RemoveAt(i);
                }
                UndoMove(move, prevCapture);
            }
            return moves;
        }

        // Simulate move and check if whiteTurn king is in check
        public bool IsKingInCheck(bool whiteTurn)
        {
            ClassicPosition kingPosition = FindKing(whiteTurn) ?? throw new System.Exception("King not found");

            List<Move> moves = GetAllPotentialMoves(!whiteTurn);
            foreach (Move move in moves)
            {
                if (move.To.Y == kingPosition.Y && move.To.X == kingPosition.X)
                {
                    return true;
                }
            }

            return false;
        }

        // Returns the king position where color == whiteTurn
        private ClassicPosition? FindKing(bool whiteTurn)
        {
            for (int i = 0; i < BoardSize; i++) {
                for (int j = 0; j < BoardSize; j++)
                {
                    Piece? piece = board[i, j];
                    if (piece != null && piece.Color == whiteTurn && piece.Type == PieceType.King)
                    {
                        return new ClassicPosition(i, j);
                    }
                }
            }
            return null;
        }


        // Returns all possible moves for the current player, does not account for checks
        public List<Move> GetAllPotentialMoves(bool whiteTurn)
        {
            List<Move> moves = [];
            // For each Piece on the board, call GetMoves() and add to list
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Piece? piece = board[i, j];
                    if (piece != null && whiteTurn == piece.Color)
                    {
                        ClassicPosition pos = new ClassicPosition(i, j);
                        moves.AddRange(piece.GetMoves(this, pos));
                    }
                }
            }

            return moves;
        }

        public bool IsCheckmate()
        {
            if (GetLegalMoves().Count == 0 && IsKingInCheck(whiteToMove))
            {
                return true;
            }
            return false;
        }
        public bool IsStalemate()
        {
            if (GetLegalMoves().Count == 0 && !IsKingInCheck(whiteToMove))
            {
                return true;
            }
            return false;
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
    }
}
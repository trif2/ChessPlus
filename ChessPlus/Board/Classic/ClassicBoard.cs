﻿using ChessPlus.Movement;
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
            board[0, 0] = new Rook(Color.Black);
            board[0, 1] = new Knight(Color.Black);
            board[0, 2] = new Bishop(Color.Black);
            board[0, 3] = new Queen(Color.Black);
            board[0, 4] = new King(Color.Black);
            board[0, 5] = new Bishop(Color.Black);
            board[0, 6] = new Knight(Color.Black);
            board[0, 7] = new Rook(Color.Black);
            for (int i = 0; i < BoardSize; i++)
            {
                board[1, i] = new Pawn(Color.Black);
                board[6, i] = new Pawn(Color.White);
            }
            board[7, 0] = new Rook(Color.White);
            board[7, 1] = new Knight(Color.White);
            board[7, 2] = new Bishop(Color.White);
            board[7, 3] = new Queen(Color.White);
            board[7, 4] = new King(Color.White);
            board[7, 5] = new Bishop(Color.White);
            board[7, 6] = new Knight(Color.White);
            board[7, 7] = new Rook(Color.White);
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
        public static bool IsKingInCheck(ClassicBoard classicBoard, bool whiteTurn)
        {
            int y = 0;
            int x = 0;
            bool kingFound = false;
            while (y < BoardSize) {
                while (x < BoardSize)
                {
                    Piece? piece = classicBoard.GetPiece(new ClassicPosition(y, x));
                    if (piece != null && piece.Color == whiteTurn && piece.Type == PieceType.King)
                    {
                        break;
                    }
                    x++;
                }
                if (kingFound)
                {
                    break;
                }
                y++;
            }

            List<Move> moves = classicBoard.GetAllPotentialMoves(!whiteTurn);
            foreach (Move move in moves)
            {
                if (move.To.Y == y && move.To.X == x)
                {
                    return true;
                }
            }

            return false;
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
}
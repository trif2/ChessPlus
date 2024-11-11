using ChessPlus.Board;
using ChessPlus.Constants;
using ChessPlus.Variants.Glinski;
using ChessPlus.Variants.Glinski.Pieces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.Board.Glinski
{
    internal class Board : BaseBoard
    {
        Hashtable board;
        public Board(int size)
        {
            board = new Hashtable();
            for (int i = -size; i <= size; i++)
            {
                for (int j = -size; j <= size; j++)
                {
                    for (int k = -size; k <= size; k++)
                    {
                        if (i + j + k == 0)
                        {
                            board.Add(new Tuple<int, int, int>(i, j, k), null);
                        }
                    }
                }
            }
        }
        private void InitializeBoard()
        {
            board = new Hashtable();
            for (int i = -5; i <= 5; i++)
            {
                for (int j = -5; j <= 5; j++)
                {
                    for (int k = -5; k <= 5; k++)
                    {
                        if (i + j + k == 0)
                        {
                            board.Add(new Tuple<int, int, int>(i, j, k), null);
                        }
                    }
                }
            }
            // Manually add pieces
            // Kings
            int whiteKingQ = 1;
            int whiteKingR = 4;
            int whiteKingS = -5;
            board[(whiteKingQ, whiteKingR, whiteKingS)] = new Piece(true, Constants.Constants.King);
            int blackKingQ = 1;
            int blackKingR = -5;
            int blackKingS = 4;
            board[(blackKingQ, blackKingR, blackKingS)] = new Piece(false, Constants.Constants.King);
            // Queens
            int whiteQueenQ = -1;
            int whiteQueenR = 5;
            int whiteQueenS = -4;
            board[(whiteQueenQ, whiteQueenR, whiteQueenS)] = new Piece(true, Constants.Constants.Queen);
            int blackQueenQ = -1;
            int blackQueenR = -4;
            int blackQueenS = 5;
            board[(blackQueenQ, blackQueenR, blackQueenS)] = new Piece(false, Constants.Constants.Queen);

            // Bishops
            for (int i = 3; i <= 5; i++)
            {
                board[(0, i, -i)] = new Piece(true, Constants.Constants.Bishop);
                board[(0, -i, i)] = new Piece(false, Constants.Constants.Bishop);
            }

            // Knights
            int whiteKnight1Q = 2;
            int whiteKnight1R = 3;
            int whiteKnight1S = -5;
            board[(whiteKnight1Q, whiteKnight1R, whiteKnight1S)] = new Piece(true, Constants.Constants.Knight);

            int whiteKnight2Q = -2;
            int whiteKnight2R = 5;
            int whiteKnight2S = -3;
            board[(whiteKnight2Q, whiteKnight2R, whiteKnight2S)] = new Piece(true, Constants.Constants.Knight);

            int blackKnight1Q = 2;
            int blackKnight1R = -5;
            int blackKnight1S = 3;
            board[(blackKnight1Q, blackKnight1R, blackKnight1S)] = new Piece(false, Constants.Constants.Knight);

            int blackKnight2Q = -2;
            int blackKnight2R = -3;
            int blackKnight2S = 5;
            board[(blackKnight2Q, blackKnight2R, blackKnight2S)] = new Piece(false, Constants.Constants.Knight);

            // Rooks
            int whiteRook1Q = 3;
            int whiteRook1R = 2;
            int whiteRook1S = -5;
            board[(whiteRook1Q, whiteRook1R, whiteRook1S)] = new Piece(true, Constants.Constants.Rook);

            int whiteRook2Q = -3;
            int whiteRook2R = 5;
            int whiteRook2S = -2;
            board[(whiteRook2Q, whiteRook2R, whiteRook2S)] = new Piece(true, Constants.Constants.Rook);

            int blackRook1Q = 3;
            int blackRook1R = -5;
            int blackRook1S = 2;
            board[(blackRook1Q, blackRook1R, blackRook1S)] = new Piece(false, Constants.Constants.Rook);

            int blackRook2Q = -3;
            int blackRook2R = -2;
            int blackRook2S = 5;
            board[(blackRook2Q, blackRook2R, blackRook2S)] = new Piece(false, Constants.Constants.Rook);
            // Pawns


            // 
        }
    }

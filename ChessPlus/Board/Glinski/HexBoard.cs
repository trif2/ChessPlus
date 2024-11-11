using ChessPlus.Movement;
using ChessPlus.Pieces.Glinski;
using ChessPlus.Positions;
using ChessPlus.Util;
using System.Collections;


namespace ChessPlus.Board.Glinski
{
    internal class HexBoard : IBoard
    {
        public Hashtable board;
        public HexBoard()
        {
            board = new Hashtable();
            InitializeBoard();
        }
        private void InitializeBoard()
        {
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
            board[(whiteKingQ, whiteKingR, whiteKingS)] = new HexPiece(true, PieceType.King);
            int blackKingQ = 1;
            int blackKingR = -5;
            int blackKingS = 4;
            board[(blackKingQ, blackKingR, blackKingS)] = new HexPiece(false, PieceType.King);
            // Queens
            int whiteQueenQ = -1;
            int whiteQueenR = 5;
            int whiteQueenS = -4;
            board[(whiteQueenQ, whiteQueenR, whiteQueenS)] = new HexPiece(true, PieceType.Queen);
            int blackQueenQ = -1;
            int blackQueenR = -4;
            int blackQueenS = 5;
            board[(blackQueenQ, blackQueenR, blackQueenS)] = new HexPiece(false, PieceType.Queen);

            // Bishops
            for (int i = 3; i <= 5; i++)
            {
                board[(0, i, -i)] = new HexPiece(true, PieceType.Bishop);
                board[(0, -i, i)] = new HexPiece(false, PieceType.Bishop);
            }

            // Knights
            int whiteKnight1Q = 2;
            int whiteKnight1R = 3;
            int whiteKnight1S = -5;
            board[(whiteKnight1Q, whiteKnight1R, whiteKnight1S)] = new HexPiece(true, PieceType.Knight);

            int whiteKnight2Q = -2;
            int whiteKnight2R = 5;
            int whiteKnight2S = -3;
            board[(whiteKnight2Q, whiteKnight2R, whiteKnight2S)] = new HexPiece(true, PieceType.Knight);

            int blackKnight1Q = 2;
            int blackKnight1R = -5;
            int blackKnight1S = 3;
            board[(blackKnight1Q, blackKnight1R, blackKnight1S)] = new HexPiece(false, PieceType.Knight);

            int blackKnight2Q = -2;
            int blackKnight2R = -3;
            int blackKnight2S = 5;
            board[(blackKnight2Q, blackKnight2R, blackKnight2S)] = new HexPiece(false, PieceType.Knight);

            // Rooks
            int whiteRook1Q = 3;
            int whiteRook1R = 2;
            int whiteRook1S = -5;
            board[(whiteRook1Q, whiteRook1R, whiteRook1S)] = new HexPiece(true, PieceType.Rook);

            int whiteRook2Q = -3;
            int whiteRook2R = 5;
            int whiteRook2S = -2;
            board[(whiteRook2Q, whiteRook2R, whiteRook2S)] = new HexPiece(true, PieceType.Rook);

            int blackRook1Q = 3;
            int blackRook1R = -5;
            int blackRook1S = 2;
            board[(blackRook1Q, blackRook1R, blackRook1S)] = new HexPiece(false, PieceType.Rook);

            int blackRook2Q = -3;
            int blackRook2R = -2;
            int blackRook2S = 5;
            board[(blackRook2Q, blackRook2R, blackRook2S)] = new HexPiece(false, PieceType.Rook);
            // Pawns


            // 
        }

        public HexPiece? GetPiece(HexPosition pos)
        {
            if (!IsPositionEmpty(pos))
            {
                return (HexPiece)board[(pos.Q, pos.R, pos.S)];
            }
            return null;
        }

        private bool IsPositionEmpty(HexPosition pos)
        {
            if (board[(pos.Q, pos.R, pos.S)] == null)
            {
                return true;
            }
            return false;
        }
        public void MovePiece(Move move);
        public bool IsCheck(bool whiteTurn);
        public bool IsCheckmate(bool whiteTurn);
        public bool IsStalemate(bool whiteTurn);
    }

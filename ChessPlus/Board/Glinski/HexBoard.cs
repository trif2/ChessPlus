using ChessPlus.Movement;
using ChessPlus.Pieces;
using ChessPlus.Pieces.Glinski;
using ChessPlus.Positions;
using ChessPlus.Util;
using System.Collections;


namespace ChessPlus.Board.Glinski
{
    public class HexBoard : IBoard
    {
        public Hashtable board;
        private bool whiteToMove;
        private bool whiteKingCastle;
        private bool whiteQueenCastle;
        private bool blackKingCastle;
        private bool blackQueenCastle;
        private HexPosition? enPassantTarget;
        private int halfMoveClock;
        private int fullMoveNumber;

        public const int BoardSize = 5;
        public const string DefaultBoard = "b/qbk/n1b1n/r5r/ppppppppp/11/5P5/4P1P4/3P1B1P3/2P2B2P2/1PRNQBKNRP1 w - 0 1";
        public HexBoard(string fen = DefaultBoard)
        {
            string[] fields = fen.Split(" ");
            board = new Hashtable();
            InitializeBoardPieces(fields[0]);

            whiteToMove = fields[1] == "w";

            enPassantTarget = fields[2] == "-" ? null : HexPosition.StringToPosition(fields[2]);

            halfMoveClock = int.Parse(fields[3]);

            fullMoveNumber = int.Parse(fields[4]);
        }
        private void InitializeBoardPieces(string fen)
        {
            for (int i = -BoardSize; i <= BoardSize; i++)
            {
                for (int j = -BoardSize; j <= BoardSize; j++)
                {
                    for (int k = -BoardSize; k <= BoardSize; k++)
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
            board[(whiteKingQ, whiteKingR, whiteKingS)] = new HexKing(Color.White);
            int blackKingQ = 1;
            int blackKingR = -5;
            int blackKingS = 4;
            board[(blackKingQ, blackKingR, blackKingS)] = new HexKing(Color.Black);
            // Queens
            int whiteQueenQ = -1;
            int whiteQueenR = 5;
            int whiteQueenS = -4;
            board[(whiteQueenQ, whiteQueenR, whiteQueenS)] = new HexQueen(Color.White);
            int blackQueenQ = -1;
            int blackQueenR = -4;
            int blackQueenS = 5;
            board[(blackQueenQ, blackQueenR, blackQueenS)] = new HexQueen(Color.Black);

            // Bishops
            for (int i = 3; i <= 5; i++)
            {
                board[(0, i, -i)] = new HexBishop(Color.White);
                board[(0, -i, i)] = new HexBishop(Color.Black);
            }

            // Knights
            int whiteKnight1Q = 2;
            int whiteKnight1R = 3;
            int whiteKnight1S = -5;
            board[(whiteKnight1Q, whiteKnight1R, whiteKnight1S)] = new HexKnight(Color.White);

            int whiteKnight2Q = -2;
            int whiteKnight2R = 5;
            int whiteKnight2S = -3;
            board[(whiteKnight2Q, whiteKnight2R, whiteKnight2S)] = new HexKnight(Color.White);

            int blackKnight1Q = 2;
            int blackKnight1R = -5;
            int blackKnight1S = 3;
            board[(blackKnight1Q, blackKnight1R, blackKnight1S)] = new HexKnight(Color.Black);

            int blackKnight2Q = -2;
            int blackKnight2R = -3;
            int blackKnight2S = 5;
            board[(blackKnight2Q, blackKnight2R, blackKnight2S)] = new HexKnight(Color.Black);

            // Rooks
            int whiteRook1Q = 3;
            int whiteRook1R = 2;
            int whiteRook1S = -5;
            board[(whiteRook1Q, whiteRook1R, whiteRook1S)] = new HexRook(Color.White);

            int whiteRook2Q = -3;
            int whiteRook2R = 5;
            int whiteRook2S = -2;
            board[(whiteRook2Q, whiteRook2R, whiteRook2S)] = new HexRook(Color.White);

            int blackRook1Q = 3;
            int blackRook1R = -5;
            int blackRook1S = 2;
            board[(blackRook1Q, blackRook1R, blackRook1S)] = new HexRook(Color.Black);

            int blackRook2Q = -3;
            int blackRook2R = -2;
            int blackRook2S = 5;
            board[(blackRook2Q, blackRook2R, blackRook2S)] = new HexRook(Color.Black);
            // Pawns


            // 
        }

        public string ExportToFen()
        {
            throw new NotImplementedException();
        }
        public Piece? GetPiece(Position pos)
        {
            if (board[(pos.Q, pos.R, pos.S)] != null)
            {
                return (Piece?)board[(pos.Q, pos.R, pos.S)];
            }
            return null;
        }
        public Position GetPositionByPiece(Piece piece)
        {
            throw new NotImplementedException();
        }
        public void MovePiece(Move move, bool simulate = false)
        {
            throw new NotImplementedException();
        }
        public void UndoMove(Move move, Piece? capturedPiece)
        {
            throw new NotImplementedException();
        }
        public List<Move> GetLegalMoves()
        {
            throw new NotImplementedException();
        }
        public bool IsKingInCheck(bool whiteTurn)
        {
            throw new NotImplementedException();
        }
        public bool IsCheckmate()
        {
            throw new NotImplementedException();
        }
        public bool IsStalemate()
        {
            throw new NotImplementedException();
        }
    }
}
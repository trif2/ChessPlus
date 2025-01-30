using ChessPlus.Direction;
using ChessPlus.Movement;
using ChessPlus.Pieces;
using ChessPlus.Pieces.Glinski;
using ChessPlus.Positions;
using ChessPlus.Util;
using System.Collections;
using System.Text;


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

        private readonly static HexPosition Top = new HexPosition(0, -5, 5);
        private readonly static HexPosition TopLeft = new HexPosition(-5, 0, 5);
        private readonly static HexPosition TopRight = new HexPosition(5, -5, 0);
        private readonly static HexPosition BottomLeft = new HexPosition(-5, 5, 0);
        private readonly static HexPosition BottomRight = new HexPosition(5, 0, -5);
        private readonly static HexPosition Bottom = new HexPosition(0, 5, -5);

        private List<HexPosition> rowPositions;
        private List<HexPosition> colPositions;
        public HexBoard(string fen = DefaultBoard)
        {
            string[] fields = fen.Split(" ");
            board = new Hashtable();

            InitializeBoardPieces(fields[0]);

            rowPositions = [];
            colPositions = [];
            GetRowColPositions();

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
                            Console.WriteLine($"Adding {i}, {j}, {k}");
                            board.Add(new HexPosition(i, j, k), null);
                        }
                    }
                }
            }
            // Manually add pieces
            // Kings
            board[new HexPosition(1, 4, -5)] = new HexKing(Color.White); // White King
            board[new HexPosition(1, -5, 4)] = new HexKing(Color.Black); // Black King
            // Queens
            board[new HexPosition(-1, 5, -4)] = new HexQueen(Color.White); // White Queen
            board[new HexPosition(-1, -4, 5)] = new HexQueen(Color.Black); // Black Queen

            // Bishops
            for (int i = 3; i <= 5; i++)
            {
                board[new HexPosition(0, i, -i)] = new HexBishop(Color.White); // White Bishops
                board[new HexPosition(0, -i, i)] = new HexBishop(Color.Black); // Black Bishops
            }

            // Knights
            board[new HexPosition(2, 3, -5)] = new HexKnight(Color.White); // White Knight 1
            board[new HexPosition(-2, 5, -3)] = new HexKnight(Color.White); // White Knight 2
            board[new HexPosition(2, -5, 3)] = new HexKnight(Color.Black); // Black Knight 1
            board[new HexPosition(-2, -3, 5)] = new HexKnight(Color.Black); // Black Knight 2

            // Rooks
            board[new HexPosition(3, 2, -5)] = new HexRook(Color.White); // White Rook 1
            board[new HexPosition(-3, 5, -2)] = new HexRook(Color.White); // White Rook 2
            board[new HexPosition(3, -5, 2)] = new HexRook(Color.Black); // Black Rook 1
            board[new HexPosition(-3, -2, 5)] = new HexRook(Color.Black); // Black Rook 2

            // Pawns
            HexPosition whitePos = new HexPosition(-4, 5, -1);
            HexPosition blackPos = new HexPosition(-4, -1, 5);
            HexPosition target = new HexPosition(0, 1, -1);
            while (!whitePos.Equals(target))
            {
                board[whitePos] = new HexPawn(Color.White);
                board[blackPos] = new HexPawn(Color.Black);
                whitePos = (HexPosition)whitePos.AddDirection(HexDirections.UpRight, 1);
                blackPos = (HexPosition)blackPos.AddDirection(HexDirections.DownRight, 1);
            }
            while (IsInBounds(whitePos))
            {
                board[whitePos] = new HexPawn(Color.White);
                board[blackPos] = new HexPawn(Color.Black);
                whitePos = (HexPosition)whitePos.AddDirection(HexDirections.DownRight, 1);
                blackPos = (HexPosition)blackPos.AddDirection(HexDirections.UpRight, 1);
            }
        }
        private void GetRowColPositions()
        {
            HexPosition currPos = Top;
            while (!currPos.Equals(TopLeft)) 
            {
                rowPositions.Add(currPos);
                currPos = (HexPosition) currPos.AddDirection(HexDirections.DownLeft, 1);
            }
            while (!currPos.Equals(BottomLeft))
            {
                rowPositions.Add(currPos);
                currPos = (HexPosition) currPos.AddDirection(HexDirections.DownRight, 1);
                rowPositions.Add(currPos);
                currPos = (HexPosition)currPos.AddDirection(HexDirections.DownLeft, 1);
            }
            while (IsInBounds(currPos))
            {
                rowPositions.Add(currPos);
                currPos = (HexPosition) currPos.AddDirection(HexDirections.DownRight, 1);
            }

            currPos = TopLeft;
            while (!currPos.Equals(Top))
            {
                colPositions.Add(currPos);
                currPos = (HexPosition)currPos.AddDirection(HexDirections.UpRight, 1);
            }
            while (IsInBounds(currPos))
            {
                colPositions.Add(currPos);
                currPos = (HexPosition)currPos.AddDirection(HexDirections.DownRight, 1);
            }
        }
        public string ExportToFen()
        {
            throw new NotImplementedException();
        }
        public Piece? GetPiece(Position pos)
        {
            if (!IsInBounds(pos))
            {
                return null;
            }
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
            return [];
        }
        public bool IsKingInCheck(bool whiteTurn)
        {
            return false;
        }
        public bool IsCheckmate()
        {
            return false;
        }
        public bool IsStalemate()
        {
            return false;
        }
        public bool IsInBounds(Position pos)
        {
            int q = pos.Q;
            int r = pos.R;
            int s = pos.S;

            bool qIsValid = q >= -BoardSize && q <= BoardSize;
            bool rIsValid = r >= -BoardSize && r <= BoardSize;
            bool sIsValid = s >= -BoardSize && s <= BoardSize;

            return qIsValid && rIsValid && sIsValid && q + r + s == 0;
        }
        public override string ToString()
        {
            List<List<HexPiece?>> rows = [];
            List<HexPiece?> currRow;
            foreach (HexPosition position in rowPositions)
            {
                currRow = [];
                HexPosition currPos = position;
                do
                {
                    int q = currPos.Q;
                    int r = currPos.R;
                    int s = currPos.S;

                    currRow.Add((HexPiece?)board[new HexPosition(q, r, s)]);

                    currPos = (HexPosition)currPos.AddDirection(HexDirections.FullRight, 1);
                } while (IsInBounds(currPos));
                rows.Add(currRow);
            }
            
            var result = new StringBuilder();

            const int baseSpaceNum = 24;
            const int pieceGapNum = 7;
            const string space = " ";

            foreach(List<HexPiece?> row in rows)
            {
                int rowCount = row.Count;
                string rowStr = string.Concat(Enumerable.Repeat(space, baseSpaceNum - 4 * rowCount));

                foreach (HexPiece? piece in row)
                {
                    if (piece == null)
                    {
                        rowStr += "-";
                    }
                    else
                    {
                        rowStr += piece.ToString();
                    }
                    rowStr += string.Concat(Enumerable.Repeat(space, pieceGapNum));
                }
                rowStr += "\n";
                result.Append(rowStr);
            }




            return result.ToString();
        }
    }
}
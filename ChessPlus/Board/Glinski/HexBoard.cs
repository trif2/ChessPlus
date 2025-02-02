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
        private readonly static HexPosition BottomLeft = new HexPosition(-5, 5, 0);

        private List<HexPosition> RowPositions;
        private List<HexPosition> ColPositions;

        private readonly Dictionary<string, HexPosition> Hexes = Hex.Hexes;
        public HexBoard(string fen = DefaultBoard)
        {
            string[] fields = fen.Split(" ");
            board = new Hashtable();

            InitializeBoardPieces(fields[0]);

            RowPositions = [];
            ColPositions = [];
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
                            board.Add(new HexPosition(i, j, k), null);
                        }
                    }
                }
            }
            // Manually add pieces
            // Kings
            board[Hexes["g1"]] = new HexKing(Color.White); // White King
            board[Hexes["g10"]] = new HexKing(Color.Black); // Black King
            // Queens
            board[Hexes["e1"]] = new HexQueen(Color.White); // White Queen
            board[Hexes["e10"]] = new HexQueen(Color.Black); // Black Queen

            // Bishops
            for (int i = 3; i <= 5; i++)
            {
                board[new HexPosition(0, i, -i)] = new HexBishop(Color.White); // White Bishops
                board[new HexPosition(0, -i, i)] = new HexBishop(Color.Black); // Black Bishops
            }

            // Knights
            board[Hexes["d1"]] = new HexKnight(Color.White); // White Knight 1
            board[Hexes["h1"]] = new HexKnight(Color.White); // White Knight 2
            board[Hexes["d9"]] = new HexKnight(Color.Black); // Black Knight 1
            board[Hexes["h9"]] = new HexKnight(Color.Black); // Black Knight 2

            // Rooks
            board[Hexes["c1"]] = new HexRook(Color.White); // White Rook 1
            board[Hexes["i1"]] = new HexRook(Color.White); // White Rook 2
            board[Hexes["c8"]] = new HexRook(Color.Black); // Black Rook 1
            board[Hexes["i8"]] = new HexRook(Color.Black); // Black Rook 2

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
                RowPositions.Add(currPos);
                currPos = (HexPosition) currPos.AddDirection(HexDirections.DownLeft, 1);
            }
            while (!currPos.Equals(BottomLeft))
            {
                RowPositions.Add(currPos);
                currPos = (HexPosition) currPos.AddDirection(HexDirections.DownRight, 1);
                RowPositions.Add(currPos);
                currPos = (HexPosition)currPos.AddDirection(HexDirections.DownLeft, 1);
            }
            while (IsInBounds(currPos))
            {
                RowPositions.Add(currPos);
                currPos = (HexPosition) currPos.AddDirection(HexDirections.DownRight, 1);
            }

            currPos = TopLeft;
            while (!currPos.Equals(Top))
            {
                ColPositions.Add(currPos);
                currPos = (HexPosition)currPos.AddDirection(HexDirections.UpRight, 1);
            }
            while (IsInBounds(currPos))
            {
                ColPositions.Add(currPos);
                currPos = (HexPosition)currPos.AddDirection(HexDirections.DownRight, 1);
            }
        }
        public string ExportToFen()
        {
            throw new NotImplementedException();
        }
        public Piece? GetPiece(Position pos)
        {
            return (IsInBounds(pos)) ? (Piece?) board[pos] : null;
        }
        public void MovePiece(Move move, bool simulate = false)
        {
            board[move.To] = board[move.From];
            board[move.From] = null;
            if (!simulate)
            {
                whiteToMove = !whiteToMove;
            }
        }
        public void UndoMove(Move move, Piece? capturedPiece)
        {
            board[move.From] = board[move.To];
            board[move.To] = (HexPiece?) capturedPiece;
        }
        public List<Move> GetLegalMoves()
        {
            List<Move> moves = GetAllPotentialMoves(whiteToMove);

            for (int i = moves.Count - 1; i >= 0; i--)
            {
                Move move = moves[i];
                Piece? prevCapture = GetPiece((HexPosition)move.To);
                // Simulate move
                MovePiece(move, true);
                if (IsKingInCheck(whiteToMove))
                {
                    moves.RemoveAt(i);
                }
                UndoMove(move, prevCapture);
            }
            return moves;
        }
        public bool IsKingInCheck(bool whiteTurn)
        {
            HexPosition kingPosition = FindKing(whiteTurn) ?? throw new System.Exception("King not found");

            List<Move> moves = GetAllPotentialMoves(!whiteTurn);
            foreach (Move move in moves)
            {
                if (move.To == kingPosition)
                {
                    return true;
                }
            }

            return false;
        }
        private HexPosition? FindKing(bool whiteTurn)
        {
            foreach (DictionaryEntry entry in board)
            {
                HexPosition position = (HexPosition) entry.Key;
                HexPiece? piece = (HexPiece?) entry.Value;
                if (piece != null && piece.Color == whiteTurn && piece.Type == PieceType.King)
                {
                    return position;
                }
            }
            return null;
        }
        public List<Move> GetAllPotentialMoves(bool whiteTurn)
        {
            List<Move> moves = [];
            // For each Piece on the board, call GetMoves() and add to list
            foreach (DictionaryEntry entry in board)
            {
                HexPosition pos = (HexPosition) entry.Key;
                HexPiece? piece = (HexPiece?) entry.Value;
                if (piece != null && whiteTurn == piece.Color)
                {
                    moves.AddRange(piece.GetMoves(this, pos));
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
            foreach (HexPosition position in RowPositions)
            {
                currRow = [];
                HexPosition currPos = position;
                do
                {
                    int q = currPos.Q;
                    int r = currPos.R;
                    int s = currPos.S;

                    currRow.Add((HexPiece?)board[new HexPosition(q, r, s)]);

                    currPos = (HexPosition)currPos.AddDirection(HexDirections.DiagRight, 1);
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
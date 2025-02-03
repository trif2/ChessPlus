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
        private HexPosition? enPassantTarget;
        private int halfMoveClock;
        private int fullMoveNumber;

        public const int BoardSize = 5;
        public const string DefaultBoard = "6/P5p/RP4pr/N1P3p1n/Q2P2p2q/BBB1P1p1bbb/K2P2p2k/N1P3p1n/RP4pr/P5p/6 w - 0 1";

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
            foreach (HexPosition pos in Hexes.Values)
            {
                board.Add(pos, null);
            }

            string[] rows = fen.Split("/");
            int q = -BoardSize;
            foreach (string row in rows)
            {
                int r = BoardSize;
                int s = -q - r;
                while (Math.Abs(s) > BoardSize)
                {
                    r--;
                    s++;
                }
                for (int k = 0; k < row.Length; k++)
                {
                    if (Math.Abs(s) <= BoardSize)
                    {
                        char c = row[k];
                        if (char.IsDigit(c))
                        {
                            r -= int.Parse(c.ToString());
                            s += int.Parse(c.ToString());
                        } 
                        else
                        {
                            HexPosition pos = new HexPosition(q, r, s);
                            board[pos] = PieceToFen.CreateHexPiece(c);
                            Console.WriteLine($"Adding {c} at {pos}");
                            r--;
                            s++;
                        }
                    }    
                }
                q++;
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
            string fen = "";
            for (int q = -BoardSize; q <= BoardSize; q++)
            {
                int gap = 0;
                for (int r = BoardSize; r >= -BoardSize; r--)
                {
                    int s = -q - r;

                    if (Math.Abs(s) <= BoardSize)
                    {
                        HexPosition pos = new HexPosition(q, r, s);
                        if (board[pos] != null)
                        {
                            if (gap > 0)
                            {
                                fen += gap.ToString();
                            }
                            fen += PieceToFen.GetAbbrev((Piece) board[pos]!);
                            gap = 0;
                        }
                        else
                        {
                            gap++;
                        }
                    }
                }
                if (gap > 0)
                {
                    fen += gap.ToString();
                }
                if (q < BoardSize)
                {
                    fen += "/";
                }
            }
            fen += " ";
            fen += whiteToMove ? "w" : "b";
            fen += " ";
            fen += enPassantTarget == null ? "-" : enPassantTarget.ToString();
            fen += " ";
            fen += halfMoveClock.ToString() + " " + fullMoveNumber.ToString();

            return fen;
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
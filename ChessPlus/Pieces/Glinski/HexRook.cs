using ChessPlus.Board;
using ChessPlus.Direction;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Glinski
{
    public class HexRook : HexPiece
    {
        public HexRook(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Rook;
        }

        public override List<Move> GetMoves(IBoard board, Position pos)
        {
            List<Move> moves = [];

            List<(int Q, int R, int S)> directions = [];

            foreach ((int Q, int R, int S) direction in HexDirections.AxialDirections)
            {
                directions.Add(direction);
            }

            foreach ((int Q, int R, int S) direction in directions)
            {
                HexPosition nextPos = (HexPosition)pos.AddDirection(direction, 1);
                while (board.IsInBounds(nextPos))
                {
                    Piece? block = board.GetPiece(nextPos);
                    if (block != null && block.Color == Color) break;
                    moves.Add(new Move(pos, nextPos));
                    if (block != null && block.Color != Color) break;
                    nextPos = (HexPosition)nextPos.AddDirection(direction, 1);
                }
            }

            return moves;
        }
    }
}

using ChessPlus.Board;
using ChessPlus.Direction;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Glinski
{
    public class HexKnight : HexPiece
    {
        public HexKnight(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Knight;
        }

        public override List<Move> GetMoves(IBoard board, Position pos)
        {
            List<Move> moves = [];

            List<HexPosition> positions = [];

            foreach ((int Q, int R, int S) direction in HexDirections.KnightDirections)
            {
                positions.Add((HexPosition) pos.AddDirection(direction, 1));
            }

            foreach (HexPosition position in positions)
            {
                Piece? block = board.GetPiece(position);
                if (board.IsInBounds(position) && (block == null || block.Color != Color))
                {
                    moves.Add(new Move(pos, position));
                }
            }

            return moves;
        }
    }
}

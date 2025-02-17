using ChessPlus.Board;
using ChessPlus.Direction;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Classic
{
    public class King : ClassicPiece
    {
        public King(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.King;
        }
        public override List<Move> GetMoves(IBoard board, Position pos)
        {
            List<Move> moves = [];
            Piece? block;

            List<ClassicPosition> positions = [];
            positions.Add((ClassicPosition)pos.AddDirection(ClassicDirections.Up, 1));
            positions.Add((ClassicPosition)pos.AddDirection(ClassicDirections.Down, 1));
            positions.Add((ClassicPosition)pos.AddDirection(ClassicDirections.Left, 1));
            positions.Add((ClassicPosition)pos.AddDirection(ClassicDirections.Right, 1));
            positions.Add((ClassicPosition)pos.AddDirection(ClassicDirections.UpLeft, 1));
            positions.Add((ClassicPosition)pos.AddDirection(ClassicDirections.UpRight, 1));
            positions.Add((ClassicPosition)pos.AddDirection(ClassicDirections.DownLeft, 1));
            positions.Add((ClassicPosition)pos.AddDirection(ClassicDirections.DownRight, 1));

            foreach (ClassicPosition position in positions)
            {
                block = board.GetPiece(position);
                if (board.IsInBounds(position) && (block == null || block.Color != Color))
                {
                    moves.Add(new Move(pos, position));
                }
            }

            return moves;
        }
    }
}

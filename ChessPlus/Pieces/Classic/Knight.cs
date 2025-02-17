using ChessPlus.Board;
using ChessPlus.Direction;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Classic
{
    public class Knight : ClassicPiece
    {
        public Knight(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Knight;
        }
        public override List<Move> GetMoves(IBoard board, Position pos)
        {
            List<Move> moves = [];

            List<ClassicPosition> positions = [];

            ClassicPosition upTwoLeftOne = (ClassicPosition)pos.AddDirection(ClassicDirections.Up, 2).AddDirection(ClassicDirections.Left, 1);
            positions.Add(upTwoLeftOne);

            ClassicPosition upTwoRightOne = (ClassicPosition)pos.AddDirection(ClassicDirections.Up, 2).AddDirection(ClassicDirections.Right, 1);
            positions.Add(upTwoRightOne);

            ClassicPosition downTwoLeftOne = (ClassicPosition)pos.AddDirection(ClassicDirections.Down, 2).AddDirection(ClassicDirections.Left, 1);
            positions.Add(downTwoLeftOne);

            ClassicPosition downTwoRightOne = (ClassicPosition)pos.AddDirection(ClassicDirections.Down, 2).AddDirection(ClassicDirections.Right, 1);
            positions.Add(downTwoRightOne);

            ClassicPosition leftTwoUpOne = (ClassicPosition)pos.AddDirection(ClassicDirections.Left, 2).AddDirection(ClassicDirections.Up, 1);
            positions.Add(leftTwoUpOne);

            ClassicPosition leftTwoDownOne = (ClassicPosition)pos.AddDirection(ClassicDirections.Left, 2).AddDirection(ClassicDirections.Down, 1);
            positions.Add(leftTwoDownOne);

            ClassicPosition rightTwoUpOne = (ClassicPosition)pos.AddDirection(ClassicDirections.Right, 2).AddDirection(ClassicDirections.Up, 1);
            positions.Add(rightTwoUpOne);

            ClassicPosition rightTwoDownOne = (ClassicPosition)pos.AddDirection(ClassicDirections.Right, 2).AddDirection(ClassicDirections.Down, 1);
            positions.Add(rightTwoDownOne);

            foreach (ClassicPosition position in positions)
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

using ChessPlus.Board;
using ChessPlus.Board.Classic;
using ChessPlus.Direction;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.Pieces.Classic
{
    public class Knight : Piece
    {
        public Knight(bool isWhite) : base(isWhite, 0)
        {
            Type = PieceType.Knight;
        }
        public override List<Move> GetMoves(ClassicBoard board, ClassicPosition pos)
        {
            List<Move> moves = [];

            List<ClassicPosition> positions = [];

            ClassicPosition upTwoLeftOne = pos.AddDirection(ClassicDirections.Up, 2).AddDirection(ClassicDirections.Left, 1);
            positions.Add(upTwoLeftOne);

            ClassicPosition upTwoRightOne = pos.AddDirection(ClassicDirections.Up, 2).AddDirection(ClassicDirections.Right, 1);
            positions.Add(upTwoRightOne);

            ClassicPosition downTwoLeftOne = pos.AddDirection(ClassicDirections.Down, 2).AddDirection(ClassicDirections.Left, 1);
            positions.Add(downTwoLeftOne);

            ClassicPosition downTwoRightOne = pos.AddDirection(ClassicDirections.Down, 2).AddDirection(ClassicDirections.Right, 1);
            positions.Add(downTwoRightOne);

            ClassicPosition leftTwoUpOne = pos.AddDirection(ClassicDirections.Left, 2).AddDirection(ClassicDirections.Up, 1);
            positions.Add(leftTwoUpOne);

            ClassicPosition leftTwoDownOne = pos.AddDirection(ClassicDirections.Left, 2).AddDirection(ClassicDirections.Down, 1);
            positions.Add(leftTwoDownOne);

            ClassicPosition rightTwoUpOne = pos.AddDirection(ClassicDirections.Right, 2).AddDirection(ClassicDirections.Up, 1);
            positions.Add(rightTwoUpOne);

            ClassicPosition rightTwoDownOne = pos.AddDirection(ClassicDirections.Right, 2).AddDirection(ClassicDirections.Down, 1);
            positions.Add(rightTwoDownOne);

            foreach (ClassicPosition position in positions)
            {
                if (IsInBounds(position))
                {
                    moves.Add(new Move(pos, position));
                }
            }

            return moves;
        }
    }
}

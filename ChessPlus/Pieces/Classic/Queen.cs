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
    public class Queen : Piece
    {
        public Queen(bool isWhite) : base(isWhite, 0)
        {
            Type = PieceType.Queen;
        }
        public override List<Move> GetMoves(ClassicBoard board, ClassicPosition pos)
        {
            List<Move> moves = [];

            ClassicPosition upPos = pos.AddDirection(ClassicDirections.Up, 1);
            while (IsInBounds(upPos))
            {
                moves.Add(new Move(pos, upPos));
                upPos = upPos.AddDirection(ClassicDirections.Up, 1);
            }

            ClassicPosition downPos = pos.AddDirection(ClassicDirections.Down, 1);
            while (IsInBounds(downPos))
            {
                moves.Add(new Move(pos, downPos));
                downPos = downPos.AddDirection(ClassicDirections.Down, 1);
            }

            ClassicPosition leftPos = pos.AddDirection(ClassicDirections.Left, 1);
            while (IsInBounds(leftPos))
            {
                moves.Add(new Move(pos, leftPos));
                leftPos = leftPos.AddDirection(ClassicDirections.Left, 1);
            }

            ClassicPosition rightPos = pos.AddDirection(ClassicDirections.Right, 1);
            while (IsInBounds(rightPos))
            {
                moves.Add(new Move(pos, rightPos));
                rightPos = rightPos.AddDirection(ClassicDirections.Right, 1);
            }

            ClassicPosition upLeftPos = pos.AddDirection(ClassicDirections.UpLeft, 1);
            while (IsInBounds(upLeftPos))
            {
                moves.Add(new Move(pos, upLeftPos));
                upLeftPos = upLeftPos.AddDirection(ClassicDirections.UpLeft, 1);
            }

            ClassicPosition upRightPos = pos.AddDirection(ClassicDirections.UpRight, 1);
            while (IsInBounds(upRightPos))
            {
                moves.Add(new Move(pos, upRightPos));
                upRightPos = upRightPos.AddDirection(ClassicDirections.UpRight, 1);
            }

            ClassicPosition downLeftPos = pos.AddDirection(ClassicDirections.DownLeft, 1);
            while (IsInBounds(downLeftPos))
            {
                moves.Add(new Move(pos, downLeftPos));
                downLeftPos = downLeftPos.AddDirection(ClassicDirections.DownLeft, 1);
            }

            ClassicPosition downRightPos = pos.AddDirection(ClassicDirections.DownRight, 1);
            while (IsInBounds(downRightPos))
            {
                moves.Add(new Move(pos, downRightPos));
                downRightPos = downRightPos.AddDirection(ClassicDirections.DownRight, 1);
            }

            return moves;
        }
    }
}

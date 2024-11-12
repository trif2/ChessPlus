using ChessPlus.Board;
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
    public class King : Piece
    {
        public King(bool isWhite) : base(isWhite, 0)
        {
            Type = PieceType.King;
        }
        public override List<Move> GetMoves(ClassicPosition pos)
        {
            List<Move> moves = [];
            ClassicPosition upPos = pos.AddDirection(ClassicDirections.Up, 1);
            if (IsInBounds(upPos))
            {
                moves.Add(new Move(pos, upPos));
            }

            ClassicPosition downPos = pos.AddDirection(ClassicDirections.Down, 1);
            if (IsInBounds(downPos))
            {
                moves.Add(new Move(pos, downPos));
            }

            ClassicPosition leftPos = pos.AddDirection(ClassicDirections.Left, 1);
            if (IsInBounds(leftPos))
            {
                moves.Add(new Move(pos, leftPos));
            }

            ClassicPosition rightPos = pos.AddDirection(ClassicDirections.Right, 1);

            if (IsInBounds(rightPos))
            {
                moves.Add(new Move(pos, rightPos));
            }

            ClassicPosition upLeftPos = pos.AddDirection(ClassicDirections.UpLeft, 1);

            if (IsInBounds(upLeftPos))
            {
                moves.Add(new Move(pos, upLeftPos));
            }

            ClassicPosition upRightPos = pos.AddDirection(ClassicDirections.UpRight, 1);

            if (IsInBounds(upRightPos))
            {
                moves.Add(new Move(pos, upRightPos));
            }

            ClassicPosition downLeftPos = pos.AddDirection(ClassicDirections.DownLeft, 1);

            if (IsInBounds(downLeftPos))
            {
                moves.Add(new Move(pos, downLeftPos));
            }

            ClassicPosition downRightPos = pos.AddDirection(ClassicDirections.DownRight, 1);

            if (IsInBounds(downRightPos))
            {
                moves.Add(new Move(pos, downRightPos));
            }

            return moves;
        }
    }
}

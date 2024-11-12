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
    public class Bishop : Piece
    {
        public Bishop(bool isWhite) : base(isWhite, 0)
        {
            Type = PieceType.Bishop;
        }

        public override List<Move> GetMoves(ClassicPosition pos)
        {
            List<Move> moves = [];

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

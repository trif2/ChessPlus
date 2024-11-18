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
    public class King : Piece
    {
        public King(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.King;
        }
        public override List<Move> GetMoves(ClassicBoard board, ClassicPosition pos)
        {
            List<Move> moves = [];
            Piece? block;

            ClassicPosition upPos = pos.AddDirection(ClassicDirections.Up, 1);
            block = board.GetPiece(upPos);
            if (IsInBounds(upPos) && (block == null || block.Color != Color))
            {
                moves.Add(new Move(pos, upPos));
            }

            ClassicPosition downPos = pos.AddDirection(ClassicDirections.Down, 1);
            if (IsInBounds(downPos) && (block == null || block.Color != Color))
            {
                moves.Add(new Move(pos, downPos));
            }

            ClassicPosition leftPos = pos.AddDirection(ClassicDirections.Left, 1);
            if (IsInBounds(leftPos) && (block == null || block.Color != Color))
            {
                moves.Add(new Move(pos, leftPos));
            }

            ClassicPosition rightPos = pos.AddDirection(ClassicDirections.Right, 1);

            if (IsInBounds(rightPos) && (block == null || block.Color != Color))
            {
                moves.Add(new Move(pos, rightPos));
            }

            ClassicPosition upLeftPos = pos.AddDirection(ClassicDirections.UpLeft, 1);

            if (IsInBounds(upLeftPos) && (block == null || block.Color != Color))
            {
                moves.Add(new Move(pos, upLeftPos));
            }

            ClassicPosition upRightPos = pos.AddDirection(ClassicDirections.UpRight, 1);

            if (IsInBounds(upRightPos) && (block == null || block.Color != Color))
            {
                moves.Add(new Move(pos, upRightPos));
            }

            ClassicPosition downLeftPos = pos.AddDirection(ClassicDirections.DownLeft, 1);

            if (IsInBounds(downLeftPos) && (block == null || block.Color != Color))
            {
                moves.Add(new Move(pos, downLeftPos));
            }

            ClassicPosition downRightPos = pos.AddDirection(ClassicDirections.DownRight, 1);

            if (IsInBounds(downRightPos) && (block == null || block.Color != Color))
            {
                moves.Add(new Move(pos, downRightPos));
            }

            return moves;
        }
    }
}

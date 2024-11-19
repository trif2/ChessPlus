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
        public Queen(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Queen;
        }
        public override List<Move> GetMoves(ClassicBoard board, ClassicPosition pos)
        {
            List<Move> moves = [];

            ClassicPosition upPos = pos.AddDirection(ClassicDirections.Up, 1);
            while (IsInBounds(upPos))
            {
                Piece? block = board.GetPiece(upPos);
                if (block != null && block.Color == Color) break;
                moves.Add(new Move(pos, upPos));
                if (block != null && block.Color != Color) break;
                upPos = upPos.AddDirection(ClassicDirections.Up, 1);
            }

            ClassicPosition downPos = pos.AddDirection(ClassicDirections.Down, 1);
            while (IsInBounds(downPos))
            {
                Piece? block = board.GetPiece(downPos);
                if (block != null && block.Color == Color) break;
                moves.Add(new Move(pos, downPos));
                if (block != null && block.Color != Color) break;
                downPos = downPos.AddDirection(ClassicDirections.Down, 1);
            }

            ClassicPosition leftPos = pos.AddDirection(ClassicDirections.Left, 1);
            while (IsInBounds(leftPos))
            {
                Piece? block = board.GetPiece(leftPos);
                if (block != null && block.Color == Color) break;
                moves.Add(new Move(pos, leftPos));
                if (block != null && block.Color != Color) break;
                leftPos = leftPos.AddDirection(ClassicDirections.Left, 1);
            }

            ClassicPosition rightPos = pos.AddDirection(ClassicDirections.Right, 1);
            while (IsInBounds(rightPos))
            {
                Piece? block = board.GetPiece(rightPos);
                if (block != null && block.Color == Color) break;
                moves.Add(new Move(pos, rightPos));
                if (block != null && block.Color != Color) break;
                rightPos = rightPos.AddDirection(ClassicDirections.Right, 1);
            }

            ClassicPosition upLeftPos = pos.AddDirection(ClassicDirections.UpLeft, 1);
            while (IsInBounds(upLeftPos))
            {
                Piece? block = board.GetPiece(upLeftPos);
                if (block != null && block.Color == Color) break;
                moves.Add(new Move(pos, upLeftPos));
                if (block != null && block.Color != Color) break;
                upLeftPos = upLeftPos.AddDirection(ClassicDirections.UpLeft, 1);
            }

            ClassicPosition upRightPos = pos.AddDirection(ClassicDirections.UpRight, 1);
            while (IsInBounds(upRightPos))
            {
                Piece? block = board.GetPiece(upRightPos);
                if (block != null && block.Color == Color) break;
                moves.Add(new Move(pos, upRightPos));
                if (block != null && block.Color != Color) break;
                upRightPos = upRightPos.AddDirection(ClassicDirections.UpRight, 1);
            }

            ClassicPosition downLeftPos = pos.AddDirection(ClassicDirections.DownLeft, 1);
            while (IsInBounds(downLeftPos))
            {
                Piece? block = board.GetPiece(downLeftPos);
                if (block != null && block.Color == Color) break;
                moves.Add(new Move(pos, downLeftPos));
                if (block != null && block.Color != Color) break;
                downLeftPos = downLeftPos.AddDirection(ClassicDirections.DownLeft, 1);
            }

            ClassicPosition downRightPos = pos.AddDirection(ClassicDirections.DownRight, 1);
            while (IsInBounds(downRightPos))
            {
                Piece? block = board.GetPiece(downRightPos);
                if (block != null && block.Color == Color) break;
                moves.Add(new Move(pos, downRightPos));
                if (block != null && block.Color != Color) break;
                downRightPos = downRightPos.AddDirection(ClassicDirections.DownRight, 1);
            }

            return moves;
        }
    }
}

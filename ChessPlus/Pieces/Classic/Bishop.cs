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
    public class Bishop : Piece
    {
        public Bishop(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Bishop;
        }

        public override List<Move> GetMoves(ClassicBoard board, ClassicPosition pos)
        {
            List<Move> moves = [];

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

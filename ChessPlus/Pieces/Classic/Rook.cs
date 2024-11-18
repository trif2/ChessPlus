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
    public class Rook : Piece
    {
        public Rook(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Rook;
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

            return moves;
        }
    }
}

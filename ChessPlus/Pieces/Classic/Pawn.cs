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
    public class Pawn : Piece
    {
        bool hasMoved = false;
        public Pawn(bool isWhite) : base(isWhite, 0)
        {
            Type = PieceType.Pawn;
        }
        public override List<Move> GetMoves(ClassicBoard board, ClassicPosition pos)
        {
            List<Move> moves = [];

            if (Color)
            {
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

                ClassicPosition upPos = pos.AddDirection(ClassicDirections.Up, 1);

                if (IsInBounds(upPos))
                {
                    moves.Add(new Move(pos, upPos));
                }

                if (!hasMoved)
                {
                    ClassicPosition upTwoPos = pos.AddDirection(ClassicDirections.Up, 2);
                    if (IsInBounds(upTwoPos))
                    {
                        moves.Add(new Move(pos, upTwoPos));
                    }
                }
            } 
            else
            {
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

                ClassicPosition downPos = pos.AddDirection(ClassicDirections.Down, 1);

                if (IsInBounds(downPos))
                {
                    moves.Add(new Move(pos, downPos));
                }

                if (!hasMoved)
                {
                    ClassicPosition downTwoPos = pos.AddDirection(ClassicDirections.Down, 2);
                    if (IsInBounds(downTwoPos))
                    {
                        moves.Add(new Move(pos, downTwoPos));
                    }
                }
            }
            return moves;
        }
    }
}

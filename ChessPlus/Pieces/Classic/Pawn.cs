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
        public Pawn(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Pawn;
        }
        public override List<Move> GetMoves(ClassicBoard board, ClassicPosition pos)
        {
            List<Move> moves = [];

            Piece? attack;
            Piece? block;

            if (Color)
            {
                ClassicPosition upLeftPos = pos.AddDirection(ClassicDirections.UpLeft, 1);
                attack = board.GetPiece(upLeftPos);
                if (IsInBounds(upLeftPos) && attack != null && attack.Color != Color)
                {
                    moves.Add(new Move(pos, upLeftPos));
                }

                ClassicPosition upRightPos = pos.AddDirection(ClassicDirections.UpRight, 1);
                attack = board.GetPiece(upRightPos);
                if (IsInBounds(upRightPos) && attack != null && attack.Color != Color)
                {
                    moves.Add(new Move(pos, upRightPos));
                }

                ClassicPosition upPos = pos.AddDirection(ClassicDirections.Up, 1);
                block = board.GetPiece(upPos);
                if (IsInBounds(upPos) && block == null)
                {
                    moves.Add(new Move(pos, upPos));
                    if (!HasMoved)
                    {
                        ClassicPosition upTwoPos = pos.AddDirection(ClassicDirections.Up, 2);
                        block = board.GetPiece(upTwoPos);
                        if (IsInBounds(upTwoPos) && block == null)
                        {
                            moves.Add(new Move(pos, upTwoPos));
                        }
                    }
                }
            } 
            else
            {
                ClassicPosition downLeftPos = pos.AddDirection(ClassicDirections.DownLeft, 1);
                attack = board.GetPiece(downLeftPos);
                if (IsInBounds(downLeftPos) && attack != null && attack.Color != Color)
                {
                    moves.Add(new Move(pos, downLeftPos));
                }

                ClassicPosition downRightPos = pos.AddDirection(ClassicDirections.DownRight, 1);
                attack = board.GetPiece(downRightPos);
                if (IsInBounds(downRightPos) && attack != null && attack.Color != Color)
                {
                    moves.Add(new Move(pos, downRightPos));
                }

                ClassicPosition downPos = pos.AddDirection(ClassicDirections.Down, 1);
                block = board.GetPiece(downPos);
                if (IsInBounds(downPos) && block != null)
                {
                    moves.Add(new Move(pos, downPos));
                    if (!HasMoved)
                    {
                        ClassicPosition downTwoPos = pos.AddDirection(ClassicDirections.Down, 2);
                        block = board.GetPiece(downTwoPos);
                        if (IsInBounds(downTwoPos) && block == null)
                        {
                            moves.Add(new Move(pos, downTwoPos));
                        }
                    }
                }

            }
            return moves;
        }
    }
}

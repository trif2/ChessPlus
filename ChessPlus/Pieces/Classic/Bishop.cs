﻿using ChessPlus.Board.Classic;
using ChessPlus.Direction;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

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

            List<(int Y, int X)> directions = [];

            directions.Add(ClassicDirections.UpLeft);
            directions.Add(ClassicDirections.UpRight);
            directions.Add(ClassicDirections.DownLeft);
            directions.Add(ClassicDirections.DownRight);

            foreach ((int Y, int X) direction in directions)
            {
                ClassicPosition nextPos = pos.AddDirection(direction, 1);
                while (IsInBounds(nextPos))
                {
                    Piece? block = board.GetPiece(nextPos);
                    if (block != null && block.Color == Color) break;
                    moves.Add(new Move(pos, nextPos));
                    if (block != null && block.Color != Color) break;
                    nextPos = nextPos.AddDirection(direction, 1);
                }
            }

            return moves;
        }
    }
}

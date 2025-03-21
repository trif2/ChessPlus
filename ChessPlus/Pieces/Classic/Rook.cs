﻿using ChessPlus.Board;
using ChessPlus.Direction;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;


namespace ChessPlus.Pieces.Classic
{
    public class Rook : ClassicPiece
    {
        public Rook(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Rook;
        }
        public override List<Move> GetMoves(IBoard board, Position pos)
        {
            List<Move> moves = [];

            List<(int Y, int X)> directions = [];

            directions.Add(ClassicDirections.Up);
            directions.Add(ClassicDirections.Down);
            directions.Add(ClassicDirections.Left);
            directions.Add(ClassicDirections.Right);

            foreach ((int Y, int X) direction in directions)
            {
                ClassicPosition nextPos = (ClassicPosition)pos.AddDirection(direction, 1);
                while (board.IsInBounds(nextPos))
                {
                    Piece? block = board.GetPiece(nextPos);
                    if (block != null && block.Color == Color) break;
                    moves.Add(new Move(pos, nextPos));
                    if (block != null && block.Color != Color) break;
                    nextPos = (ClassicPosition)nextPos.AddDirection(direction, 1);
                }
            }

            return moves;
        }
    }
}

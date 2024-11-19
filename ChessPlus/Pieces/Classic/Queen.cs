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
            List<(int Y, int Z)> directions = [];

            directions.Add(ClassicDirections.Up);
            directions.Add(ClassicDirections.Down);
            directions.Add(ClassicDirections.Left);
            directions.Add(ClassicDirections.Right);
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

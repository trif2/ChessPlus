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

            List<ClassicPosition> positions = [];
            positions.Add(pos.AddDirection(ClassicDirections.Up, 1));
            positions.Add(pos.AddDirection(ClassicDirections.Down, 1));
            positions.Add(pos.AddDirection(ClassicDirections.Left, 1));
            positions.Add(pos.AddDirection(ClassicDirections.Right, 1));
            positions.Add(pos.AddDirection(ClassicDirections.UpLeft, 1));
            positions.Add(pos.AddDirection(ClassicDirections.UpRight, 1));
            positions.Add(pos.AddDirection(ClassicDirections.DownLeft, 1));
            positions.Add(pos.AddDirection(ClassicDirections.DownRight, 1));

            foreach (ClassicPosition position in positions)
            {
                block = board.GetPiece(position);
                if (IsInBounds(position) && (block == null || block.Color != Color))
                {
                    moves.Add(new Move(pos, position));
                }
            }

            return moves;
        }
    }
}

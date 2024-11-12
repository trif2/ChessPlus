using ChessPlus.Board;
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
    internal class King : Piece
    {
        public King(bool isWhite) : base(isWhite, 0)
        {
            Type = PieceType.King;
        }
        public override List<Move> GetMoves(ClassicPosition pos)
        {
            return [];
        }
    }
}

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
    internal class Knight : Piece
    {
        public Knight(bool isWhite) : base(isWhite, 0)
        {
            Type = PieceType.Knight;
        }
        public override List<Move> GetMoves(ClassicPosition pos)
        {
            return [];
        }
    }
}

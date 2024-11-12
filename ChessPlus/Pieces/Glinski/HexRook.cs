using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.Pieces.Glinski
{
    class HexRook : HexPiece
    {
        public HexRook(bool isWhite) : base(isWhite, 0)
        {
            Type = PieceType.Bishop;
        }

        public override List<Move> GetMoves(HexPosition pos)
        {
            return [];
        }
    }
}

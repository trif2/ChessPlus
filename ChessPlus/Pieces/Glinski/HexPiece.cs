using ChessPlus.Movement;
using ChessPlus.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.Pieces.Glinski
{
    abstract class HexPiece
    {
        public bool Color { get; set; }
        public int Type { get; set; }
        public HexPiece(bool isWhite, int type)
        {
            Color = isWhite;
            Type = type;
        }
        // Returned moves may be illegal (validated in Board methods)
        public abstract List<Move> GetMoves(HexPosition pos);
    }
}

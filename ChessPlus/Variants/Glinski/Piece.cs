using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.Variants.Glinski
{
    internal class Piece
    {
        public bool Color;
        public int Type;
        public Piece(bool isWhite, int type)
        {
            Color = isWhite;
            Type = type;
        }

    }
}

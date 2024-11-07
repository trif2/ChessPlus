using ChessPlus.Constants;
using ChessPlus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.BaseClasses
{
    internal class BasePiece : IPiece
    {
        public bool color;
        public int PieceType { get; set; }
        public BasePiece(bool isWhite, int pieceType)
        {
            color = isWhite;
            PieceType = pieceType;
        }
    }
}

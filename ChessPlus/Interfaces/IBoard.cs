using ChessPlus.BaseClasses;
using ChessPlus.Coordinate;
using ChessPlus.Variants.Glinski;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.Interfaces
{
    internal interface IBoard
    {
        void InitializeBoard();
        Piece GetPiece(Position pos);
        bool IsPositionEmpty(Position pos);
        void MovePiece(BaseMove move);
        void IsCheck(bool whiteTurn);
        void IsCheckmate(bool whiteTurn);
        void IsStalemate(bool whiteTurn);
    }
}

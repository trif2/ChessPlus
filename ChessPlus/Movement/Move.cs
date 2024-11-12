using ChessPlus.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.Movement
{
    class Move
    {
        public Position From { get; set; }
        public Position To { get; set; }

        public Move(Position from, Position to)
        {
            From = from;
            To = to;
        }
    }
}
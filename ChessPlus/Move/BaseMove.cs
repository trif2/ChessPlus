using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.Move
{
    internal class BaseMove : IMove
    {
        public Position From { get; set; }
        public Position To { get; set; }

    }
}

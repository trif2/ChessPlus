using ChessPlus.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.Movement
{
    public class ClassicMove : Move
    {
        public ClassicMove(ClassicPosition from, ClassicPosition to) : base(from, to) { }
        public ClassicMove(string from, string to) : base(ClassicPosition.StringToPosition(from), ClassicPosition.StringToPosition(to)) { }
        public ClassicMove(int fromY, int fromX, int toY, int toX) : base(new ClassicPosition(fromY, fromX), new ClassicPosition(toY, toX)) { }
        public override string ToString()
        {
            return From.ToString() + To.ToString();
        }
    }
}

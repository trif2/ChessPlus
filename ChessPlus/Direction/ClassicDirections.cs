using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.Direction
{
    internal static class ClassicDirections
    {
        public static readonly (int Y, int X) Up = (-1, 0);
        public static readonly (int Y, int X) Down = (1, 0);
        public static readonly (int Y, int X) Left = (0, -1);
        public static readonly (int Y, int X) Right = (0, 1);
    }
}

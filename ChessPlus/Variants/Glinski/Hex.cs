using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.Variants.Glinski
{
    internal class Hex
    {
        HashSet<Tuple<int, int, int>> map;
        public Hex(int size)
        {
            map = new HashSet<Tuple<int, int, int>>();
            for (int i = -size; i <= size; i++)
            {
                for (int j = -size; j <= size; j++)
                {
                    for (int k = -size; k <= size; k++)
                    {
                        if (i + j + k == 0)
                        {
                            map.Add(new Tuple<int, int, int>(i, j, k));
                        }
                    }
                }
            }
        }
    }
}

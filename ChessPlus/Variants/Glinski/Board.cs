using ChessPlus.BaseClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.Variants.Glinski
{
    internal class Board : BaseBoard
    {
        Hashtable board;
        public Board(int size)
        {
            board = new Hashtable();
            for (int i = -size; i <= size; i++)
            {
                for (int j = -size; j <= size; j++)
                {
                    for (int k = -size; k <= size; k++)
                    {
                        if (i + j + k == 0)
                        {
                            board.Add(new Tuple<int, int, int>(i, j, k), null);
                        }
                    }
                }
            }
        }
    }
}

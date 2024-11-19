using ChessPlus.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPlus.Movement
{
    public class Move
    {
        public Position From { get; set; }
        public Position To { get; set; }

        public Move(Position from, Position to)
        {
            From = from;
            To = to;
        }

        public override string ToString()
        {
            return PositionToString(From) + PositionToString(To);
        }
        private string PositionToString(Position pos)
        {
            string letter = "";
            switch (pos.X)
            {
                case 0:
                    letter = "a";
                    break;
                case 1:
                    letter = "b";
                    break;
                case 2:
                    letter = "c";
                    break;
                case 3:
                    letter = "d";
                    break;
                case 4:
                    letter = "e";
                    break;
                case 5:
                    letter = "f";
                    break;
                case 6:
                    letter = "g";
                    break;
                case 7:
                    letter = "h";
                    break;
            }
            int number = 8 - pos.Y;
            return letter + number.ToString();
        }
    }
}
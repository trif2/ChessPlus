using ChessPlus.Positions;
using System.Text.Json.Serialization;

namespace ChessPlus.Movement
{
    public class Move
    {
        public Position From { get; set; }
        public Position To { get; set; }
        [JsonConstructor]
        public Move(Position from, Position to)
        {
            From = from;
            To = to;
        }
        public Move(string from, string to)
        {
            From = ClassicPosition.StringToPosition(from);
            To = ClassicPosition.StringToPosition(to);
        }
        public Move(int fromY, int fromX, int toY, int toX)
        {
            From = new ClassicPosition(fromY, fromX);
            To = new ClassicPosition(toY, toX);
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
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Move m = (Move)obj;
            return From.Equals(m.From) && To.Equals(m.To);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(From, To);
        }
    }
}
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
        public override string ToString()
        {
            return From.ToString() + To.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
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
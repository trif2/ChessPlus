using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace ChessPlus.Positions
{
    public class HexPosition(int q = 0, int r = 0, int s = 0) : Position
    {
        public override int Q { get; set; } = q;
        public override int R { get; set; } = r;
        public override int S { get; set; } = s;
        [JsonIgnore]
        public override int Y
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }
        [JsonIgnore]
        public override int X
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }
        public override Position AddDirection(object direction, int scalar)
        {
            if (direction is (int dq, int dr, int ds))
            {
                int newQ = Q + dq * scalar;
                int newR = R + dr * scalar;
                int newS = S + ds * scalar;
                var newPosition = new HexPosition(newQ, newR, newS);
                return newPosition;
            }
            else
            {
                throw new ArgumentException("Invalid direction type", nameof(direction));
            }
        }
        public static HexPosition StringToPosition(string position)
        {
            if (Hex.Hexes.TryGetValue(position, out HexPosition? value))
            {
                return value;
            }
            else
            {
                throw new ArgumentException("Invalid position", nameof(position));
            }
        }
        public override string ToString()
        {
            return $"({Q}, {R}, {S})";
        }
        public bool IsValidPosition()
        {
            if (Q < -5 || Q > 5 || R < -5 || R > 5 || S < -5 || S > 5 || Q + R + S != 0)
            {
                return false;
            }
            return true;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            HexPosition pos = (HexPosition)obj;
            return Q == pos.Q && R == pos.R && S == pos.S;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Q, R, S);
        }
    }
}

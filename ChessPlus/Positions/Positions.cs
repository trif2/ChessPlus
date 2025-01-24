using System.Text.Json.Serialization;

namespace ChessPlus.Positions
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type", UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    [JsonDerivedType(typeof(ClassicPosition), "classic")]
    [JsonDerivedType(typeof(HexPosition), "hex")]
    public abstract class Position
    {
        public abstract int Y { get; set; }
        public abstract int X { get; set; }
        public abstract int Q { get; set; }
        public abstract int R { get; set; }
        public abstract int S { get; set; }
    }
    public class ClassicPosition(int y, int x) : Position
    {
        public override int Y { get; set; } = y;
        public override int X { get; set; } = x;
        [JsonIgnore]
        public override int Q
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }
        [JsonIgnore]
        public override int R
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }
        [JsonIgnore]
        public override int S
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }
        public ClassicPosition AddDirection((int Y, int X) direction, int scalar)
        {
            int newY = Y + direction.Y * scalar;
            int newX = X + direction.X * scalar;
            return new ClassicPosition(newY, newX);
        }
        public static ClassicPosition StringToPosition(string position)
        {
            int x = position[0] - 'a';
            int y = 8 - (position[1] - '0');
            return new ClassicPosition(y, x);
        }
        public override string ToString()
        {
            char file = (char)('a' + X);
            int rank = 8 - Y;
            return $"{file}{rank}";
        }
        public bool IsValidPosition()
        {
            if (Y < 0 || Y > 7 || X < 0 || X > 7)
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
            ClassicPosition pos = (ClassicPosition)obj;
            return Y == pos.Y && X == pos.X;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Y, X);
        }
    }
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
        public HexPosition AddDirection((int Q, int R, int S) direction, int scalar)
        {
            return new HexPosition(Q + direction.Q, R + direction.R, S + direction.S);
        }
        public static HexPosition StringToPosition(string position)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            throw new NotImplementedException();
        }
        public bool IsValidPosition()
        {
            throw new NotImplementedException();
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

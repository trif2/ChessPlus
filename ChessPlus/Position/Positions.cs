﻿namespace ChessPlus.Positions
{
    abstract class Position
    {
        public abstract int Y { get; set; }
        public abstract int X { get; set; }
        public abstract int Q { get; set; }
        public abstract int R { get; set; }
        public abstract int S { get; set; }
    }
    class ClassicPosition(int y, int x) : Position
    {
        public override int Y { get; set; } = y;
        public override int X { get; set; } = x;
        public override int Q
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }
        public override int R
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }
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
    }
    class HexPosition(int q = 0, int r = 0, int s = 0) : Position
    {
        public override int Q { get; set; } = q;
        public override int R { get; set; } = r;
        public override int S { get; set; } = s;
        public override int Y
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }
        public override int X
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }
        public HexPosition AddDirection((int Q, int R, int S) direction, int scalar)
        {
            return new HexPosition(Q + direction.Q, R + direction.R, S + direction.S);
        }
    }
}

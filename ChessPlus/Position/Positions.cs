namespace ChessPlus.Positions
{
    internal abstract class Position
    {
        public abstract int Y { get; }
        public abstract int X { get; }
        public abstract int Q { get; }
        public abstract int R { get; }
        public abstract int S { get; }
    }
    internal class ClassicPosition(int y, int x) : Position
    {
        public override int Y { get; } = y;
        public override int X { get; } = x;
        public override int Q => throw new NotSupportedException();
        public override int R => throw new NotSupportedException();
        public override int S => throw new NotSupportedException();
    }
    internal class HexPosition(int q = 0, int r = 0, int s = 0) : Position
    {
        public override int Q { get; } = q;
        public override int R { get; } = r;
        public override int S { get; } = s;
        public override int Y => throw new NotSupportedException();
        public override int X => throw new NotSupportedException();
    }
}

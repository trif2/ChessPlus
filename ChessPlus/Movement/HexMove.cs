using ChessPlus.Positions;

namespace ChessPlus.Movement
{
    public class HexMove : Move
    {
        public HexMove(HexPosition from, HexPosition to) : base(from, to) { }
        public HexMove(string from, string to) : base(HexPosition.StringToPosition(from), HexPosition.StringToPosition(to)) { }
        public HexMove(int fromQ, int fromR, int fromS, int toQ, int toR, int toS) : base(new HexPosition(fromQ, fromR, fromS), new HexPosition(toQ, toR, toS)) { }
        public override string ToString()
        {
            return From.ToString() + To.ToString();
        }
    }
}

namespace ChessPlus.Positions
{
    public static class Hex
    {
        public static readonly Dictionary<string, HexPosition> Hexes = new Dictionary<string, HexPosition>();
        static Hex()
        {
            InitializeHexes();
        }

        private static void InitializeHexes()
        {
            int size = 5;
            char[] columns = "abcdefghikl".ToCharArray();
            for (int q = -size; q <= size; q++)
            {
                int rank = 1;
                for (int r = size; r >= -size; r--)
                {
                    int s = -q - r;
                    if (Math.Abs(s) <= size)
                    {
                        string key = $"{columns[q + size]}{rank}";
                        Hexes[key] = new HexPosition(q, r, s);
                        rank++;
                    }
                }
            }
        }
    }
}

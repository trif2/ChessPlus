using ChessPlus.Util;

namespace ChessPlus.Pieces.Glinski
{
    public static class PieceToFen
    {
        public static Piece CreatePiece(char pieceAbbrev)
        {
            Piece piece = pieceAbbrev switch
            {
                'P' => new HexPawn(Color.White),
                'N' => new HexKnight(Color.White),
                'B' => new HexBishop(Color.White),
                'R' => new HexRook(Color.White),
                'Q' => new HexQueen(Color.White),
                'K' => new HexKing(Color.White),

                'p' => new HexPawn(Color.Black),
                'n' => new HexKnight(Color.Black),
                'b' => new HexBishop(Color.Black),
                'r' => new HexRook(Color.Black),
                'q' => new HexQueen(Color.Black),
                'k' => new HexKing(Color.Black),

                _ => throw new System.Exception("Invalid piece abbreviation")
            };
            return piece;
        }
        public static char GetAbbrev(Piece piece)
        {
            return piece.ToString()[0];
        }
    }
}

using ChessPlus.Pieces.Glinski;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Classic
{
    public static class PieceFen
    {
        public static Piece CreateClassicPiece(char pieceAbbrev)
        {
            Piece piece = pieceAbbrev switch
            {
                'P' => new Pawn(Color.White),
                'N' => new Knight(Color.White),
                'B' => new Bishop(Color.White),
                'R' => new Rook(Color.White),
                'Q' => new Queen(Color.White),
                'K' => new King(Color.White),

                'p' => new Pawn(Color.Black),
                'n' => new Knight(Color.Black),
                'b' => new Bishop(Color.Black),
                'r' => new Rook(Color.Black),
                'q' => new Queen(Color.Black),
                'k' => new King(Color.Black),

                _ => throw new System.Exception("Invalid piece abbreviation")
            };

            return piece;
        }
        public static Piece CreateHexPiece(char pieceAbbrev)
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

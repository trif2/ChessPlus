using ChessPlus.Board;
using ChessPlus.Direction;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Glinski
{
    public class HexKing : HexPiece
    {
        public HexKing(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.King;
        }

        public override List<Move> GetMoves(IBoard board, Position pos)
        {
            List<Move> moves = [];
            Piece? block;

            List<HexPosition> positions = [];
            positions.Add((HexPosition)pos.AddDirection(HexDirections.Up, 1));
            positions.Add((HexPosition)pos.AddDirection(HexDirections.Down, 1));
            positions.Add((HexPosition)pos.AddDirection(HexDirections.UpLeft, 1));
            positions.Add((HexPosition)pos.AddDirection(HexDirections.UpRight, 1));
            positions.Add((HexPosition)pos.AddDirection(HexDirections.DownRight, 1));
            positions.Add((HexPosition)pos.AddDirection(HexDirections.DownLeft, 1));
            positions.Add((HexPosition)pos.AddDirection(HexDirections.DiagLeft, 1));
            positions.Add((HexPosition)pos.AddDirection(HexDirections.DiagRight, 1));
            positions.Add((HexPosition)pos.AddDirection(HexDirections.DiagUpLeft, 1));
            positions.Add((HexPosition)pos.AddDirection(HexDirections.DiagUpRight, 1));
            positions.Add((HexPosition)pos.AddDirection(HexDirections.DiagDownLeft, 1));
            positions.Add((HexPosition)pos.AddDirection(HexDirections.DiagDownRight, 1));

            foreach (HexPosition position in positions)
            {
                block = board.GetPiece(position);
                if (board.IsInBounds(position) && (block == null || block.Color != Color))
                {
                    moves.Add(new Move(pos, position));
                }
            }

            return moves;
        }
    }
}

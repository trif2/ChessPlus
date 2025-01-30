using ChessPlus.Board;
using ChessPlus.Direction;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Glinski
{
    public class HexPawn : HexPiece
    {
        public HexPawn(bool isWhite) : base(isWhite, 0, false)
        {
            Type = PieceType.Pawn;
        }

        public override List<Move> GetMoves(IBoard board, Position pos)
        {
            List<Move> moves = [];

            Piece? attack;
            Piece? block;

            if (Color)
            {
                HexPosition upLeftPos = (HexPosition)pos.AddDirection(HexDirections.UpLeft, 1);
                attack = board.GetPiece(upLeftPos);
                if (board.IsInBounds(upLeftPos) && attack != null && attack.Color != Color)
                {
                    moves.Add(new Move(pos, upLeftPos));
                }

                HexPosition upRightPos = (HexPosition)pos.AddDirection(HexDirections.UpRight, 1);
                attack = board.GetPiece(upRightPos);
                if (board.IsInBounds(upRightPos) && attack != null && attack.Color != Color)
                {
                    moves.Add(new Move(pos, upRightPos));
                }

                HexPosition upPos = (HexPosition)pos.AddDirection(HexDirections.Up, 1);
                block = board.GetPiece(upPos);
                if (board.IsInBounds(upPos) && block == null)
                {
                    moves.Add(new Move(pos, upPos));
                    if (!HasMoved)
                    {
                        HexPosition upTwoPos = (HexPosition)pos.AddDirection(ClassicDirections.Up, 2);
                        block = board.GetPiece(upTwoPos);
                        if (board.IsInBounds(upTwoPos) && block == null)
                        {
                            moves.Add(new Move(pos, upTwoPos));
                        }
                    }
                }
            }
            else
            {
                HexPosition downLeftPos = (HexPosition)pos.AddDirection(HexDirections.DownLeft, 1);
                attack = board.GetPiece(downLeftPos);
                if (board.IsInBounds(downLeftPos) && attack != null && attack.Color != Color)
                {
                    moves.Add(new Move(pos, downLeftPos));
                }

                HexPosition downRightPos = (HexPosition)pos.AddDirection(HexDirections.DownRight, 1);
                attack = board.GetPiece(downRightPos);
                if (board.IsInBounds(downRightPos) && attack != null && attack.Color != Color)
                {
                    moves.Add(new Move(pos, downRightPos));
                }

                HexPosition downPos = (HexPosition)pos.AddDirection(HexDirections.Down, 1);
                block = board.GetPiece(downPos);
                if (board.IsInBounds(downPos) && block == null)
                {
                    moves.Add(new Move(pos, downPos));
                    if (!HasMoved)
                    {
                        HexPosition downTwoPos = (HexPosition)pos.AddDirection(HexDirections.Down, 2);
                        block = board.GetPiece(downTwoPos);
                        if (board.IsInBounds(downTwoPos) && block == null)
                        {
                            moves.Add(new Move(pos, downTwoPos));
                        }
                    }
                }

            }
            return moves;
        }
    }
}

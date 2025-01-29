using ChessPlus.Board;
using ChessPlus.Board.Classic;
using ChessPlus.Direction;
using ChessPlus.Movement;
using ChessPlus.Positions;
using ChessPlus.Util;

namespace ChessPlus.Pieces.Classic
{
    public class Pawn : ClassicPiece
    {
        public Pawn(bool isWhite) : base(isWhite, 0, false)
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
                ClassicPosition upLeftPos = (ClassicPosition)pos.AddDirection(ClassicDirections.UpLeft, 1);
                attack = board.GetPiece(upLeftPos);
                if (board.IsInBounds(upLeftPos) && attack != null && attack.Color != Color)
                {
                    moves.Add(new Move(pos, upLeftPos));
                }

                ClassicPosition upRightPos = (ClassicPosition)pos.AddDirection(ClassicDirections.UpRight, 1);
                attack = board.GetPiece(upRightPos);
                if (board.IsInBounds(upRightPos) && attack != null && attack.Color != Color)
                {
                    moves.Add(new Move(pos, upRightPos));
                }

                ClassicPosition upPos = (ClassicPosition)pos.AddDirection(ClassicDirections.Up, 1);
                block = board.GetPiece(upPos);
                if (board.IsInBounds(upPos) && block == null)
                {
                    moves.Add(new Move(pos, upPos));
                    if (!HasMoved)
                    {
                        ClassicPosition upTwoPos = (ClassicPosition)pos.AddDirection(ClassicDirections.Up, 2);
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
                ClassicPosition downLeftPos = (ClassicPosition)pos.AddDirection(ClassicDirections.DownLeft, 1);
                attack = board.GetPiece(downLeftPos);
                if (board.IsInBounds(downLeftPos) && attack != null && attack.Color != Color)
                {
                    moves.Add(new Move(pos, downLeftPos));
                }

                ClassicPosition downRightPos = (ClassicPosition)pos.AddDirection(ClassicDirections.DownRight, 1);
                attack = board.GetPiece(downRightPos);
                if (board.IsInBounds(downRightPos) && attack != null && attack.Color != Color)
                {
                    moves.Add(new Move(pos, downRightPos));
                }

                ClassicPosition downPos = (ClassicPosition)pos.AddDirection(ClassicDirections.Down, 1);
                block = board.GetPiece(downPos);
                if (board.IsInBounds(downPos) && block == null)
                {
                    moves.Add(new Move(pos, downPos));
                    if (!HasMoved)
                    {
                        ClassicPosition downTwoPos = (ClassicPosition)pos.AddDirection(ClassicDirections.Down, 2);
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

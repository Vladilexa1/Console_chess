using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_chess.board;

namespace Console_chess.Pieces
{
    class Pawn : Piece
    {
        public Pawn(Color color, Coordinates coordinates)
        {
            this.color = color;
            this.coordinates = coordinates;
        }

        protected override HashSet<CoordinatesShift> getPieceMoves()
        {
           HashSet<CoordinatesShift> result = new HashSet<CoordinatesShift>();
            if (color == Color.WHITE)
            {
                result.Add(new CoordinatesShift(0, 1));
                if (coordinates.rank == 2)
                {
                    result.Add(new CoordinatesShift(0, 2));
                }
                result.Add(new CoordinatesShift(-1, 1));
                result.Add(new CoordinatesShift(1, 1));
            }
            else
            {
                result.Add(new CoordinatesShift(0, -1));
                if (coordinates.rank == 7)
                {
                    result.Add(new CoordinatesShift(0, -2));
                }
                result.Add(new CoordinatesShift(-1, -1));
                result.Add(new CoordinatesShift(1, -1));
            }

            return result;

        }
        protected override bool isSquareAvailableForMove(Coordinates coordinates, Board board)
        {

            if (this.coordinates.file == coordinates.file)
            {
                int rankShift = Math.Abs(this.coordinates.rank - coordinates.rank);

                if (rankShift == 2)
                {
                    List<Coordinates> between = BoardUtils.getVerticalCoordinatesBetween(this.coordinates, coordinates);

                    return board.isSquareEmpty(between.First()) && board.isSquareEmpty(coordinates);
                }
                else
                {
                    return board.isSquareEmpty(coordinates);
                } 
            }
            else
            {
                if (board.isSquareEmpty(coordinates))
                {
                    return false;
                }
                else
                {
                    return board.getPiece(coordinates).color != color;
                }
            }
        }

        protected override HashSet<CoordinatesShift> getPieceAttacks()
        {
            HashSet<CoordinatesShift> result = new HashSet<CoordinatesShift>();

            if (color == Color.WHITE)
            {
                result.Add(new CoordinatesShift(-1, 1));
                result.Add(new CoordinatesShift(1, 1));
            }
            else
            {
                result.Add(new CoordinatesShift(-1, -1));
                result.Add(new CoordinatesShift(1, -1));
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Console_chess.board;

namespace Console_chess.Pieces
{
    class King : Piece
    {
        public King(Color color, Coordinates coordinates)
        {
            this.color = color;
            this.coordinates = coordinates;
        }

        protected override HashSet<CoordinatesShift> getPieceMoves()
        {
            HashSet<CoordinatesShift> result = new HashSet<CoordinatesShift>();

            for (int fileShift = -1; fileShift <= 1; fileShift++)
            {
                for (int rankShift = -1; rankShift <= 1; rankShift++)
                {
                    if (fileShift == 0 && rankShift == 0)
                    {
                        continue;
                    }
                    result.Add(new CoordinatesShift(fileShift, rankShift));
                }
            }
            return result;
        }
        protected override bool isSquareAvailableForMove(Coordinates coordinates, Board board)
        {
            bool result = base.isSquareAvailableForMove(coordinates, board);

            if (result)
            {
                return !board.isSquareAttackedByColor(coordinates, swapColor(color));
            }

            return false;
        }
        public Color swapColor(Color color)
        {
            return color == Color.WHITE ? Color.BLACK : Color.WHITE;
        }
    }
}

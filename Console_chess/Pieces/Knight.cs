using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess.Pieces
{
    class Knight : Piece
    {
        public Knight(Color color, Coordinates coordinates)
        {
            this.color = color;
            this.coordinates = coordinates;
        }

        protected override HashSet<CoordinatesShift> getPieceMoves()
        {
            List<CoordinatesShift> list = new List<CoordinatesShift>
            {
                new CoordinatesShift(fileShift: 1, rankShift: 2),
                new CoordinatesShift(fileShift: 2, rankShift: 1),

                new CoordinatesShift(fileShift: 2, rankShift: -1),
                new CoordinatesShift(fileShift: 1, rankShift: -2),

                new CoordinatesShift(fileShift: -2, rankShift: -1),
                new CoordinatesShift(fileShift: -1, rankShift: -2),

                new CoordinatesShift(fileShift: -2, rankShift: 1),
                new CoordinatesShift(fileShift: -1, rankShift: 2)
            };

            return new HashSet<CoordinatesShift>(list);
        }
    }
}

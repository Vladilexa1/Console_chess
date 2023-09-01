using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess.Pieces
{
    class Bishop : Piece
    {
        public Bishop(Color color, Coordinates coordinates)
        {
            this.color = color;
            this.coordinates = coordinates;
        }

        protected override HashSet<CoordinatesShift> getPieceMoves()
        {
            throw new NotImplementedException();
        }
    }
}

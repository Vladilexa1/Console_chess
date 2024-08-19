using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess.Pieces
{
    class Rook : LongRangePiece, IRook
    {
        public Rook(Color color, Coordinates coordinates)
        {
            this.color = color;
            this.coordinates = coordinates;
        }
        protected override HashSet<CoordinatesShift> getPieceMoves()
        {
            IRook rook = new Rook(color, coordinates);
            return rook.getRookMoves();
        }
    }
}

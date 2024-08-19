using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess.Pieces
{
    class Bishop : LongRangePiece, IBishop
    {
        public Bishop(Color color, Coordinates coordinates)
        {
            this.color = color;
            this.coordinates = coordinates;
        }
        protected override HashSet<CoordinatesShift> getPieceMoves()
        {
            IBishop bishop = new Bishop(color, coordinates);
            return bishop.getBishopMoves();
        }
        
    }
}

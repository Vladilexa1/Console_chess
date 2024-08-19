using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess.Pieces
{
    class Queen : LongRangePiece, IRook, IBishop
    {
        public Queen(Color color, Coordinates coordinates)
        {
            this.color = color;
            this.coordinates = coordinates;
        }

        protected override HashSet<CoordinatesShift> getPieceMoves()
        {
            HashSet<CoordinatesShift> moves = new HashSet<CoordinatesShift>();
            
            IRook rook = new Queen(color, coordinates);
            IBishop bishop = new Queen(color, coordinates);

            moves.UnionWith(rook.getRookMoves());
            moves.UnionWith(bishop.getBishopMoves());
            return moves;
        }
    }
}

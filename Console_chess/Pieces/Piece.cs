using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess.Pieces
{
    public abstract class Piece
    {
        public Color color;
        public Coordinates coordinates;
        //public Piese(Color color, Coordinates coordinates)
        //{
        //    this.color = color;
        //    this.coordinates = coordinates;
        //}
       public HashSet<Coordinates> getAviableMoveSquares(Board board)
       {
            HashSet<Coordinates> result = new HashSet<Coordinates>();
            foreach (var shift in getPieceMoves())
            {
                if (coordinates.canShift(shift))
                {
                    Coordinates newCoordinates = coordinates.shift(shift);
                    if (isSquareAvailableForMove(newCoordinates, board))
                    {
                        result.Add(newCoordinates);
                    }
                }
            }
            return result;
       }

        private bool isSquareAvailableForMove(Coordinates coordinates, Board board)
        { 
            return board.isSquareEmpty(coordinates) || board.getPiece(coordinates).color != color;
        }

        protected abstract HashSet<CoordinatesShift> getPieceMoves();
       
    }

}

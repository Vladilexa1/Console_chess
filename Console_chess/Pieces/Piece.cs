using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_chess.board;

namespace Console_chess.Pieces
{
    public abstract class Piece
    {
        public Color color;
        public Coordinates coordinates;
      
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

       protected virtual bool isSquareAvailableForMove(Coordinates coordinates, Board board)
       { 
            return board.isSquareEmpty(coordinates) || board.getPiece(coordinates).color != color;
       }

        protected abstract HashSet<CoordinatesShift> getPieceMoves();
       
        protected virtual HashSet<CoordinatesShift> getPieceAttacks()
        {
            return getPieceMoves();
        }

        public HashSet<Coordinates> getAttackedSquares(Board board)
        {
            HashSet<CoordinatesShift> pieceAttacks = getPieceAttacks();
            HashSet<Coordinates> result = new HashSet<Coordinates>();

            foreach (var pieceAttack in pieceAttacks)
            {
                if (coordinates.canShift(pieceAttack))
                {
                    Coordinates shiftedCoordinates = coordinates.shift(pieceAttack);
                    if (isSquareAvailableForAttack(shiftedCoordinates, board))
                    {
                        result.Add(shiftedCoordinates);
                    }
                }
            }
            return result;
        }

        protected virtual bool isSquareAvailableForAttack(Coordinates coordinates, Board board)
        {
            return true;
        }
    }

}

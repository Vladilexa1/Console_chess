using Console_chess.board;
using Console_chess.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess
{
    public  class CheckmateGameStateChecker : GameStateChecker
    {
        public override GameState check(Board board, Color color)
        {
            // check if king check
            // check that there is no move to prevent this check
            Piece king = filterKing(board, color);
            
            if (!board.isSquareAttackedByColor(king.coordinates, swapColor(king.color)))
            {
                return GameState.ONGOING;
            }
            List<Piece> pieces = board.getPiecesForColor(color);
            foreach (var piece in pieces)
            {
                HashSet<Coordinates> aviableMoveSquares = piece.getAviableMoveSquares(board);
                foreach (var coordinates in aviableMoveSquares)
                {
                    Board clone = new BoardFactory().copy(board);
                    clone.makeMove(new Move(piece.coordinates, coordinates));

                    Piece cloneKing = filterKing(clone, color);
                    if (!clone.isSquareAttackedByColor(cloneKing.coordinates, swapColor(color)))
                    {
                        return GameState.ONGOING;
                    }  
                }
            }
            if (color == Color.WHITE)
            {
                return GameState.CHECKMATE_TO_WHITE_KING;
            }
            else
            {
                return GameState.CHECKMATE_TO_BLACK_KING;
            }
        }
        private static Color swapColor(Color color)
        {
            return color == Color.WHITE ? Color.BLACK : Color.WHITE;
        }
        private Piece filterKing(Board board, Color color)
        {
            foreach (var piece in board.getPiecesForColor(color))
            {
                if (piece.GetType() == new King(piece.color, piece.coordinates).GetType())
                {
                    return piece;
                }
            }
            return null;
        }
    }
}

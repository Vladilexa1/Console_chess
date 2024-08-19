using Console_chess.board;
using Console_chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess
{
    public class StalemateGameChecker : GameStateChecker
    {
        public override GameState check(Board board, Color color)
        {
            List<Piece> pieces = board.getPiecesForColor(color);

            foreach (var piece in pieces)
            {
                HashSet<Coordinates> aviableMoveSquares = piece.getAviableMoveSquares(board);

                if (aviableMoveSquares.Count > 0)
                {
                    return GameState.ONGOING;
                }

            }

            return GameState.STALEMATE;
        }
    }
}

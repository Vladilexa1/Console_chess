using Console_chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess
{
    public class Game
    {
        private readonly Board board;

        private BoardConsoleRenderer renderer = new BoardConsoleRenderer();

        private InputCoorinates InputCoorinates = new InputCoorinates();

        public Game(Board board)
        {
            this.board = board;
        }

        public void gameLoop()
        {
            bool isWhiteToMove = true;
            if (isWhiteToMove)
            {
                Console.WriteLine("White to move");
            }
            else
            {
                Console.WriteLine("Black to move");
            }
            while (true)
            {
                renderer.Render(board);

               Coordinates soureCoordinates = InputCoorinates.inputPieceCoordinatesForColor
                   (
                     isWhiteToMove ? Color.WHITE : Color.BLACK, board
                   );

                Piece piece = board.getPiece(soureCoordinates);
                HashSet<Coordinates> aviableMoveSquares = piece.getAviableMoveSquares(board);
                renderer.Render(board, piece);
                Coordinates targetCoordinates = InputCoorinates.inputAviableSquare(aviableMoveSquares);
                board.movePiece(soureCoordinates, targetCoordinates);

                isWhiteToMove = !isWhiteToMove;
            }
        }
    }
}

using Console_chess.board;
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

        private List<GameStateChecker> checkers = new List<GameStateChecker>
        {
            new StalemateGameChecker(),
            new CheckmateGameStateChecker()
        };

        public Game(Board board)
        {
            this.board = board;
        }

        public void gameLoop()
        {
            bool isWhiteToMove = true;

            GameState state = determineGameState(board, isWhiteToMove ? Color.WHITE : Color.BLACK);

            while (state == GameState.ONGOING)
            {
                if (isWhiteToMove)
                {
                    Console.Clear();
                    Console.WriteLine("White to move");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Black to move");
                }
                renderer.Render(board);

                Move move = InputCoorinates.inputMove(board, isWhiteToMove ? Color.WHITE : Color.BLACK, renderer);

                // make move
                board.makeMove(move);
                
                // pass move
                isWhiteToMove = !isWhiteToMove;

                state = determineGameState(board, isWhiteToMove ? Color.WHITE : Color.BLACK);
            }
            renderer.Render(board);
            Console.WriteLine("Game end with state = " + state);
        }

        private GameState determineGameState(Board board, Color color)
        {
            foreach (var checker in checkers)
            {
                GameState state = checker.check(board, color);

                if (state != GameState.ONGOING)
                {
                    return state;
                }
            }
            return GameState.ONGOING;
        }
    }
}

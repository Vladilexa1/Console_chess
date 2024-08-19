using Console_chess.Pieces;
using Console_chess.board;

namespace Console_chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Board board = new BoardFactory().fromFEN("rnb1kbnr/pppp1ppp/4p3/8/6Pq/5P2/PPPPP2P/RNBQKBNR w KQkq - 0 1");
            Game game = new Game(board);
            game.gameLoop();
            Console.ReadLine();
        }
    }
}
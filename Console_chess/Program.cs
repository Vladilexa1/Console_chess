using Console_chess.Pieces;

namespace Console_chess
{
    
    
    
    class Program
    {
        
        
        
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Board board = new BoardFactory().fromFEN("3rkqr1/3pnnp1/3pbbp1/3pppp1/3PPPP1/3PBBP1/3PNNP1/3RKQR1 w - - 0 1");
            //BoardFactory boardFactory = 
           
            //BoardConsoleRenderer renderer = new BoardConsoleRenderer();
            //renderer.Render(boardFactory.fromFEN("3rkqr1/3pnnp1/3pbbp1/3pppp1/3PPPP1/3PBBP1/3PNNP1/3RKQR1 w - - 0 1"));
            //board.setupDefaultPiecesPositions();
            
            
            
            Game game = new Game(board);
            game.gameLoop();
            
           // renderer.Render(board);

         

            Console.ReadLine();
        }
    }
}
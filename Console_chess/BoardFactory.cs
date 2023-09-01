using Console_chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess
{
    class BoardFactory
    {
        private PieceFactory pieceFactory = new PieceFactory();
        public Board fromFEN(string fen)
        {
            //rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
            Board board = new Board();

            string[] parts = fen.Split(' ');
            string piecePositions = parts[0];
            
            string[] fenRows = piecePositions.Split('/');

            for (int i = 0; i < fenRows.Length; i++)
            {
                string row = fenRows[i];
                int rank = 8 - i;
                int fileIndex = 0;

                for (int j = 0; j < row.Length; j++)
                {
                    char fenChar = row[j];
                    if (Char.IsDigit(fenChar))
                    {
                        fileIndex += int.Parse(fenChar.ToString());
                    }
                    else
                    {
                        File file = (File)fileIndex;
                        Coordinates coordinates = new Coordinates(file, rank);
                        board.setPiese(coordinates, pieceFactory.fromFenChar(fenChar, coordinates));
                        fileIndex++;
                    }
                }
               
            }
            return board;
        }
    }
}

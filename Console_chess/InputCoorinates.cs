using Console_chess.board;
using Console_chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess
{
    public class InputCoorinates
    {
        
        public Coordinates input()
        {
            while (true)
            {
                
                Console.WriteLine("Please enter coorinates (ex. a1)");
                string input = Console.ReadLine();

                if (input.Length != 2)
                {
                    Console.WriteLine("Invalid format");
                    continue;
                }
                char fileChar = input.ToCharArray()[0];
                char rankChar = input.ToCharArray()[1];
                if (!Char.IsLetter(fileChar))
                {
                    Console.WriteLine("Invalid format");
                    continue;
                }
                if (!Char.IsNumber(rankChar))
                {
                    Console.WriteLine("Invalid format");
                    continue;
                }
                int rank = int.Parse(rankChar.ToString());
                if (rank < 1 || rank > 8)
                {
                    Console.WriteLine("Invalid format");
                    continue;
                }
                if (!Enum.TryParse<File>(fileChar.ToString().ToUpper(), out File file))
                {
                    Console.WriteLine("Invalid format");
                    continue;
                }
                return new Coordinates(file, rank);
            }
        }
        public Coordinates inputPieceCoordinatesForColor(Color color, Board board)
        {
            while (true)
            {
                Console.WriteLine("Enter coorinates for a piece to move");

                Coordinates coordinates = input();
                if (board.isSquareEmpty(coordinates))
                {
                    Console.WriteLine("Empty Square");
                    continue;
                }
                Piece piece = board.getPiece(coordinates);
                if (piece.color != color)
                {
                    Console.WriteLine("Wrong color");
                    continue;
                }
                HashSet<Coordinates> aviableMoveSquares = piece.getAviableMoveSquares(board);
                if (aviableMoveSquares.Count == 0)
                {
                    Console.WriteLine("Blocked piece");
                    continue;
                }
                return coordinates;
            }
        }
        public Coordinates inputAviableSquare(HashSet<Coordinates> coordinates)
        {
            while (true)
            {
                Console.WriteLine("Enter your move for selected piece");
                Coordinates input = this.input();

                if(!coordinates.Contains(input))
                {
                    Console.WriteLine("Non-aviable square");
                    continue;
                }
                return input;
            }
        }
        public static Move inputMove(Board board, Color color, BoardConsoleRenderer renderer) 
        {
            while (true)
            {
                InputCoorinates inputCoorinates = new InputCoorinates();
                Coordinates soureCoordinates = inputCoorinates.inputPieceCoordinatesForColor(color, board);

                Piece piece = board.getPiece(soureCoordinates);
                HashSet<Coordinates> aviableMoveSquares = piece.getAviableMoveSquares(board);

                renderer.Render(board, piece);
                Coordinates targetCoordinates = inputCoorinates.inputAviableSquare(aviableMoveSquares);

                Move move = new Move(soureCoordinates, targetCoordinates);
                if (validateIfKingInChackAfterMove(board, color, move))
                {
                    Console.WriteLine("Your King is under attack!");
                    continue;
                }
                return move;
            }
            
            
        }

        private static bool validateIfKingInChackAfterMove(Board board, Color color, Move move)
        {
            Board copy = (new BoardFactory()).copy(board);
            copy.makeMove(move);
            Piece king;
           
            foreach (var piece in copy.getPiecesForColor(color))
            {
                if (piece.GetType() == new King(piece.color, piece.coordinates).GetType())
                {
                    king = piece;
                   return copy.isSquareAttackedByColor(king.coordinates, swapColor(king.color));
                }
            }
            return false;
        }
        private static Color swapColor(Color color)
        {
            return color == Color.WHITE ? Color.BLACK : Color.WHITE;
        }
    }
}

using Console_chess.board;
using Console_chess.Pieces;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess
{
    public class BoardConsoleRenderer
    {
        public const string ANSI_RESET = "\u001B[0m";
        public const string ANSI_WHITE_PIECE_COLOR = "\u001B[97m";
        public const string ANSI_BLACK_PIECE_COLOR = "\u001B[30m";
        public const string ANSI_WHITE_SQUARE_BACKGROUN = "\u001B[47m";
        public const string ANSI_BLACK_SQUARE_BACKGROUN = "\u001B[0;100m";
        public const string ANSI_HIGHLIGHTED_SQUARE_BACKGROUN = "\u001B[0;45m";
        public void Render(Board board, Piece pieceToMove)
        {
            HashSet<Coordinates> aviableMoveSquares = new HashSet<Coordinates>();
            if (pieceToMove != null)
            {
                aviableMoveSquares = pieceToMove.getAviableMoveSquares(board);
            }
           

            for (int rank = 8; rank >= 1; rank--)
            {
                string line = "";

                foreach (File file in Enum.GetValues(typeof(File)))
                {
                    Coordinates coordinates = new Coordinates(file, rank);
                    bool isHighLight = aviableMoveSquares.Contains(coordinates);
                    if (board.isSquareEmpty(coordinates))
                    {
                        line += getSpringForEmptySquare(coordinates, isHighLight);
                    }
                    else
                    {
                        line += getPieceSprite(board.getPiece(coordinates), isHighLight);
                    }
                    Console.Write(line);
                    line = "";
                }
                line += ANSI_RESET;
                Console.WriteLine(ANSI_RESET);
                
            }
        }
        public void Render(Board board)
        {
            Render(board, null);
        }
        private string getPieceSprite(Piece piese, bool isHigtLight)
        {
            return colorizeSprite(sprite: " " + selectUnicodeSpriteForPiece(piese) + " ", piese.color, Board.isSquareDark(piese.coordinates), isHigtLight);
        }
        private string getSpringForEmptySquare(Coordinates coordinates, bool isHigtLight)
        {
            return colorizeSprite(sprite:"   ", Color.WHITE, Board.isSquareDark(coordinates), isHigtLight);
        }
        private string selectUnicodeSpriteForPiece(Piece piese)
        {
            switch (getSimpleName(piese))
            {
                case "Pawn":
                    return "♙";
                case "Bishop":
                    return "♗";
                case "Knight":
                    return "♘";
                case "Queen":
                    return "♕";
                case "Rook":
                    return "♖";
                case "King":
                    return "♔";
                default:  return "";
            }
        }
        private string colorizeSprite(string sprite, Color pieceColor, bool isSquareDark, bool isHigtLighted)
        {
            string result = sprite;

            if (pieceColor == Color.WHITE) //krasim figuri
            {
                result = ANSI_WHITE_PIECE_COLOR + result;
            }
            else
            {
                result = ANSI_BLACK_PIECE_COLOR + result;
            }
            if (isHigtLighted)
            {
                result = ANSI_HIGHLIGHTED_SQUARE_BACKGROUN + result;
            }
            else if (isSquareDark)
            {
                result = ANSI_BLACK_SQUARE_BACKGROUN + result;
            }
            else
            {
                result = ANSI_WHITE_SQUARE_BACKGROUN + result;
            }
            return result;
        }
        private string getSimpleName(object obj)
        {
            Type type = obj.GetType();
            return type.Name;
        }
    }
}

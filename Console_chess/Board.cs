using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Console_chess.Pieces;

namespace Console_chess
{
    public class Board
    {
        Dictionary<Coordinates, Piece> pieces = new Dictionary<Coordinates, Piece>();
       
        public void remuvePiece(Coordinates coordinates)
        {
            pieces.Remove(coordinates);
        }
        public void movePiece(Coordinates from, Coordinates to) 
        {
            Piece piece = getPiece(from);
            
            remuvePiece(from);
            setPiese(to, piece);
        }

        public void setPiese(Coordinates coordinates, Piece piese)
        {
            piese.coordinates = coordinates;
            try
            {
                pieces.Add(coordinates, piese);
            }
            catch (Exception)
            {
                pieces[coordinates] = piese;
            }
            
            
        }
        public void setupDefaultPiecesPositions()
        {
            // set pawns
            foreach (File file in Enum.GetValues(typeof(File)))
            {
                setPiese(new Coordinates(file, rank: 2), new Pawn(Color.WHITE, new Coordinates(file, rank: 2)));
                setPiese(new Coordinates(file, rank: 7), new Pawn(Color.BLACK, new Coordinates(file, rank: 7)));
            }
            // set rook
            setPiese(new Coordinates(File.A, rank: 1), new Rook(Color.WHITE, new Coordinates(File.A, rank: 1)));
            setPiese(new Coordinates(File.H, rank: 1), new Rook(Color.WHITE, new Coordinates(File.H, rank: 1)));
            setPiese(new Coordinates(File.A, rank: 8), new Rook(Color.BLACK, new Coordinates(File.A, rank: 8)));
            setPiese(new Coordinates(File.H, rank: 8), new Rook(Color.BLACK, new Coordinates(File.H, rank: 8)));
            // set knight
            setPiese(new Coordinates(File.B, rank: 1), new Knight(Color.WHITE, new Coordinates(File.B, rank: 1)));
            setPiese(new Coordinates(File.G, rank: 1), new Knight(Color.WHITE, new Coordinates(File.G, rank: 1)));
            setPiese(new Coordinates(File.B, rank: 8), new Knight(Color.BLACK, new Coordinates(File.B, rank: 8)));
            setPiese(new Coordinates(File.G, rank: 8), new Knight(Color.BLACK, new Coordinates(File.G, rank: 8)));
            // set bishop
            setPiese(new Coordinates(File.C, rank: 1), new Bishop(Color.WHITE, new Coordinates(File.C, rank: 1)));
            setPiese(new Coordinates(File.F, rank: 1), new Bishop(Color.WHITE, new Coordinates(File.F, rank: 1)));
            setPiese(new Coordinates(File.C, rank: 8), new Bishop(Color.BLACK, new Coordinates(File.C, rank: 8)));
            setPiese(new Coordinates(File.F, rank: 8), new Bishop(Color.BLACK, new Coordinates(File.F, rank: 8)));
            // set queens
            setPiese(new Coordinates(File.D, rank: 1), new Queen(Color.WHITE, new Coordinates(File.D, rank: 1)));
            setPiese(new Coordinates(File.D, rank: 8), new Queen(Color.BLACK, new Coordinates(File.D, rank: 8)));
            // set king
            setPiese(new Coordinates(File.E, rank: 1), new King(Color.WHITE, new Coordinates(File.E, rank: 1)));
            setPiese(new Coordinates(File.E, rank: 8), new King(Color.BLACK, new Coordinates(File.E, rank: 8)));
        }
        public static bool isSquareDark(Coordinates coordinates)
        {
            return (((((int)coordinates.file) + 1) + coordinates.rank) % 2) == 0;
        }
        public bool isSquareEmpty(Coordinates coordinates)
        {
            return !searchHashDictionary(coordinates);
        }
        public Piece getPiece(Coordinates coordinates)
        {
            return pieces[coordinates];
        }
        private bool searchHashDictionary(Coordinates coordinates)
        {
            foreach (var item in pieces)
            {
                if (item.Key.GetHashCode() == coordinates.GetHashCode())
                {
                    return true;
                }
            }
            return false;
        }
    }
}

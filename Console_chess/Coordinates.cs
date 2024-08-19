using Console_chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Console_chess.board;

namespace Console_chess
{
    public class Coordinates
    {
        public File file;
        public int rank;
        public Coordinates(File file, int rank)
        {
            this.file = file;
            this.rank = rank;
        }



        public Coordinates shift(CoordinatesShift shift) // проверить
        {
            return new Coordinates(this.file + shift.fileShift, rank: this.rank + shift.rankShift);
        }
        public bool canShift(CoordinatesShift shift) // проверить
        {
            int f = (int)file + shift.fileShift;
            int r = rank + shift.rankShift;

            if (f < 0 || f > 7) return false; 
            if (r < 1 || r > 8) return false;
            return true;
        }


        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            Coordinates that = (Coordinates)obj;
            if (file != that.file) return false;
            return rank.Equals(that.rank);
        }
        public override int GetHashCode()
        {
            int result = file.GetHashCode();
            result = 31 * result + rank.GetHashCode();
            return result;
        }
    }
}

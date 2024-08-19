using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess.board
{
    public class BoardUtils
    {
        public static List<Coordinates> getDiagonalCoordinatesBetween(Coordinates source, Coordinates target)
        {
            // допущение - клетки лежат на одной диагонали

            List<Coordinates> result = new List<Coordinates>();

            int fileShift = source.file < target.file ? 1 : -1;
            int rankShift = source.rank < target.rank ? 1 : -1;

            for (
                    int fileIndex = (int)source.file + fileShift,
                    rank = source.rank + rankShift;

                    fileIndex != (int)target.file && rank != target.rank;

                    fileIndex += fileShift, rank += rankShift
                )
            {
                result.Add(new Coordinates(file: (File)fileIndex, rank));
            }

            return result;
        }
        public static List<Coordinates> getVerticalCoordinatesBetween(Coordinates source, Coordinates target)
        {
            // допущение, клетки лежат на одной вертикали

            List<Coordinates> result = new List<Coordinates>();


            int rankShift = source.rank < target.rank ? 1 : -1;

            for (
                    int rank = source.rank + rankShift;

                    rank != target.rank;

                    rank += rankShift
                )
            {
                result.Add(new Coordinates(source.file, rank));
            }

            return result;
        }
        public static List<Coordinates> getHorisontalCoordinatesBetween(Coordinates source, Coordinates target)
        {
            // допущение, клетки лежат на одной горизонтали

            List<Coordinates> result = new List<Coordinates>();


            int fileShift = source.file < target.file ? 1 : -1;

            for (
                    int fileIndex = (int)source.file + fileShift;

                    fileIndex != (int)target.file;

                    fileIndex += fileShift
                )
            {
                result.Add(new Coordinates(file: (File)fileIndex, source.rank));
            }

            return result;
        }
    }
}

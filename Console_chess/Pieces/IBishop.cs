using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess.Pieces
{
    interface IBishop
    {
       HashSet<CoordinatesShift> getBishopMoves()
       {
            HashSet<CoordinatesShift> result = new HashSet<CoordinatesShift>();
            // bottom-left to top-right
            for (int i = -7; i < 7; i++)
            {
                if (i == 0) continue;

                result.Add(new CoordinatesShift(i, i));
            }
            // bottom-right to top-left
            for (int i = -7; i < 7; i++)
            {
                if (i == 0) continue;

                result.Add(new CoordinatesShift(i, -i));
            }
            return result;
       }
    }
}

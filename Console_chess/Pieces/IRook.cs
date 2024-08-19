﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess.Pieces
{
    interface IRook
    {
        HashSet<CoordinatesShift> getRookMoves()
        {
            HashSet<CoordinatesShift> result = new HashSet<CoordinatesShift>();
            // left to right
            for (int i = -7; i < 7; i++)
            {
                if (i == 0) continue;

                result.Add(new CoordinatesShift(i, 0));
            }
            // bottom to top
            for (int i = -7; i < 7; i++)
            {
                if (i == 0) continue;

                result.Add(new CoordinatesShift(0, i));
            }
            return result;
        }
    }
}

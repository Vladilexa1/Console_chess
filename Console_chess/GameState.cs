using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess
{
    public enum GameState
    {
        ONGOING,
        STALEMATE, 
        CHECKMATE_TO_WHITE_KING,
        CHECKMATE_TO_BLACK_KING
    }
}

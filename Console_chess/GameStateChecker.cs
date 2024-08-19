using Console_chess.board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_chess
{
    public abstract class GameStateChecker
    {
        public abstract GameState check(Board board, Color color);
    }
}

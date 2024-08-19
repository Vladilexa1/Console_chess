namespace Console_chess.board
{
    public class Move
    {
        public Coordinates from;
        public Coordinates to;

        public Move(Coordinates from, Coordinates to)
        {
            this.from = from;
            this.to = to;
        }


    }
}
namespace Console_chess.Pieces
{
    public class CoordinatesShift
    {
        public readonly int fileShift;
        public readonly int rankShift;

        public CoordinatesShift(int fileShift, int rankShift)
        {
            this.fileShift = fileShift;
            this.rankShift = rankShift;
        }
    }
}
namespace CMD_Checkers.Model.Core
{
    public abstract class APawn
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Team { get; private set; }
        protected APawn(int x, int y, char team)
        {
            X = x;
            Y = y;
            Team = team;
        }

        public abstract bool CanMove(int toX, int toY);
        public abstract bool IsKing();
    }
}
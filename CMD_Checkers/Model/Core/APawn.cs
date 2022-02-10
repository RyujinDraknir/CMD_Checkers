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

        public virtual bool CanMove(int toX, int toY, int gridSize)
        {
            return ((toX < gridSize)
                && (toX >= 0)
                && (toY < gridSize)
                && (toY >= 0));
        }
        public abstract bool IsKing();
    }
}
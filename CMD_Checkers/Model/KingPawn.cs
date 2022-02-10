using CMD_Checkers.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD_Checkers.Model
{
    public class KingPawn : APawn
    {
        public KingPawn(int x, int y, char team) : base(x, y, team)
        {
        }

        public override bool CanMove(int toX, int toY)
        {
            return ((toX == X + 1) || (toX == X - 1)) && ((toY == Y + 1) || (toY == Y - 1));
        }
        public override bool IsKing()
        {
            return true;
        }
    }
}

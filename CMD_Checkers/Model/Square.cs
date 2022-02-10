using CMD_Checkers.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD_Checkers.Model
{
    public class Square
    {
        public APawn Pawn { get; set; }
        public Square()
        {
            Pawn = null;
        }

        public APawn IsOccupiedBy()
        {
            return Pawn;
        }
        public bool IsOccupied()
        {
            return Pawn != null;
        }


    }
}

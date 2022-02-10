using CMD_Checkers.Model.Core;
using System.Collections.Generic;

namespace CMD_Checkers.Model
{
    public class Player
    {
        public string UserName { get; private set; }
        public List<APawn> Pawns { get; private set; }
        public char Team { get; private set; }

        public Player(string userName, char team)
        {
            UserName = userName;
            Team = team;
            Pawns = new List<APawn>();
        }

        public void AddPawn(APawn pawn)
        {
            Pawns.Add(pawn);
        }

        public void RemovePawn(APawn pawn)
        {
            Pawns.Remove(pawn);
        }
    }
}
using CMD_Checkers.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD_Checkers.Model
{
    public class Grid
    {
        private const int ASCII_START_ALPHABET = 97;
        private int gridSize;
        public Square[,] Squares { get; private set; }
        public Grid(int size)
        {
            gridSize = size;
            Squares = new Square[gridSize, gridSize];

            for (int i = 0; i < gridSize; i++){
                for (int j = 0; j < gridSize; j++)
                {
                    Squares[i, j] = new Square();
                }
            }

        }

        public void SetPawn(APawn pawn)
        {
            Squares[pawn.X, pawn.Y].Pawn = pawn;
        }

        public override string ToString()
        {
            string gridString = "    ";

            for (int i = 1; i <= gridSize; i++)
            {
                if (i != 1)
                    gridString += "   ";
                gridString += i;
            }
            gridString += "\n";

            for (int i = 0; i <= gridSize; i++)
            {
                gridString += "  ";
                for (int j = 1; j <= gridSize; j++)
                {
                    if (i == 0 && j == 1)
                        gridString += "╔";
                    else if (i == gridSize && j == 1)
                        gridString += "╚";
                    else if (i == 0)
                        gridString += "╦";
                    else if (i == gridSize)
                        gridString += "╩";
                    else if (j == 1)
                        gridString += "╠";
                    else
                        gridString += "╬";

                    gridString += "═══";

                    if (i == 0 && j == gridSize)
                        gridString += "╗";
                    else if (i == gridSize && j == gridSize)
                        gridString += "╝";
                    else if (j == gridSize)
                        gridString += "╣";
                }

                if (i != gridSize)
                {
                    gridString += "\n";
                    gridString += ((char)(i + ASCII_START_ALPHABET)) + " ";
                    gridString += "║";
                    for (int j = 0; j < gridSize; j++)
                    {
                        gridString += " ";
                        if (!Squares[i, j].IsOccupied())
                            gridString += " ";
                        else
                        {
                            APawn pawn = Squares[i, j].IsOccupiedBy();
                            if (pawn.IsKing())
                                gridString += ("" + pawn.Team).ToUpper();
                            else
                                gridString += ("" + pawn.Team).ToLower();
                        }
                        gridString += " ║";
                    }
                }
                gridString += "\n";
            }

            return gridString;
        }
    }
}

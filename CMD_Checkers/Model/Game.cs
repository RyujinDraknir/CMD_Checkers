using CMD_Checkers.Model.Core;
using CMD_Checkers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMD_Checkers.Model
{
    public class Game
    {
        private const int ASCII_START_ALPHABET = 97;
        private const int DEFAULT_GRID_SIZE = 8;
        private const int DEFAULT_PAWN_LINE = 3;
        private const char DEFAULT_PLAYER_ONE_TEAM = 'w';
        private const char DEFAULT_PLAYER_TWO_TEAM = 'n';

        private int GridSize;
        private int PawnLine;
        private char PlayerOneTeam;
        private char PlayerTwoTeam;
        public Player PlayerOne { get; private set; }
        public Player PlayerTwo { get; private set; }
        public Grid Grid { get; private set; }
        public AskerService AskerService { get; set; }
        public PrinterService PrinterService { get; set; }

        public Game(
            AskerService askerService,
            PrinterService printerService,
            int gridSize = DEFAULT_GRID_SIZE,
            int pawnLine = DEFAULT_PAWN_LINE,
            char playerOneChar = DEFAULT_PLAYER_ONE_TEAM,
            char playerTwoChar = DEFAULT_PLAYER_TWO_TEAM
            )
        {
            GridSize = gridSize;
            PawnLine = pawnLine;
            PlayerOneTeam = playerOneChar;
            PlayerTwoTeam = playerTwoChar;
            AskerService = askerService;
            PrinterService = printerService;

            InitializePlayer();
            InitializeGrid();
            InitializePawns();
            PrinterService.Print(Grid.ToString());

            //Start();
        }

        private void Start()
        {
            Player winner = null;

            while (winner == null)
            {
                PlayTurn(PlayerOne);
            }

        }

        private void PlayTurn(Player player)
        {
            PrinterService.Clear();

            string selectPawn = AskerService.Ask("Enter the coordinates of the pawn you want to move (example: a1) : ");
            string toPawn = AskerService.Ask("Enter the coordinates of where you want to move your pawn (example: b2) : ");
        }

        private bool MovePawn(Player player, string movePawn, string to)
        {
            movePawn = movePawn.ToLower().Trim();
            to = to.ToLower().Trim();
            bool validParam = Regex.IsMatch(movePawn, "[a-z][1-9]") && Regex.IsMatch(to, "[a-z][1-9]");

            int x = movePawn.ToCharArray()[0] - ASCII_START_ALPHABET;
            int y = movePawn.ToCharArray()[1];

            int toX = to.ToCharArray()[0] - ASCII_START_ALPHABET;
            int toY = to.ToCharArray()[1];

            validParam = validParam && x < GridSize && toX < GridSize && y < GridSize && toY < GridSize;

            if (!validParam)
                return false;

            APawn pawn = Grid.Squares[x, y].Pawn;

            if(pawn == null || !pawn.CanMove(toX, toY, GridSize))
                return false;



            return true;

        }

        private Player CheckWinner()
        {
            if (PlayerOne.Pawns.Count() == 0)
                return PlayerTwo;
            if (PlayerTwo.Pawns.Count() == 0)
                return PlayerOne;

            return null;
        }

        #region Initialization

        private void InitializePlayer()
        {
            string username = AskerService.Ask("Enter the UserName of the 1st player : \n");
            PlayerOne = new(username, PlayerOneTeam);

            username = AskerService.Ask("Enter the UserName of the 2nd player : \n");

            while (username.ToUpper().Equals(PlayerOne.UserName.ToUpper()))
            {
                PrinterService.Print("Error the username is the same than player one."
                     + "\n" + "Try Again");
                username = AskerService.Ask("Enter the UserName of the 2nd player : \n");
            }
            PlayerTwo = new(username, PlayerTwoTeam);
        }
        private void InitializeGrid()
        {
            Grid = new Grid(GridSize);
        }
        private void InitializePawns()
        {
            for (int i = 0; i < Grid.Squares.Length; i++)
            {
                bool isInLines = (i > (Grid.Squares.Length - (GridSize * PawnLine) - 1));
                if((i / GridSize) % 2 == ((i + 1) % 2) && isInLines)
                {
                        WhitePawn pawn = new WhitePawn(i / 8, i % 8, PlayerOneTeam);
                        Grid.SetPawn(pawn);
                        PlayerOne.AddPawn(pawn);
                }
            }


            for (int i = 0; i < Grid.Squares.Length; i++)
            {
                bool isInLines = (i < GridSize * PawnLine);
                if ((i / GridSize) % 2 == ((i + 1) % 2) && isInLines)
                {
                        BlackPawn pawn = new BlackPawn(i / 8, i % 8, PlayerTwoTeam);
                        Grid.SetPawn(pawn);
                        PlayerTwo.AddPawn(pawn);
                }
            }
        }

        #endregion
    }
}

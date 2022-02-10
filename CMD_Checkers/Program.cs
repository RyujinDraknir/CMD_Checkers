using CMD_Checkers.Model;
using CMD_Checkers.Services;
using System;

namespace CMD_Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            PrinterService printer = new PrinterService();
            AskerService asker = new AskerService();

            Game game = new Game(asker, printer);
        }
    }
}

using CMD_Checkers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD_Checkers.Services
{
    public class PrinterService
    {
        public void Print(string str)
        {
            Console.WriteLine(str);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}

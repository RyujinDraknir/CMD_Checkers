using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD_Checkers.Services
{
    public class AskerService
    {
        public string Ask(string question)
        {
            Console.WriteLine(question);
            string result = Console.ReadLine();

            while (String.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine("NullInput : Try Again");
                Console.WriteLine(question);
                result = Console.ReadLine();
            }
            return result;
        }

        public void WaitForInput()
        {
            Console.ReadLine();
        }
    }
}

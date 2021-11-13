using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kck1
{
    static class View
    {
        public static void MainMenuHeader(string[] str)
        {
            foreach (var x in str)
                Console.WriteLine("\t" + x);
        }
        public static void InstructionsHeader(string[] str)
        {
            foreach (var x in str)
                Console.WriteLine("\t\t\t\t\t\t\t\t" + x);
        }
        public static void WriteInstructions()
        {

        }
        public static void TournamentHeader()
        {

        }
    }
}

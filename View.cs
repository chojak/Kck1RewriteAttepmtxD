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
                Console.WriteLine("\t\t\t\t\t" + x);
        }
        public static void WriteInstructions()
        {

        }
        public static void TournamentHeader(string[] str)
        {
            foreach(var x in str)
                Console.WriteLine("\t\t\t\t\t  " + x);
        }
        public static void PrintScoreboard(int s, ref int GuaranteedPrize)
        {
            int score = 11 - s;
            int cursortop = 5;
            int cursorleft = 70;

            string[] rewards = { "1 000 000", "500 000", "250 000", "125 000", "75 000", "40 000", "20 000", "10 000", "5000", "2000", "1000", "500" };

            if (s == 1)
                GuaranteedPrize = 1000;
            if (s == 6)
                GuaranteedPrize = 40000;

            Console.SetCursorPosition(cursorleft, cursortop - 1);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Gwarantowana wygrana - " + GuaranteedPrize);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(cursorleft, cursortop);
            for (int i = 0; i < 12; i++)
            {
                if (i == 0 || i == 5 || i == 10)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (i == score)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(rewards[i]);
                Console.SetCursorPosition(cursorleft, ++cursortop);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        public static void PrintQuestion(string str)
        {
            int left = 8;
            Console.SetCursorPosition(left, 5);
            Console.WriteLine(new String(' ', 53));
            Console.SetCursorPosition(left, 5);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" ? " + str + " ? ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static int Options(int CursorTop)
        {
            CursorTop += 2;
            int option = 0;
            while (true)
            {
                switch (option)
                {
                    case 0:
                        Console.SetCursorPosition(8, CursorTop);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Start!");
                        Console.SetCursorPosition(8 + 40, CursorTop);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Instruction");
                        Console.SetCursorPosition(8 + 80, CursorTop);
                        Console.WriteLine("Quit");
                        break;

                    case 1:
                        Console.SetCursorPosition(8, CursorTop);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Start!");
                        Console.SetCursorPosition(8 + 40, CursorTop);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Instruction");
                        Console.SetCursorPosition(8 + 80, CursorTop);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Quit");
                        break;

                    case 2:
                        Console.SetCursorPosition(8, CursorTop);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("Start!");
                        Console.SetCursorPosition(8 + 40, CursorTop);
                        Console.WriteLine("Instruction");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(8 + 80, CursorTop);
                        Console.WriteLine("Quit");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;

                    default:
                        break;
                }
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.RightArrow)
                    option = ++option % 3;

                if (key == ConsoleKey.LeftArrow)
                {
                    option--;
                    if (option == -1)
                        option = 2;
                }
                if (key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(8, CursorTop);
                    return option;
                }
            }
        }
        public static char TournamentOptions(Question Question, int CursorTop)
        {
            CursorTop += 2;
            int option = 0;
            int left = 12;

            bool FiftyFifty = false;
            bool QuestionToAudience = false;
            bool HelpCall = false;

            Console.SetCursorPosition(10, CursorTop);
            Console.Write(new String(' ', 53));
            Console.SetCursorPosition(10, CursorTop + 1);
            Console.Write(new String(' ', 53));
            Console.SetCursorPosition(10, CursorTop + 2);
            Console.Write(new String(' ', 53));
            Console.SetCursorPosition(10, CursorTop + 3);
            Console.Write(new String(' ', 53));

            

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(left, CursorTop);
                Console.WriteLine(Question.OptionA);
                Console.SetCursorPosition(left + 20, CursorTop);
                Console.WriteLine(Question.OptionB);
                Console.SetCursorPosition(left, CursorTop + 2);
                Console.WriteLine(Question.OptionC);
                Console.SetCursorPosition(left + 20, CursorTop + 2);
                Console.WriteLine(Question.OptionD);
                Console.SetCursorPosition(left - 4, CursorTop + 5);
                Console.WriteLine("Kola Ratunkowe: ");
                Console.SetCursorPosition(left - 3, CursorTop + 6);
                Console.WriteLine("1. 50/50");
                Console.SetCursorPosition(left - 3, CursorTop + 7);
                Console.WriteLine("2. Głos publiczności");
                Console.SetCursorPosition(left - 3, CursorTop + 8);
                Console.WriteLine("3. Telefon do przyjaciela");
                switch (option)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left, CursorTop);
                        Console.WriteLine(Question.OptionA);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left + 20, CursorTop);
                        Console.WriteLine(Question.OptionB);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left, CursorTop + 2);
                        Console.WriteLine(Question.OptionC);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left + 20, CursorTop + 2);
                        Console.WriteLine(Question.OptionD);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left - 4, CursorTop + 5);
                        Console.WriteLine("Kola Ratunkowe: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left - 3, CursorTop + 6);
                        Console.WriteLine("1. 50/50");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left - 3, CursorTop + 7);
                        Console.WriteLine("2. Głos publiczności");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left - 3, CursorTop + 8);
                        Console.WriteLine("3. Telefon do przyjaciela");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.DownArrow)
                {
                    option = option == 0 ? 2 : option;
                    option = option == 1 ? 3 : option;
                    option = option == 
                }
                
                if (key == ConsoleKey.UpArrow)
                {
                    option = option == 2 ? 0 : option;
                    option = option == 3 ? 1 : option;
                }

                if (key == ConsoleKey.LeftArrow)
                {
                    option = option == 1 ? 0 : option;
                    option = option == 3 ? 2 : option;
                }
                if (key == ConsoleKey.RightArrow)
                {
                    option = option == 0 ? 1 : option;
                    option = option == 2 ? 3 : option;
                }
                if (key == ConsoleKey.Enter)
                {
                    if (option == 0)
                        return 'a';
                    if (option == 1)
                        return 'b';
                    if (option == 2)
                        return 'c';
                    if (option == 3)
                        return 'd';
                }
            }
        }
        public static void Win()
        {

        }
        public static void Lose(Question Question, char CorrectAnswer, int Prize)
        {
            Console.SetCursorPosition(60, 20);
            Console.WriteLine("Przegrales, poprawna odpowiedz to: " + Question.CorrectAnswer);
            Console.SetCursorPosition(60, 21);
            Console.Write("Wygrana: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Prize);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}

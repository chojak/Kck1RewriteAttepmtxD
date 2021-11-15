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
            Console.SetCursorPosition(4, 5);
            Console.WriteLine("\tMilionerzy - gra teleturniej.\n\n" +
                              "\tGra polega na odpowiadaniu na podane pytania w celu zdobycia głównej nagrody - miliona!!\n" +
                              "\tDo każdego pytania musimy wskazać jedną poprawną odpowiedź\n\n" +
                              "\tW razie problemów przychodzą nam z pomocą koła ratunkowe, które mamy 3 i każde możemy użyć tylko raz\n\n" +
                              "\tW grze posiadamy także gwarantowane nagrody powiązane z nagrodą\n" +
                              "\tJeśli źle odpowiemy na pytanie za 75000, mamy gwarantowane 40000 itp.\n" +
                              "\tMożemy w każdej chwili zrezygnować z rozgrywki, wówczas skończymy z aktualnie zdobytą ilością punktów\n" +
                              "\tNawigujemy po menu za pomocą strzałek, oraz zatwierdzamy nasz wybór przy pomocy klawisza Enter");
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

            string[] rewards = { "1000000", "500000", "250000", "125000", "75000", "40000", "20000", "10000", "5000", "2000", "1000", "500" };

            if (s == 1)
                GuaranteedPrize = 1000;
            if (s == 6)
                GuaranteedPrize = 40000;
            if (s == 11)
                GuaranteedPrize = 1000000;

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
            Console.WriteLine(new String(' ', 55));
            Console.SetCursorPosition(left, 5);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" ? " + str + " ? ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static int Options(int CursorTop, ref string Name)
        {
            Console.WriteLine("\n\n" + new String('-', 110));
            int left = 10;
            CursorTop += 2;
            int option = 0;
            if (Name == "")
                Name = "Log in";
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(left, CursorTop);
                Console.WriteLine("Start!");
                Console.SetCursorPosition(left + 20, CursorTop);
                Console.WriteLine(Name);
                Console.SetCursorPosition(left + 40, CursorTop);
                Console.WriteLine("Hall of fame");
                Console.SetCursorPosition(left + 65, CursorTop);
                Console.WriteLine("Instruction");
                Console.SetCursorPosition(left + 85, CursorTop);
                Console.WriteLine("Quit");
                switch (option)
                {
                    case 0:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left, CursorTop);
                        Console.WriteLine("Start!");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;

                    case 1:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left + 20, CursorTop);
                        Console.WriteLine(Name);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;

                    case 2:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left + 40, CursorTop);
                        Console.WriteLine("Hall of fame");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;

                    case 3:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left + 65, CursorTop);
                        Console.WriteLine("Instruction");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;

                    case 4:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left + 85, CursorTop);
                        Console.WriteLine("Quit");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;

                    default:
                        break;
                }
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.RightArrow)
                    option = ++option % 5;

                if (key == ConsoleKey.LeftArrow)
                {
                    option--;
                    if (option == -1)
                        option = 4;
                }
                if (key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(8, CursorTop);
                    return option;
                }
            }
        }
        public static void LogInHeader(string[] str)
        {
            foreach (var x in str)
                Console.WriteLine("\t\t\t\t\t     " + x);
        }
        public static char TournamentOptions(Question Question, int CursorTop, ref bool FirstHelp, ref bool SecondHelp, ref bool ThirdHelp)
        {
            CursorTop += 2;
            int option = 0;
            int left = 4;

            string Help1 = FirstHelp == true ? "1. 50/50" : "ZUŻYTE                     ";
            string Help2 = SecondHelp == true ? "2. Głos publiczności" : "ZUŻYTE                           ";
            string Help3 = ThirdHelp == true ? "3. Telefon do przyjaciela" : "ZUŻYTE                       ";


            Console.SetCursorPosition(8, CursorTop + 10);
            Console.Write("                                                       ");

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
                Console.SetCursorPosition(left + 28, CursorTop);
                Console.WriteLine(Question.OptionB);
                Console.SetCursorPosition(left, CursorTop + 2);
                Console.WriteLine(Question.OptionC);
                Console.SetCursorPosition(left + 28, CursorTop + 2);
                Console.WriteLine(Question.OptionD);
                Console.SetCursorPosition(left - 4, CursorTop + 5);
                Console.WriteLine("Kola Ratunkowe: ");
                Console.SetCursorPosition(left - 3, CursorTop + 6);
                Console.WriteLine(Help1);
                Console.SetCursorPosition(left - 3, CursorTop + 7);
                Console.WriteLine(Help2);
                Console.SetCursorPosition(left - 3, CursorTop + 8);
                Console.WriteLine(Help3);
                Console.SetCursorPosition(left - 3, CursorTop + 12);
                Console.WriteLine("Rezygnuj");
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
                        Console.SetCursorPosition(left + 28, CursorTop);
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
                        Console.SetCursorPosition(left + 28, CursorTop + 2);
                        Console.WriteLine(Question.OptionD);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left - 3, CursorTop + 6);
                        Console.WriteLine(Help1);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left - 3, CursorTop + 7);
                        Console.WriteLine(Help2);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left - 3, CursorTop + 8);
                        Console.WriteLine(Help3);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left - 3, CursorTop + 12);
                        Console.WriteLine("Rezygnuj");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.DownArrow)
                {
                    if (option == 0)
                        option = 2;
                    else if (option == 1)
                        option = 3;
                    else if (option == 2 || option == 3)
                        option = 4;
                    else if (option == 4)
                        option = 5;
                    else if (option == 5)
                        option = 6;
                    else if (option == 6)
                        option = 7;
                }
                
                if (key == ConsoleKey.UpArrow)
                {
                    option = option == 2 ? 0 : option;
                    option = option == 3 ? 1 : option;
                    option = option == 4 ? 2 : option;
                    option = option == 5 ? 4 : option;
                    option = option == 6 ? 5 : option;
                    option = option == 7 ? 6 : option;
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
                    if (option == 4)
                    {
                        Program.FirstHelp(FirstHelp, Question, CursorTop);
                        FirstHelp = false;
                    }
             
                    if (option == 5)
                    {
                        Program.SecondHelp(SecondHelp, Question, CursorTop);
                        SecondHelp = false;
                    }
                    if (option == 6)
                    {
                        Program.ThirdHelp(ThirdHelp, Question, CursorTop);
                        ThirdHelp = false;
                    }
                    if (option == 7)
                        return 's';
                }
            }
        }
        public static void Win(string Prize)
        {
            Program.SaveProgress(int.Parse(Prize));
            Console.SetCursorPosition(60, 20);
            if (Prize == "1000000")
            {
                Console.WriteLine("ZOSTAŁEŚ MILIONEREM!!");
            }
            else
            {
                Console.WriteLine("Udalo Ci się wygrać: {0}", Prize);
            }
            Console.ReadKey();
            Console.ReadKey();

            Environment.Exit(0);
        }
        public static void Lose(Question Question, char CorrectAnswer, int Prize)
        {
            Program.SaveProgress(Prize);
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

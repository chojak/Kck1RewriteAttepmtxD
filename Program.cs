using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kck1
{
    class Program
    {
        static public List<Question> Questions = new List<Question>();
        static string[] MilionerzyHeader = {
                                    @" ╔------------------------------------------------------------------------------------------╗ ",
                                    @" |                                                                                          | ",
                                    @" |    /$$      /$$ /$$ /$$ /$$                                                              | ",
                                    @" |   | $$$    /$$$|__/| $$|__/                                                              | ",
                                    @" |   | $$$$  /$$$$ /$$| $$ /$$  /$$$$$$  /$$$$$$$   /$$$$$$   /$$$$$$  /$$$$$$$$ /$$   /$$  | ",
                                    @" |   | $$ $$/$$ $$| $$| $$| $$ /$$__  $$| $$__  $$ /$$__  $$ /$$__  $$|____ /$$/| $$  | $$  | ",
                                    @" |   | $$  $$$| $$| $$| $$| $$| $$  \ $$| $$  \ $$| $$$$$$$$| $$  \__/   /$$$$/ | $$  | $$  | ",
                                    @" |   | $$\  $ | $$| $$| $$| $$| $$  | $$| $$  | $$| $$_____/| $$        /$$__/  | $$  | $$  | ",
                                    @" |   | $$ \/  | $$| $$| $$| $$|  $$$$$$/| $$  | $$|  $$$$$$$| $$       /$$$$$$$$|  $$$$$$$  | ",
                                    @" |   |__/     |__/|__/|__/|__/ \______/ |__/  |__/ \_______/|__/      |________/ \____  $$  | ",
                                    @" |                                                                               /$$  | $$  | ",
                                    @" |                                                                              |  $$$$$$/  | ",
                                    @" |                                                                               \______/   | ",
                                    @" |                                                                                          | ",
                                    @" ╚------------------------------------------------------------------------------------------╝ "};
        static string[] InstructionsHeader = {
                "╔-------------------------╗",        // ?? maybe rules
                "| I N S T R U C T I O N S |",
                "╚-------------------------╝"};
        static string[] Tournament = {
                "╔---------------------╗",
                "| T O U R N A M E N T |",
                "╚---------------------╝"};
        static int GuaranteedPrize = 0;
        static int Score = 0;
        static void LoadQuestions(ref List<Question> Questions, string path)
        {
            try
            {
                string[] TempQuestions = System.IO.File.ReadAllLines(path);
                for(int i = 0; i < TempQuestions.Length; i += 7)
                {
                    Questions.Add(new Question(i, TempQuestions));
                }
            }
            catch (InvalidOperationException e)
            {
                throw new Exception("Could not load a file: " + e);
            }
        }
        static Question PickRandomQuestion(ref List<Question> Questions)
        {
            var Rand = new Random();
            var RandIndex = Rand.Next(0, Questions.Count / 7) * 7;

            var PickedQuestion = Questions.ElementAt(RandIndex);
            Questions.RemoveAt(RandIndex);
            return PickedQuestion;
        }
        static void Game()
        {

        }
        static void Instructions()
        {
            Console.Clear();
            View.InstructionsHeader(InstructionsHeader);
            SelectMode(Options(Console.CursorTop));
        }
        static int Options(int CursorTop)
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
        static void SelectMode(int Option)
        {
            Console.CursorVisible = false;
            switch (Option)
            {
                case 0: // start
                    Game();
                    break;

                case 1: // instructions
                    Instructions();
                    break;

                case 2: // quit
                    SelectMode(Options(Console.CursorTop));
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(110, 30);
            LoadQuestions(ref Questions, "quiz.txt");
            View.MainMenuHeader(MilionerzyHeader);
            SelectMode(Options(Console.CursorTop));
        }
    }
}

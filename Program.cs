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
        static int Score = -1;
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
            Console.Clear();
            View.TournamentHeader(Tournament);
            bool result = true;
            char GuessedAnswer;
            Question CurrentQuestion;

            while (true)
            {
                View.PrintScoreboard(Score, ref GuaranteedPrize);
                CurrentQuestion = PickRandomQuestion(ref Questions);
                View.PrintQuestion(CurrentQuestion.Content);
                GuessedAnswer = View.TournamentOptions(CurrentQuestion, Console.CursorTop);
                result = GuessedAnswer == CurrentQuestion.CorrectAnswer ? true : false;
                Score++;
                if (Score == 12 || result == false)
                    break;
            }
            if (result == false)
                View.Lose(CurrentQuestion, GuessedAnswer, GuaranteedPrize);
            if (Score == 12)
            {
                View.PrintScoreboard(Score, ref GuaranteedPrize);
                View.Win();
            }
        }
        static void Instructions()
        {
            Console.Clear();
            View.InstructionsHeader(InstructionsHeader);
            SelectMode(View.Options(Console.CursorTop));
        }
        static void SelectMode(int Option)
        {
            switch (Option)
            {
                case 0: // start
                    Game();
                    break;

                case 1: // instructions
                    Instructions();
                    break;

                case 2: // quit
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            LoadQuestions(ref Questions, "quiz.txt");

            Console.SetWindowSize(110, 25);
            Console.CursorVisible = false;
            View.MainMenuHeader(MilionerzyHeader);
            SelectMode(View.Options(Console.CursorTop));
        }
    }
}

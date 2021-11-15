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
        static public List<User> Users = new List<User>();
        static string QuestionsPath = "quiz.txt";
        static string UsersPath = "users.txt";
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
        static string[] TournamentHeader = {
                "╔---------------------╗",
                "| T O U R N A M E N T |",
                "╚---------------------╝"};
        static string[] LogInHeader = {
                "╔-----------╗",
                "| L O G I N |",
                "╚-----------╝",};
        static string[] HallOfFameHeader = {
                "╔-----------------------╗",
                "| H A L L  O F  F A M E |",
                "╚-----------------------╝"};
        static string[] Rewards = { "500", "1000", "2000", "5000", "10000", "20000", "40000", "75000", "125000", "250000", "500000", "1000000" };
        static int GuaranteedPrize = 0;
        static int Score = -1;
        static string Name = "";
        static void LoadUsers(ref List<User> Users, string path)
        {
            try
            {
                string[] TempUsers = System.IO.File.ReadAllLines(path);
                for(int i = 0; i < TempUsers.Length; i++)
                {
                    if(TempUsers[i].Split(' ').Length == 2)
                    {
                        string name = TempUsers[i].Split(' ')[0];
                        int highScore = int.Parse(TempUsers[i].Split(' ')[1]);
                        Users.Add(new User(name, highScore));
                    }
                }
            }
            catch(InvalidOperationException e)
            {
                throw new Exception("Could not load a file: " + e);
            }
        }
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
            var RandIndex = Rand.Next(0, Questions.Count);
            var PickedQuestion = Questions.ElementAt(RandIndex);
            Questions.RemoveAt(RandIndex);
            return PickedQuestion;
        }
        public static void FirstHelp(bool IsAvailable, Question Question, int CursorTop)
        {
            int left = 8;
            char FakeAnswer = ' ';
            Console.SetCursorPosition(left, CursorTop + 10);
            if (IsAvailable == false)
                Console.WriteLine("Kolo ratunkowe zostalo juz uzyte!                                                            ");
            else
            {
                char CorrectAnswer = Question.CorrectAnswer;

                if (CorrectAnswer == 'a')
                    FakeAnswer = 'b';
                if (CorrectAnswer == 'b')
                    FakeAnswer = 'c';
                if (CorrectAnswer == 'c')
                    FakeAnswer = 'd';
                if (CorrectAnswer == 'd')
                    FakeAnswer = 'a';

                Console.WriteLine("Pozostałe odpowiedzi: " + CorrectAnswer + " " + FakeAnswer + "                                                            ");
            }
        }
        public static void SecondHelp(bool IsAvailable, Question Question, int CursorTop)
        {
            int left = 8;
            Console.SetCursorPosition(left, CursorTop + 10);
            if (IsAvailable == false)
                Console.WriteLine("Kolo ratunkowe zostalo juz uzyte!                                                    ");
            else
            {
                float a = 0, b = 0, c = 0, d = 0;
                Random Rand = new Random();
                for(int i = 0; i < 110; i++)
                {
                    int temp = Rand.Next(0, 4);
                    if (temp == 0)
                        a++;
                    if (temp == 1)
                        b++;
                    if (temp == 2)
                        c++;
                    if (temp == 3)
                        d++;
                }
                if (Question.CorrectAnswer == 'a')
                    a += 10;
                if (Question.CorrectAnswer == 'b')
                    b += 10;
                if (Question.CorrectAnswer == 'c')
                    c += 10;
                if (Question.CorrectAnswer == 'd')
                    d += 10;

                Console.Write("A: {0:0}% B: {1:0}% C: {2:0}% D: {3:0}%                                                      ", a / 120 * 100, b / 120 * 100, c / 120 * 100, d / 120 * 100);
            }
        }
        public static void ThirdHelp(bool IsAvailable, Question Question, int CursorTop)
        {
            int left = 8;
            Console.SetCursorPosition(left, CursorTop + 10);
            if (IsAvailable == false)
                Console.WriteLine("Kolo ratunkowe zostalo juz uzyte!                                                ");
            else
            {
                float a = 0, b = 0, c = 0, d = 0;
                Random Rand = new Random();
                String Name = "";
                int Person = Rand.Next(0, 3);

                if (Person == 0)
                    Name = "Agnieszka";
                if (Person == 1)
                    Name = "Marek";
                if (Person == 2)
                    Name = "Zdzicho";

                for (int i = 0; i < 100; i++)
                {
                    int temp = Rand.Next(0, 4);
                    if (temp == 0)
                        a++;
                    if (temp == 1)
                        b++;
                    if (temp == 2)
                        c++;
                    if (temp == 3)
                        d++;
                }
                if (Question.CorrectAnswer == 'a')
                    a += 20;
                if (Question.CorrectAnswer == 'b')
                    b += 20;
                if (Question.CorrectAnswer == 'c')
                    c += 20;
                if (Question.CorrectAnswer == 'd')
                    d += 20;

                float TheBiggest = Math.Max(a, Math.Max(b, Math.Max(c, d)));

                if (TheBiggest == a)
                {
                    Console.WriteLine("{0}: Wydaje mi się, że poprawną odpowiedzią będzie a                          ", Name);
                }
                if (TheBiggest == b)
                {
                    Console.WriteLine("{0}: Wybierz b, masz moje slowo!                                   ", Name);
                }
                if (TheBiggest == c)
                {
                    Console.WriteLine("{0}: Nie mam pewności, ale obstawiam c                             ", Name);
                }
                if (TheBiggest == d)
                {
                    Console.WriteLine("{0}: Coś mi mówi, że to będzie d                                     ", Name);
                }
            }
        }
        public static void SaveProgress(int Score)
        {
            bool meet = false;
            foreach (var x in Users)
            {
                if (x.Name == Name)
                {
                    System.Diagnostics.Debug.WriteLine(x.HighScore);
                    meet = true;
                    if (x.HighScore < Score)
                    {
                        x.HighScore = Score;
                    }
                    System.Diagnostics.Debug.WriteLine(x.HighScore);
                }
            }
            if (meet == false)
            {
                Users.Add(new User(Name, Score));
                System.Diagnostics.Debug.WriteLine("xD");
            }

            string UsersString = "";
            foreach (var x in Users)
            {
                UsersString += x.Name + " " + x.HighScore + "\n";
            }

            System.IO.File.WriteAllText(UsersPath, UsersString);
        }
        static void Game()
        {
            Console.Clear();
            View.TournamentHeader(TournamentHeader);
            bool result = true;
            char GuessedAnswer;
            Question CurrentQuestion;

            bool FirstHelp = true;
            bool SecondHelp = true;
            bool ThirdHelp = true;

            while (true)
            {
                View.PrintScoreboard(Score, ref GuaranteedPrize);
                CurrentQuestion = PickRandomQuestion(ref Questions);
                View.PrintQuestion(CurrentQuestion.Content);
                GuessedAnswer = View.TournamentOptions(CurrentQuestion, Console.CursorTop, ref FirstHelp, ref SecondHelp, ref ThirdHelp);
                result = GuessedAnswer == CurrentQuestion.CorrectAnswer ? true : false;
                if (result == false || GuessedAnswer == 's')
                    break;
                Score++;
                if (Score == 11)
                    break;
                System.Diagnostics.Debug.WriteLine(Score);
            }
            if (GuessedAnswer == 's')
            {
                if (Score == 0)
                    View.Win("0");
                View.Win(Rewards[Score]);
            }
            /*if (result == false)
                View.Lose(CurrentQuestion, GuessedAnswer, GuaranteedPrize);*/
            if (Score == 11)
            {
                View.PrintScoreboard(Score, ref GuaranteedPrize);
                View.Win(Rewards[Score]);
            }
        }
        static void Instructions()
        {
            Console.Clear();
            View.InstructionsHeader(InstructionsHeader);
            View.WriteInstructions();
            SelectMode(View.Options(Console.CursorTop, ref Name));
        }
        static void LogIn()
        {
            Console.Clear();
            View.LogInHeader(LogInHeader);
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("Podaj swoją nazwę: ");
            Name = Console.ReadLine();
            Console.SetCursorPosition(3, 5);
            Console.WriteLine("Witaj, {0}!", Name);
            Console.ReadKey();
            
            Console.Clear();
            Console.SetWindowSize(110, 25);
            Console.CursorVisible = false;
            View.MainMenuHeader(MilionerzyHeader);
            SelectMode(View.Options(Console.CursorTop, ref Name));
        }
        static void HallOfFame()
        {
            Console.Clear();
            View.InstructionsHeader(HallOfFameHeader);

            Users.Sort((x, y) =>
            {
                int tempx = x.HighScore;
                int tempy = y.HighScore;

                if (tempx > tempy)
                    return -1;
                if (tempx < tempy)
                    return 1;
                return 0;

            });
            for(int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(34, 4 + i);
                Console.WriteLine("{0}. {1}\tWynik: {2}", i + 1, Users[i].Name, Users[i].HighScore);
            }
            SelectMode(View.Options(Console.CursorTop, ref Name));
        }
        static void SelectMode(int Option)
        {
            switch (Option)
            {
                case 0: // start
                    Game();
                    break;

                case 1: // instructions
                    LogIn();
                    break;
                case 2:
                    HallOfFame();
                    break;
                case 3:
                    Instructions();
                    break;
                case 4: // quit
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            LoadQuestions(ref Questions, QuestionsPath);
            LoadUsers(ref Users, UsersPath);

            Console.SetWindowSize(110, 25);
            Console.CursorVisible = false;
            View.MainMenuHeader(MilionerzyHeader);
            SelectMode(View.Options(Console.CursorTop, ref Name));
        }
    }
}

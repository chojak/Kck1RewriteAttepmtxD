using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kck1
{
    class Question
    {
        public string Content { get; }
        public string OptionA { get; }
        public string OptionB { get; }
        public string OptionC { get; }
        public string OptionD { get; }
        public char CorrectAnswer { get; }
        public int QuestionIndex { get; }
        public Question(int QuestionIndex, string[] Questions)
        {
            Content = Questions[QuestionIndex];

            OptionA = Questions[QuestionIndex + 1];
            OptionB = Questions[QuestionIndex + 2];
            OptionC = Questions[QuestionIndex + 3];
            OptionD = Questions[QuestionIndex + 4];

            this.QuestionIndex = QuestionIndex / 7;
            CorrectAnswer = Questions[QuestionIndex + 5][0];
        }
        public override string ToString()
        {
            return Content + " " + OptionA + ' ' + OptionB + ' ' + OptionC + ' ' + OptionD + ' ' + CorrectAnswer + ' ' + QuestionIndex;
        }
        static Question PickRandomQuestion(ref List<Question> Questions)
        {
            var Rand = new Random();
            var RandIndex = Rand.Next(0, Questions.Count / 7) * 7;

            var PickedQuestion = Questions.ElementAt(RandIndex);
            Questions.RemoveAt(RandIndex);
            return PickedQuestion;
        }
    }
}

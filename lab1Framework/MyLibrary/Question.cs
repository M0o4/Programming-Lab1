using System;

namespace MyLibrary
{
    public class Question
    {
          #region Public Variables

        public string Text
        {
            get => _text;
            set => _text = string.IsNullOrEmpty(value) ? "No text" : value;
        }

        public string Answer
        {
            get => _answer;
            set => _answer = string.IsNullOrEmpty(value) ? "No answer" : value;
        }
        
        #endregion

        #region Private Variables
        
        private string _text;
        private string _answer;

        #endregion


        #region Methods

        protected void AddScore(ref int score) => score++;
        
        public Question(string text, string answer)
        {
            Text = text;
            Answer = answer;
        }

        public virtual void AskQuestion(ref int score, bool answeResult)
        {
            var currConsoleColor = Console.ForegroundColor;
            
            Console.WriteLine($"Вопрос: {Text}");
            
            Console.Write("Введите ответ: ");
            var answer = Console.ReadLine();

            WriteResult(answer != null && String.Equals(Answer, answer, StringComparison.CurrentCultureIgnoreCase),
                ref score);

            // if (answer != null && String.Equals(Answer, answer, StringComparison.CurrentCultureIgnoreCase))
            // {
            //     AddScore(ref score);
            //     Console.ForegroundColor = ConsoleColor.Green;
            //     Console.WriteLine("Правильно!");
            //     Console.ForegroundColor = currConsoleColor;
            // }
            // else
            // {
            //     Console.ForegroundColor = ConsoleColor.Red;
            //     Console.WriteLine("Не правильно!");
            //     Console.ForegroundColor = currConsoleColor;
            // }

        }

        protected void WriteResult(bool answer, ref int score)
        {
            var currConsoleColor = Console.ForegroundColor;
            
            if (answer)
            {
                AddScore(ref score);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Правильно!");
                Console.ForegroundColor = currConsoleColor;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Не правильно!");
                Console.ForegroundColor = currConsoleColor;
            }
        }
        
        protected Question() {}

        #endregion
    }
}
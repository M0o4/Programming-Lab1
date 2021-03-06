using System;

namespace TestLibrary
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

        public Question(string text, string answer)
        {
            Text = text;
            Answer = answer;
        }

        public virtual void AskQuestion()
        {
            Console.WriteLine($"Вопрос: {Text}");
            
            Console.Write("Введите ответ: ");
            var answer = Console.ReadLine();
            
            if(answer != null && Answer.ToLower() == answer.ToLower())
                Console.WriteLine("Правильно!");
            else
                Console.WriteLine("Не правильно!"); 
        }
        
        protected Question() {}

        #endregion
    }
}
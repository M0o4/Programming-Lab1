using System;

namespace TestLibrary
{
    class Question
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

        protected int _score;
        private string _text;
        private string _answer;

        #endregion


        #region Methods

        private void AddScore() => _score++;
        
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

            if (answer != null && String.Equals(Answer, answer, StringComparison.CurrentCultureIgnoreCase))
            {
                AddScore();
                Console.WriteLine("Правильно!");
            }else
                Console.WriteLine("Не правильно!"); 
        }
        
        protected Question() {}

        #endregion
    }
    
    
}
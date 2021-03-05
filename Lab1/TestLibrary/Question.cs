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


        public Question(string text, string answer)
        {
            Text = text;
            Answer = answer;
        }

        protected Question() {}
    }
}
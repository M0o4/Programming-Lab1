using System.Collections.Generic;

namespace MyLibrary
{
    public class Test
    {
        #region Public Variables

        public int Score => _score;

        public List<Question> QuestionsList => questionsList;

        public string StudentName
        {
            get => _studentName;
            set => _studentName = string.IsNullOrEmpty(value) ? "No student name" : value;
        }

        #endregion


        #region Private Variables
        
        private string _studentName;
        internal readonly List<Question> questionsList;
        private int _score;

        #endregion

        #region Methods

        public Test() => questionsList = new List<Question>(10);
        

        public void AddTestQuestion(TestQuestion testQuestion)
        {
            questionsList.Add(testQuestion);
        }

        public void GetResult(bool answerResult)
        {
            if (answerResult)
                _score++;
        }

        #endregion
    }
}
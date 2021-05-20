namespace MyLibrary
{
    public class Exam : Test
    {
        #region Public Variables
         public string SubjectName
        {
            get => _subjectName;
            set => _subjectName = string.IsNullOrEmpty(value) ? "No subject name" : value;
        }

        public string SchoolName
        {
            get => _schoolName;
            set => _schoolName = string.IsNullOrEmpty(value) ? "No school name" : value;
        }
        
        public bool IsPassed
        {
            set => _isPassed = value;
        }
        #endregion

        #region Private Variables
        
        private string _subjectName;
        private string _schoolName;
        private bool _isPassed;

        #endregion
        
        #region Methods

        public void AddWriteQuestion(Question question)
        {
            questionsList.Add(question);
        }
        
        #endregion
    }
}
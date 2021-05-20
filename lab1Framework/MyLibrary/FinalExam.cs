using System;
using System.Collections.Generic;

namespace MyLibrary
{
    public class FinalExam : Exam
    {
        public List<string> ListOfExaminers { get; }

        public int TimeLimit { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        #region Private Variables

        #endregion
        
        #region Methods
        public FinalExam() =>ListOfExaminers = new List<string>(2);
        
        public void AddExaminers(string examiner) => ListOfExaminers.Add(examiner);

        #endregion
    }
}
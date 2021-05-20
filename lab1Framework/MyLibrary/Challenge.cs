
namespace MyLibrary
{
    public class Challenge : Test
    {
         #region Public Variables

        public string NameOfEducationalInstitution
        {
            get => _nameOfEducationalInstitution;
            set => _nameOfEducationalInstitution = string.IsNullOrEmpty(value) ? "No name" : value;
        }
        
        public int PassingScore { set; get; }

        public string StudentIdCard { set; get; }

        #endregion
        
        #region Private Variables

        private string _nameOfEducationalInstitution;

        #endregion
        
    }
}
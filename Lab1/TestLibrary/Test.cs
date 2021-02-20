namespace TestLibrary
{
    public class Test
    {
        #region Public Variables
        
        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrEmpty(value) ? "No name" : value;
        }
        
        #endregion

        #region Private Variables
        
        private string _name;
        private Question[] _questions;
        
        #endregion
    }
}
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
        
        protected string _name;
        protected Question[] _questions;
        
        #endregion
    }
}
using System;
using System.IO;
using System.Xml.Serialization;

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

        #region Methods

        public virtual void AskQuestion()
        {
            Console.WriteLine("Чики Брики");   
        }
        
        public virtual void Save (string fileName)
        {
            string path = $@".\Tests\{fileName}.txt";
            FileStream outFile = File.Create(path);
            XmlSerializer formatter = new XmlSerializer(this.GetType());
            formatter.Serialize(outFile, this);
        }

        #endregion
    }
}
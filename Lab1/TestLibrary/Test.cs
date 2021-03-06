using System;
using System.Collections.Generic;
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

        public string StudentName
        {
            get => _studentName;
            set => _studentName = string.IsNullOrEmpty(value) ? "No student name" : value;
        }

        #endregion
        

        #region Private Variables
        
        protected string _name;
        protected string _studentName;
        protected readonly List<Question> _questions;
        
        #endregion

        #region Methods

        public Test()
        {
            _questions = new List<Question>();
        }

        public void EnterName()
        {
            Console.WriteLine("Введите ФИО");
            Console.Write("Ввод: ");
            StudentName = Console.ReadLine();
        }

        public virtual void AddQuestion()
        {
            string exit;
            
            do
            {
                Console.Write("Введите вопрос: ");
                var text = Console.ReadLine();
                
                _questions.Add(new TestQuestion(text));
                
                Console.WriteLine("Добавить еще тестовый вопрос? \nY)да N)нет");
                
                Console.Write("Ввод: ");

                exit = Console.ReadLine();

            } while (exit != null && exit.ToLower() == "y");
            
        }
        
        public virtual void AskQuestion()
        {
            foreach (var question in _questions)
            {
                question.AskQuestion();
            }
        }
        
        
        // public virtual void Save (string fileName)
        // {
        //     string path = $@".\Tests\{fileName}.txt";
        //     FileStream outFile = File.Create(path);
        //     XmlSerializer formatter = new XmlSerializer(this.GetType());
        //     formatter.Serialize(outFile, this);
        // }

        #endregion
    }
}
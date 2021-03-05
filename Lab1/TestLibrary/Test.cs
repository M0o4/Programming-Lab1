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
        protected List<Question> _questions;
        
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
                
                Console.WriteLine("Добавить еще вопрос? \nY)да N)нет");
                
                Console.Write("Ввод: ");

                exit = Console.ReadLine();

            } while (exit != null && exit.ToLower() == "y");
            
        }
        
        public virtual void AskQuestion()
        {
            foreach (var question in _questions)
            {
                var item = (TestQuestion) question;
                
                int id;
                
                Console.WriteLine(item.Text);
                
                item.ShowAnswers();
                
                do
                {
                    Console.Write("Введите ответ: ");

                    var answer = Console.ReadLine();
                    
                    if (!int.TryParse(answer, out id))
                        Console.WriteLine("Ошибка ввода, попробуйте снова.");
                    
                } while (id < 1);
                

                Console.WriteLine(string.Equals(item.Answer.ToLower(), item.GetAnswerInList(id-1).ToLower(), StringComparison.CurrentCultureIgnoreCase) ? "Правильно!" : "Неравиольно!!");
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
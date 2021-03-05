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
        protected List<TestQuestion> _questions;
        
        #endregion

        #region Methods

        public Test()
        {
            _questions = new List<TestQuestion>();
        }

        public void EnterName()
        {
            Console.WriteLine("Введите ФИО");
            Console.Write("Ввод: ");
            StudentName = Console.ReadLine();
        }

        public virtual void AddQuestion()
        {
            int a = 0;
            
            do
            {
                Console.Write("Введите вопрос: ");
                var text = Console.ReadLine();
                
                _questions.Add(new TestQuestion(text));
                
                Console.WriteLine("Добавить еще вопрос? \n0)да 1)нет");
                
                Console.Write("Ввод: ");

                a = Convert.ToInt32(Console.ReadLine());

            } while (a == 0);
            
        }
        
        public virtual void AskQuestion()
        {
            foreach (var item in _questions)
            {
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
                

                Console.WriteLine(item.Answer.ToLower() == item.GetAnswerInList(id-1).ToLower() ? "Правильно!" : "Неравиольно!!");
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
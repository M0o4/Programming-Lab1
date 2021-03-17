using System;
using System.Collections.Generic;

namespace MyLibrary
{
    public class Test
    {
        #region Public Variables

        public int Score => _score;

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
        internal readonly List<Question> _questions;
        protected int _score;

        #endregion

        #region Methods

        public Test() => _questions = new List<Question>(10);

        protected void EnterName()
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
            Console.Clear();

            EnterName();

            Console.WriteLine();

            foreach (var question in _questions)
            {
                question.AskQuestion(ref _score);
            }

            Console.WriteLine($"Тест окончен, баллы за тест: {_score}");
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
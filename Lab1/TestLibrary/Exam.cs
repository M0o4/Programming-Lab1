using System;

namespace TestLibrary
{
    public class Exam : Test
    {
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

        protected string _subjectName;
        protected string _schoolName;

        private void AddSubjectName()
        {
            Console.WriteLine("Введите название предмета.");
            Console.Write("Ввод: ");

            SubjectName = Console.ReadLine();
        }

        public override void AddQuestion()
        {
            AddSubjectName();

            Console.WriteLine("Какие задания вы хотите добавить?");
            Console.WriteLine("1)Тестовые\n2)Письменные");
            
            //switch
            //1)Тестовые =>
            base.AddQuestion();
            //Добавить еще тест?
            //да нет
            //Добавить письменный
            //код
            _questions.Add(new Question("2+2", "4"));
            //Добавить еще тест?
            //да нет
        }

        public override void AskQuestion()
        {
            //проверить какой тест
            foreach (var question in _questions)
            {
                if(question.GetType() == typeof(TestQuestion))
                {
                    base.AskQuestion();
                    continue;
                }

                //спросить письменный тест
            }
            
        }
    }
}
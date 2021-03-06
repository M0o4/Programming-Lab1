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
            string exit;

            AddSubjectName();

            do
            {
                int choice = -1;

                Console.WriteLine("Какие задания вы хотите добавить?");

                do
                {
                    Console.WriteLine("1)Тестовые\n2)Письменные");
                    Console.Write("Ввод: ");
                    var input = Console.ReadLine();

                    if (!int.TryParse(input, out choice))
                        Console.WriteLine("Ошибка: \"Не верный ввод\"");
                } while (choice <= 0 || choice > 2);

                switch (choice)
                {
                    case 1:
                        base.AddQuestion();
                        break;
                    case 2:
                        AddWriteQuestion();
                        break;
                }


                Console.WriteLine("Добавить еще задания? \nY)да N)нет");

                Console.Write("Ввод: ");

                exit = Console.ReadLine();
            } while (exit != null && exit.ToLower() == "y");
        }

        private void AddWriteQuestion()
        {
            string exit;

            do
            {
                Console.WriteLine("Введите вопрос: ");
                Console.Write("Ввод: ");
                var text = Console.ReadLine();

                Console.WriteLine("Введите ответ на вопрос: ");
                Console.Write("Ввод: ");
                var answer = Console.ReadLine();

                _questions.Add(new Question(text, answer));

                Console.WriteLine("Добавить еще вопрос? \nY)да N)нет");

                Console.Write("Ввод: ");

                exit = Console.ReadLine();
            } while (exit != null && exit.ToLower() == "y");
        }

        public override void AskQuestion()
        {
            Console.WriteLine($"Экзамен по {SubjectName}");
            base.AskQuestion();
        }
    }
}
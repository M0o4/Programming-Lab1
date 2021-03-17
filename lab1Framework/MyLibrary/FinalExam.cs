using System;
using System.Collections.Generic;

namespace MyLibrary
{
    public class FinalExam : Exam
    {
         #region Private Variables
        
        private List<string> _listOfExaminers;
        private int _timeLimit;
        private DateTime _start;
        private DateTime _end;

        #endregion
        
        #region Methods

        public FinalExam() =>_listOfExaminers = new List<string>(2);

        private void EnterTimeLimit()
        {
            var currConsoleColor = Console.ForegroundColor;
            
            Console.WriteLine("Введите органичение по времени на тест в минутах.");
            
            do
            {
                Console.Write("Ввод:");
                var input = Console.ReadLine();
                
                if (!int.TryParse(input, out _timeLimit))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода, попробуйте снова.\a");
                    Console.ForegroundColor = currConsoleColor;
                }
                
            } while (_timeLimit <= 0);
        }

        private void EnterExaminers()
        {
            string exit;
            
            Console.WriteLine("Введите экзаменатора.");
            
            do
            {
                Console.Write("Ввод: ");
                _listOfExaminers.Add(Console.ReadLine());
                
                Console.WriteLine("Добавить еще?\nY)да N)нет");

                Console.Write("Ввод: ");

                exit = Console.ReadLine();
            } while (exit != null && exit.ToLower() == "y");
        }

        private void DisplayExaminators()
        {
            foreach (var examinator in _listOfExaminers)
            {
                Console.WriteLine(examinator);
            }
        }
        
        
        public override void AddQuestion()
        {
            EnterExaminers();
            EnterTimeLimit();
            
            base.AddQuestion();
        }

        public override void AskQuestion()
        {
            var currConsoleColor = Console.ForegroundColor;

            EnterName();

            Console.WriteLine();
            
            Console.WriteLine($"Экзамен по {SubjectName}");
            Console.WriteLine();
            Console.WriteLine("Экзаменаторы:");
            DisplayExaminators();

            Console.WriteLine();
            
            _start = DateTime.Now;
            _end = DateTime.Now.AddMinutes(_timeLimit);
            Console.WriteLine($"Тест начался в {_start}\nЗакончиться в {_end}");

            Console.WriteLine();
            
            foreach (var question in _questions)
            {
                question.AskQuestion(ref _score);
                
                if (_end.Subtract(DateTime.Now).TotalMinutes <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Время вышло, тест окончен!");
                    Console.ForegroundColor = currConsoleColor;
                    break;
                }
            }

            Console.WriteLine();
            
            Console.WriteLine($"Тест окончен, баллы за тест: {_score}");
        }
        #endregion
    }
}
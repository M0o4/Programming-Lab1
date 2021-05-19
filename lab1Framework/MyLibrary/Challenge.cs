using System;

namespace MyLibrary
{
    public class Challenge : Test
    {
         #region Public Variables

        public string NameOfEducationalInstitution
        {
            get => _nameOfEducationalInstitution;
            set => _nameOfEducationalInstitution = string.IsNullOrEmpty(value) ? "No name" : value;
        }

        #endregion
        
        #region Private Variables

        private string _nameOfEducationalInstitution;
        private int _passingScore;
        private string _studentIdCard;

        #endregion
        
        #region Methods

        private void EnterNameOfEducationalInstitution()
        {
            Console.WriteLine("Введите название учебного учреждения.");
            Console.Write("Ввод: ");
            NameOfEducationalInstitution = Console.ReadLine();
        }

        private void EnterPassingScore()
        {
            var currConsoleColor = Console.ForegroundColor;
            
            Console.WriteLine("Введите проходной балл.");
            
            do
            {
                Console.Write("Ввод:");
                var input = Console.ReadLine();
                
                if (!int.TryParse(input, out _passingScore))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода, попробуйте снова.\a");
                    Console.ForegroundColor = currConsoleColor;
                }
                
            } while (_passingScore <= 0);
        }

        private void EnterStudentIdCard()
        {
            var currConsoleColor = Console.ForegroundColor;
            
            Console.WriteLine("Введите свою ID карту.");
            do
            {
                Console.Write("Ввод:");

                _studentIdCard = Console.ReadLine();
                
                if (string.IsNullOrEmpty(_studentIdCard))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода, попробуйте снова.\a");
                    Console.ForegroundColor = currConsoleColor;
                }
                
            } while (_passingScore <= 0);
        }

        // public override void AddQuestion()
        // {
        //     EnterNameOfEducationalInstitution();
        //     EnterPassingScore();
        //     EnterStudentIdCard();
        //     base.AddQuestion();
        // }
        //
        // public override void AskQuestion()
        // {
        //     base.AskQuestion();
        //     if(_score < _passingScore)
        //         Console.WriteLine("Экзамен не сдан");
        //     else
        //         Console.WriteLine("Экзамен сдан");
        // }

        #endregion
    }
}
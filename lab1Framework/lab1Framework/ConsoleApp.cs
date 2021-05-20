using System;
using System.Collections.Generic;
using MyLibrary;

namespace lab1Framework
{
    public class ConsoleApp
    {
        
        public void StartApp()
        {
        	var currConsoleColor = Console.ForegroundColor;
        	while (true)
        	{
        		Console.Clear();
        		Console.WriteLine("***** Лабораторная работа  №1 *****");
        		
        		Console.WriteLine();
        
        		Console.WriteLine("1)Тест\n2)Экзамен\n3)Выпускной экзамен\n4)Испытание\n5)Выход");
        
        		int choice;
        		do
        		{
        			Console.WriteLine();
        			Console.Write("Ввод: ");
        			var input = Console.ReadLine();
        
        			if (!int.TryParse(input, out choice))
        			{
        				Console.ForegroundColor = ConsoleColor.Red;
        				Console.WriteLine("Ошибка: \"Неверный ввод\"\a");
        				Console.ForegroundColor = currConsoleColor;
        			}
        		} while (choice <= 0 || choice > 5);
        
        		switch (choice)
        		{
        			case 1:
        				StartClass(new Test());
        				break;
        			case 2:
        				StartClass(new Exam());
        				break;
        			case 3:
        				StartClass(new FinalExam());
        				break;
        			case 4:
        				StartClass(new Challenge());
        				break;
        			case 5:
        				return;
        		}
        	}
        }
        
        private void StartClass(Test test)
        {
            switch (test)
            {
                case Challenge challenge:
                    AddQuestion(challenge);
                    Console.Clear();
                    AskQuestion(challenge);
                    break;
                case FinalExam finalExam:
                    AddQuestion(finalExam);
                    Console.Clear();
                    AskQuestion(finalExam);
                    break;
                case Exam exam:
                    AddQuestion(exam);
                    Console.Clear();
                    AskQuestion(exam);
                    break;
                default:
                    AddQuestion(test);
                    Console.Clear();
                    AskQuestion(test);
                    break;
            }
            
        	Console.WriteLine("\nНажмите Enter чтобы продолжить.");
        	Console.ReadKey();
        }
        
        private  void AskQuestion(FinalExam exam)
        {
            var currConsoleColor = Console.ForegroundColor;
        
            EnterName(exam);
        
            Console.WriteLine();
            
            Console.WriteLine($"Экзамен по {exam.SubjectName}");
            Console.WriteLine();
            Console.WriteLine("Экзаменаторы:");
            DisplayExaminers(exam);
        
            Console.WriteLine();
            
            exam.Start = DateTime.Now;
            exam.End = DateTime.Now.AddMinutes(exam.TimeLimit);
            Console.WriteLine($"Тест начался в {exam.Start}\nЗакончиться в {exam.End}");
        
            Console.WriteLine();
            
            foreach (var question in exam.QuestionsList)
            {
                bool result;
                switch (question)
                {
                    case TestQuestion testQuestion:
                        AskTestQuestion(testQuestion, out result);
                        exam.GetResult(result);
                        break;
                    default:
                        AskWriteQuestion(question, out result);
                        exam.GetResult(result);
                        break;
                }
                
                if (exam.End.Subtract(DateTime.Now).TotalMinutes <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Время вышло, тест окончен!");
                    Console.ForegroundColor = currConsoleColor;
                    break;
                }
            }
        
            Console.WriteLine();
            
            Console.WriteLine($"Тест окончен, баллы за тест: {exam.Score}");
        }
        
        private void AskQuestion(Exam exam)
        {
            Console.WriteLine(exam.SchoolName);
            Console.WriteLine($"Экзамен по {exam.SubjectName}");
            AskQuestion((Test) exam);
        
            exam.IsPassed = exam.Score > 0;
        }

        private void AskQuestion(Challenge challenge)
        {
            AskQuestion((Test)challenge);
            if(challenge.Score < challenge.PassingScore)
                Console.WriteLine("Экзамен не сдан");
            else
                Console.WriteLine("Экзамен сдан");
        }
        
        private void AskQuestion(Test test)
        {
            EnterName(test);

            Console.WriteLine();

            foreach (var question in test.QuestionsList)
            {
                bool result;
                switch (question)
                {
                    case TestQuestion testQuestion:
                        AskTestQuestion(testQuestion, out result);
                        test.GetResult(result);
                        break;
                    default:
                        AskWriteQuestion(question, out result);
                        test.GetResult(result);
                        break;
                }
            }
            
            Console.WriteLine($"Тест окончен, баллы за тест: {test.Score}");
        }

        private void AddQuestion(Challenge challenge)
        {
            EnterNameOfEducationalInstitution(challenge);
            EnterPassingScore(challenge);
            EnterStudentIdCard(challenge);
            AddQuestion((Test)challenge);
        }
        
        private void EnterNameOfEducationalInstitution(Challenge challenge)
        {
            Console.WriteLine("Введите название учебного учреждения.");
            Console.Write("Ввод: ");
            challenge.NameOfEducationalInstitution = Console.ReadLine();
        }
        
        private void EnterPassingScore(Challenge challenge)
        {
            var currConsoleColor = Console.ForegroundColor;
            int passingScore;
            
            Console.WriteLine("Введите проходной балл.");
            
            do
            {
                Console.Write("Ввод:");
                var input = Console.ReadLine();
                
                if (!int.TryParse(input, out passingScore))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода, попробуйте снова.\a");
                    Console.ForegroundColor = currConsoleColor;
                }
                
            } while (passingScore <= 0);

            challenge.PassingScore = passingScore;
        }
        
        private void EnterStudentIdCard(Challenge challenge)
        {
            var currConsoleColor = Console.ForegroundColor;
            
            Console.WriteLine("Введите свою ID карту.");
   
                Console.Write("Ввод:");
        
                challenge.StudentIdCard = Console.ReadLine();
                
                if (string.IsNullOrEmpty(challenge.StudentIdCard))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода, попробуйте снова.\a");
                    Console.ForegroundColor = currConsoleColor;
                }
        }
        
        private void AddQuestion(FinalExam exam)
        {
            EnterExaminers(exam);
            EnterTimeLimit(exam);
            AddQuestion((Exam)exam);
        }
        
        private void DisplayExaminers(FinalExam exam)
        {
            foreach (var examiner in exam.ListOfExaminers)
            {
                Console.WriteLine(examiner);
            }
        }
        
        private void EnterTimeLimit(FinalExam exam)
        {
            int timeLimit;
            var currConsoleColor = Console.ForegroundColor;
            
            Console.WriteLine("Введите органичение по времени на тест в минутах.");
            
            do
            {
               
                Console.Write("Ввод:");
                var input = Console.ReadLine();
                
                if (!int.TryParse(input, out  timeLimit))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода, попробуйте снова.\a");
                    Console.ForegroundColor = currConsoleColor;
                }
                
            } while (timeLimit <= 0);

            exam.TimeLimit = timeLimit;
        }

        private void EnterExaminers(FinalExam finalExam)
        {
            string exit;
            
            Console.WriteLine("Введите экзаменатора.");
            
            do
            {
                Console.Write("Ввод: ");
                finalExam.AddExaminers(Console.ReadLine());
                
                Console.WriteLine("Добавить еще?\nY)да N)нет");

                Console.Write("Ввод: ");

                exit = Console.ReadLine();
            } while (exit != null && exit.ToLower() == "y");
        }

        
        private void AddQuestion(Exam exam)
        {
            var currConsoleColor = Console.ForegroundColor;
            string exit;
        
            AddSchoolName(exam);
            AddSubjectName(exam);
        
            do
            {
                int choice;
        
                Console.WriteLine("Какие задания вы хотите добавить?");
        
                do
                {
                    Console.WriteLine("1)Тестовые\n2)Письменные");
                    Console.Write("Ввод: ");
                    var input = Console.ReadLine();
        
                    if (!int.TryParse(input, out choice))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка: \"Неверный ввод\"\a");
                        Console.ForegroundColor = currConsoleColor;
                    }
                } while (choice <= 0 || choice > 2);
        
                switch (choice)
                {
                    case 1:
                        AddQuestion((Test)exam);
                        break;
                    case 2:
                        AddWriteQuestion(exam);
                        break;
                }
                
                Console.WriteLine("Добавить еще задания? \nY)да N)нет");
        
                Console.Write("Ввод: ");
        
                exit = Console.ReadLine();
            } while (exit != null && exit.ToLower() == "y");
        }
        
        private void AddSchoolName(Exam exam)
        {
            Console.WriteLine("Введите название школы.");
            Console.Write("Ввод: ");
        
            exam.SchoolName = Console.ReadLine();
        
            Console.WriteLine();
        }

        private void AddSubjectName(Exam exam)
        {
            Console.WriteLine("Введите название предмета.");
            Console.Write("Ввод: ");
        
            exam.SubjectName = Console.ReadLine();
        
            Console.WriteLine();
        }
        
        private void AddQuestion(Test test)
        {
            string exit;
            do
            {
                test.AddTestQuestion(CreateTestQuestion());

                Console.WriteLine("Добавить еще тестовый вопрос? \nY)да N)нет");

                Console.Write("Ввод: ");

                exit = Console.ReadLine();
            } while (exit != null && exit.ToLower() == "y");
        }

        private void AddWriteQuestion(Exam exam)
        {
            string exit;
            do
            {
                exam.AddWriteQuestion(CreateWriteQuestion());

                Console.WriteLine("Добавить еще вопрос? \nY)да N)нет");

                Console.Write("Ввод: ");

                exit = Console.ReadLine();
            } while (exit != null && exit.ToLower() == "y");
        }
        
        private Question CreateWriteQuestion()
        {
            Console.WriteLine("Введите вопрос: ");
            Console.Write("Ввод: ");
            var text = Console.ReadLine();
            
            Console.WriteLine("Введите ответ на вопрос: ");
            Console.Write("Ввод: ");
            var answer = Console.ReadLine();
            return new Question(text, answer);
        }
        
        private  void AskWriteQuestion(Question question, out bool result)
        {
            Console.WriteLine($"Вопрос: {question.Text}");
            
            Console.Write("Введите ответ: ");
            var answer = Console.ReadLine();

            WriteResult(answer != null && String.Equals(question.Answer, answer, StringComparison.CurrentCultureIgnoreCase),
                out result);
        }
        
        private  void AskTestQuestion(TestQuestion test, out bool result)
        {
            var currConsoleColor = Console.ForegroundColor;
            int id;

            Console.WriteLine($"Вопрос: {test.Text}");

            ShowAnswers(test);

            do
            {
                Console.Write("Введите ответ: ");

                var answer = Console.ReadLine();

                if (!int.TryParse(answer, out id))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода, попробуйте снова.\a");
                    Console.ForegroundColor = currConsoleColor;
                }
            } while (id < 1);
            
            
            WriteResult(string.Equals(test.Answer, test.GetAnswerInList(id - 1), StringComparison.CurrentCultureIgnoreCase), 
                out result);
        }
        

        private void WriteResult(bool answer, out bool result)
        {
            var currConsoleColor = Console.ForegroundColor;
            
            if (answer)
            {
                result = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Правильно!");
                Console.ForegroundColor = currConsoleColor;
            }
            else
            {
                result = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Не правильно!");
                Console.ForegroundColor = currConsoleColor;
            }
        }
        
        private void ShowAnswers(TestQuestion test)
        {
            for (int i = 0; i < test.Answers.Count; i++)
            {
                Console.WriteLine(i + 1 + ")" + test.Answers[i]);
            }
        }
        
        private TestQuestion CreateTestQuestion()
        {
            string exit;
            List<string> answers = new List<string>();
            
            Console.Write("Введите вопрос: ");
            var text = Console.ReadLine();
            
            Console.WriteLine("Введите ответ на вопрос: ");
            Console.Write("Ввод: ");
            var answer = Console.ReadLine();
            
            do
            {
                Console.WriteLine("Введите неправльные ответы: ");
                Console.Write("Ввод: ");

                var str = Console.ReadLine();
                answers.Add(str);

                Console.WriteLine("Хотите добавить еще ответов?\nY)Да\nN)Нет");
                Console.Write("Ввод: ");
                exit = Console.ReadLine();
            } while (exit != null && exit.ToLower() == "y");
            
            return new TestQuestion(text, answer, answers);
        }
        
        private void EnterName(Test test)
        {
            Console.WriteLine("Введите ФИО");
            Console.Write("Ввод: ");
            test.StudentName = Console.ReadLine();
        }
    }
}
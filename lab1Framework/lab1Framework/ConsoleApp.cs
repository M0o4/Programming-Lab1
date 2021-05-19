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
        	AddQuestion(test);
        	AskQuestion(test);
        	Console.WriteLine("\nНажмите Enter чтобы продолжить.");
        	Console.ReadKey();
        }
        
        private void AskQuestion(Test test)
        {
            Console.Clear();

            EnterName(test);

            Console.WriteLine();

            foreach (var question in test.Questions)
            {
                AskTestQuestion(question, out var result);
                test.GetResult(result);
            }
            
            
            Console.WriteLine($"Тест окончен, баллы за тест: {test.Score}");
        }
        
        private void AddQuestion(Test test)
        {
            string exit;
            do
            {
                test.AddQuestion(CreateTestQuestion());

                Console.WriteLine("Добавить еще тестовый вопрос? \nY)да N)нет");

                Console.Write("Ввод: ");

                exit = Console.ReadLine();
            } while (exit != null && exit.ToLower() == "y");
        }

        private  void AskTestQuestion(Question test, out bool result)
        {
            var currConsoleColor = Console.ForegroundColor;
            int id;
            TestQuestion temp = (TestQuestion) test;

            
            Console.WriteLine($"Вопрос: {temp.Text}");

            ShowAnswers(temp);

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
            
            
            WriteResult(string.Equals(test.Answer, temp.GetAnswerInList(id - 1), StringComparison.CurrentCultureIgnoreCase), out result, test);
        }
        
        private void WriteResult(bool answer, out bool result, Question question)
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
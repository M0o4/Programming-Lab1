using System;
using MyLibrary;

namespace lab1Framework
{
	class Program
	{
		static void Main(string[] args)
		{
			//Menu();

			ConsoleApp consoleApp = new ConsoleApp();
			consoleApp.StartApp();
			
			Console.ReadLine();
		}

		// static void Menu()
		// {
		// 	var currConsoleColor = Console.ForegroundColor;
		// 	while (true)
		// 	{
		// 		Console.Clear();
		// 		Console.WriteLine("***** Лабораторная работа  №1 *****");
		// 		
		// 		Console.WriteLine();
		//
		// 		Console.WriteLine("1)Тест\n2)Экзамен\n3)Выпускной экзамен\n4)Испытание\n5)Выход");
		//
		// 		int choice;
		// 		do
		// 		{
		// 			Console.WriteLine();
		// 			Console.Write("Ввод: ");
		// 			var input = Console.ReadLine();
		//
		// 			if (!int.TryParse(input, out choice))
		// 			{
		// 				Console.ForegroundColor = ConsoleColor.Red;
		// 				Console.WriteLine("Ошибка: \"Неверный ввод\"\a");
		// 				Console.ForegroundColor = currConsoleColor;
		// 			}
		// 		} while (choice <= 0 || choice > 5);
		//
		// 		switch (choice)
		// 		{
		// 			case 1:
		// 				StartClass(new Test());
		// 				break;
		// 			case 2:
		// 				StartClass(new Exam());
		// 				break;
		// 			case 3:
		// 				StartClass(new FinalExam());
		// 				break;
		// 			case 4:
		// 				StartClass(new Challenge());
		// 				break;
		// 			case 5:
		// 				return;
		// 		}
		// 	}
		// }
		//
		// static void StartClass(Test test)
		// {
		// 	test.AddQuestion();
		// 	test.AskQuestion();
		// 	Console.WriteLine("\nНажмите Enter чтобы продолжить.");
		// 	Console.ReadKey();
		// }
	}
}

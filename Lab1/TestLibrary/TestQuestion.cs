﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace TestLibrary
{
     class TestQuestion : Question
    {
        #region Private Variables

        private readonly List<string> _answers;

        private readonly Random _rng = new Random();

        #endregion

        #region Methods

        public TestQuestion(string text)
        {
            Text = text;

            _answers = new List<string>();

            AddAnswers();
        }

        private void AddAnswers()
        {
            string exit;

            Console.WriteLine("Введите ответ на вопрос: ");
            Console.Write("Ввод: ");
            var answer = Console.ReadLine();
            Answer = answer;
            _answers.Add(answer);

            do
            {
                Console.WriteLine("Введите неправльные ответы: ");
                Console.Write("Ввод: ");

                answer = Console.ReadLine();
                _answers.Add(answer);

                Console.WriteLine("Хотите добавить еще ответов?\nY)Да\nN)Нет");
                Console.Write("Ввод: ");
                exit = Console.ReadLine();
            } while (exit != null && exit.ToLower() == "y");

            Shuffle(_answers);
        }

        private void Shuffle(IList<string> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public void ShowAnswers()
        {
            for (int i = 0; i < _answers.Count; i++)
            {
                Console.WriteLine(i + 1 + ")" + _answers[i]);
            }
        }

        public string GetAnswerInList(int id)
        {
            if (id > _answers.Count || id < 0) return null;

            return _answers[id];
        }

        public override void AskQuestion(ref int score)
        {
            var currConsoleColor = Console.ForegroundColor;
            int id;

            Console.WriteLine($"Вопрос: {Text}");

            ShowAnswers();

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

            WriteResult(string.Equals(Answer, GetAnswerInList(id - 1), StringComparison.CurrentCultureIgnoreCase), ref score);
            
            // if (string.Equals(Answer, GetAnswerInList(id - 1), StringComparison.CurrentCultureIgnoreCase))
            // {
            //     AddScore(ref score);
            //     Console.ForegroundColor = ConsoleColor.Green;
            //     Console.WriteLine("Правильно!");
            //     Console.ForegroundColor = currConsoleColor;
            // }
            // else
            // {
            //     Console.ForegroundColor = ConsoleColor.Red;
            //     Console.WriteLine("Не правильно!");
            //     Console.ForegroundColor = currConsoleColor;
            // }
        }

        #endregion
    }
}
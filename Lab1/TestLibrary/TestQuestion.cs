﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace TestLibrary
{
    public class TestQuestion : Question
    {

        #region Private Variables

        private List<string> _answers;
        
        private Random rng = new Random();  

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
            
            do
            {
                _answers.Add(answer);
                
                Console.WriteLine("Введите неправльные ответы: ");
                Console.Write("Ввод: ");

                answer = Console.ReadLine();
                
                Console.WriteLine("Хотите добавить еще ответов?\nY)Да\nN)Нет");
                Console.Write("Ввод: ");
                exit = Console.ReadLine();
            } while (exit != null && exit.ToLower() == "y");

            Shuffle(_answers);
        }
        
        private void Shuffle( IList<string> list)  
        {  
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
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
            if(id > _answers.Count || id < 0) return null;

            return _answers[id];
        }
        
        #endregion
    }
}
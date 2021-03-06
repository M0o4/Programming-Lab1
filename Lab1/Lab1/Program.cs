using System;
using TestLibrary;

namespace Lab1
{
	class Program
	{
		static void Main(string[] args)
		{
			SaveClass saveClass = new SaveClass();
			
			Test test = new Test();
			FinalExam exam = new FinalExam();
		
			Exam m_exam = new Exam();
			
			m_exam.AddQuestion();
			
			Console.Clear();
			
			Ask(m_exam);
		}
		
		static void Ask(Test test)
		{
			test.AskQuestion();
		}
	}
	
	
}



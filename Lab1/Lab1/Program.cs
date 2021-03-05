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
			
			test.AddQuestion();
			Ask(test);
		}
		
		static void Ask(Test test)
		{
			test.AskQuestion();
		}
	}
	
	
}



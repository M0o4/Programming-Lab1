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

			test.Name = "Test name";
			//
			//exam.Name = "Test exam name";
			//
			// saveClass.Save(exam, "exam2");

			//saveClass.Load(exam, "exam2");
			
			test.Save("suka1");
			
			Ask(test);
			Ask(exam);
		}

		static void Ask(Test test)
		{
			test.AskQuestion();
		}
	}
}

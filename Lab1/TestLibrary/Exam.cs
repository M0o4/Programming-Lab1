using System;

namespace TestLibrary
{
    public class Exam : Test
    {
        public override void AskQuestion()
        {
            base.AskQuestion();
            Console.Write("Ку");
        }
    }
}
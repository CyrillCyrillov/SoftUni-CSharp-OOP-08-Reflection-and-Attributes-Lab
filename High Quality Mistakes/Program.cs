using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            Spy spy = new Spy();

           
            string resultMistakes = spy.AnalyzeAccessModifiers(typeof(Hacker).FullName);
            Console.WriteLine(resultMistakes);


            //Console.WriteLine("Hello World!");
        }
    }
}

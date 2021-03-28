using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();


            string resultGettersAndSetters = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(resultGettersAndSetters);


            //Console.WriteLine("Hello World!");
        }
    }
}
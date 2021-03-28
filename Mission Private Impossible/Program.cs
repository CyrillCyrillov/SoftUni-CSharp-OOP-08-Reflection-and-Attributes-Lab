using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();


            string resultPrivateMethods = spy.RevealPrivateMethods(typeof(Hacker).FullName);
            Console.WriteLine(resultPrivateMethods);


            //Console.WriteLine("Hello World!");
        }
    }
}

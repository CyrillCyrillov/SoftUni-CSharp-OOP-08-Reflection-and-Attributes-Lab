using System;
using System.Reflection;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(result);

            //int test = 1;

            //Console.WriteLine("Hello World!");
        }
    }
}

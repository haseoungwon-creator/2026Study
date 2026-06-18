using System.Diagnostics;

namespace Generic
{
    internal class Program
    {
        void Test<T>(T value)where T : class
        {
            Console.WriteLine(value);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Test("hello");


        }
    }
}


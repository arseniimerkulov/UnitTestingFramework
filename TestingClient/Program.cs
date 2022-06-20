using System;

namespace TestingClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var app = new App();
            var result = app.Run();
            Console.WriteLine(result);
        }
    }
}

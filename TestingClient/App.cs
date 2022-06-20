using System;
using System.IO;
using UnitTestingFramework;

namespace TestingClient
{
    enum ReturnResult
    {
        Success = 0,
        Error = 1,
    }
    internal class App
    {
        public ReturnResult Run()
        {
            Console.WriteLine("Enter full path to assembly where you want to test something:");
            Console.WriteLine("\t*Choose .dll file from ..\\bin\\ dir instead of ..\\obj\\");            

            var path = Console.ReadLine();
            while (!File.Exists(path))
            {
                Console.WriteLine("File was not found, try again");
                path = Console.ReadLine();
            }

            try
            {
                var testRunner = new TestRunner();
                var results = testRunner.RunTests(path);                
                foreach (var testResult in results)
                {
                    Console.WriteLine(testResult.Name + " " + testResult.Success);
                    if(testResult.Success == false)
                    {
                        Console.WriteLine("Error message: " + testResult.Error);
                    }
                }
            }
            catch (Exception)
            {

                return ReturnResult.Error;
            }

            return ReturnResult.Success;
        }

    }
}

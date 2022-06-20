using System;
using TestingItems;
using UnitTestingFramework;
using UnitTestingFramework.Attributes;

namespace UnitTests
{
    [TestClass]
    public class MathOperationsTests
    {
        public void ValidSumArgs_ReturnsCorrectResult()
        {
            int a = 5;
            int b = 7;

            var expected = 12;

            var simple = new MathOperations();
            int actual = simple.Add(a, b);

            Assert.Equal(expected, actual);
        }
        
        public void ValidSubstractArgs_ReturnsCorrectResult()
        {
            int a = 15;
            int b = 7;

            var expected = 8;

            var simple = new MathOperations();
            int actual = simple.Substract(a, b);

            Assert.Equal(expected, actual);
        }
        
        public void ValidStringsConcat_ReturnsSuccess()
        {
            var a = "Mykolaiv";
            var b = "Kharkiv";

            var expected = "MykolaivKharkiv";

            var simple = new MathOperations();
            var actual = simple.ConcatStrings(a, b);

            Assert.Equal(expected, actual);
        }
        public void EnvironmentChanger()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace UnitTestingFramework
{
    public class Assert
    {
        public static void Equal<T>(T expected, T actual)
        {
            var comparer = new Comparer(CultureInfo.InvariantCulture);
            var resultOfCoparison = comparer.Compare(expected, actual);
            if(resultOfCoparison != 0)
            {
                throw new TestException(string.Format("Expected to recieve {0} but recieved {1}", expected, actual));
            }            
        }
        public void IsTrue(bool actual)
        {
            var expected = true;

            if (expected != actual)
            {
                throw new TestException(string.Format("Expected to recieve {0} but recieved {1}", expected, actual));
            }
        }
        public void IsFalse(bool actual)
        {
            var expected = false;
            if (expected != actual)
            {
                throw new TestException(string.Format("Expected to recieve {0} but recieved {1}", expected, actual));
            }
        }

    }
}

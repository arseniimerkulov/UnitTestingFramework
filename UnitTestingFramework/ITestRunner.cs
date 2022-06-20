using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingFramework
{
    public interface ITestRunner
    {
        List<Test> RunTests(string pathToTestLib);
    }
}

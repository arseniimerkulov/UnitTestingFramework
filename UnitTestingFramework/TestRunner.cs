using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnitTestingFramework.Attributes;

namespace UnitTestingFramework
{
    public class TestRunner : ITestRunner
    {
        public List<Test> RunTests(string pathToTestLib)
        {
            var listOfTestResults = new List<Test>();
            var assembly = Assembly.LoadFrom(pathToTestLib);

            var types = assembly.GetTypes();

            var testClasses = new List<Type>();

            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                var testMethods = methods.Where(m => m.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(FactAttribute))).ToList();
                
                if(type.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(TestClassAttribute)))
                {
                    testClasses.Add(type);
                }

                if (testMethods.Any())
                {                    

                    listOfTestResults.AddRange(RunMethodsTests(testMethods, type));
                }
            }
            if (testClasses.Any())
            {
                listOfTestResults.AddRange(RunAllMethodsFromClass(testClasses));
            }

            return listOfTestResults;
        }

        private List<Test> RunAllMethodsFromClass(List<Type> types)
        {
            var testResults = new List<Test>();
            foreach (var type in types)
            {                
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).ToList();
                testResults.AddRange(RunMethodsTests(methods, type));
            }
            return testResults;
        }

        private List<Test> RunMethodsTests(List<MethodInfo> testMethods, Type type)
        {
            var listOfTestResults = new List<Test>();
            var instanseOfTestClass = Activator.CreateInstance(type);
            foreach (var testMethod in testMethods)
            {
                var testResult = new Test();
                testResult.Name = string.Format("{0}.{1}", type.Name, testMethod.Name);
                try
                {
                    testMethod.Invoke(instanseOfTestClass, null);
                    testResult.Success = true;
                }
                catch (TestException ex)
                {
                    testResult.Error = ex.Message;

                    testResult.Success = false;
                }
                catch (Exception ex)
                {
                    testResult.Error = ex.InnerException.Message;

                    testResult.Success = false;
                }
                listOfTestResults.Add(testResult);
            }
            return listOfTestResults;
        }
    }
}

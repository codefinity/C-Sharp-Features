using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Threading.Tasks;

namespace LocalFunctions
{
    class Program
    {
        //References:   https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#ref-locals-and-returns
        //              https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions
        //              https://devblogs.microsoft.com/premier-developer/dissecting-the-local-functions-in-c-7/
        //              https://stackoverflow.com/questions/40943117/local-function-vs-lambda-c-sharp-7-0

        //Local functions enable you to declare methods inside the context of another method. 
        //Local functions make it easier for readers of the class to see that the local method 
        //is only called from the context in which it is declared.

        //Rules: 
        //Note that all local variables that are defined in the containing member, 
        //including its method parameters, are accessible in the local function.

        //Unlike a method definition, a local function definition cannot include the member access modifier.
        //Because all local functions are private, including an access modifier, such as the private keyword, 
        //generates compiler error CS0106, "The modifier 'private' is not valid for this item."

        //In addition, attributes can't be applied to the local function or to its parameters and type parameters.

        static void Main(string[] args)
        {
            string contents = GetText(@"C:\temp", "example.txt");

            Console.WriteLine("Contents of the file:\n" + contents);
        }

        private static string GetText(string path, string filename)
        {
            var sr = File.OpenText(AppendPathSeparator(path) + filename);
            var text = sr.ReadToEnd();
            return text;

            // Declare a local function.
            string AppendPathSeparator(string filepath)
            {
                if (!filepath.EndsWith(@"\"))
                    filepath += @"\";

                return filepath;
            }
        }


        //There are two common use cases for local functions: public iterator methods and public async methods. 
        //Both types of methods generate code that reports errors later than programmers might expect. 
        //In iterator methods, any exceptions are observed only when calling code that enumerates the returned 
        //sequence. In async methods, any exceptions are only observed when the returned Task is awaited. 
        //The following example demonstrates separating parameter validation from the iterator implementation 
        //using a local function:

        public static IEnumerable<char> AlphabetSubset3(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");

            return alphabetSubsetImplementation();

            IEnumerable<char> alphabetSubsetImplementation()
            {
                for (var c = start; c < end; c++)
                    yield return c;
            }
        }

        //The same technique can be employed with async methods to ensure that exceptions 
        //arising from argument validation are thrown before the asynchronous work begins:

        public Task<string> PerformLongRunningWork(string address, int index, string name)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException(message: "An address is required", paramName: nameof(address));
            if (index < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "The index must be non-negative");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));

            return longRunningWorkImplementation();

            async Task<string> longRunningWorkImplementation()
            {
                var interimResult = await FirstWork(address);
                var secondResult = await SecondStep(index, name);
                return $"The results are {interimResult} and {secondResult}. Enjoy.";
            }

            async Task<int> SecondStep(int index, string name)
            {
                throw new NotImplementedException();
            }

            async Task<int> FirstWork(string address)
            {
                throw new NotImplementedException();
            }
        }


        //At first glance, local functions and lambda expressions are very similar. 
        //In many cases, the choice between using lambda expressions and local functions is a matter of 
        //style and personal preference. However, there are real differences in where you can use one or 
        //the other that you should be aware of.

        //Let's examine the differences between the local function and lambda expression implementations 
        //of the factorial algorithm.
        //First the version using a local function:

        public static int LocalFunctionFactorial(int n)
        {
            return nthFactorial(n);

            int nthFactorial(int number) => (number < 2) ?
                1 : number * nthFactorial(number - 1);
        }

        //Contrast that implementation with a version that uses lambda expressions:

        public static int LambdaFactorial(int n)
        {
            Func<int, int> nthFactorial = default(Func<int, int>);

            nthFactorial = (number) => (number < 2) ?
                1 : number * nthFactorial(number - 1);

            return nthFactorial(n);
        }

        //The local functions have names. The lambda expressions are anonymous 
        //methods that are assigned to variables that are Func or Action types. 
        //When you declare a local function, the argument types and return type 
        //are part of the function declaration. Instead of being part of the 
        //body of the lambda expression, the argument types and return type are 
        //part of the lambda expression's variable type declaration. 
        //Those two differences may result in clearer code.




    }
}

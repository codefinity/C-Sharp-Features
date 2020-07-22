using System;

//
using static System.Math;
using static System.Console;

namespace UsingStatic
{
    class Program
    {
        static void Main(string[] args)
        {

            //Reference: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-static

            double twoPowerFiveMath = Math.Pow(2, 5);

            //C# using static directive helps us to access static members 
            //(methods and fields) of the class without using the class name.

            //By eliminating the need to explicitly reference the 
            //Math class each time a member is referenced, the using static 
            //directive produces much cleaner code:

            //using static imports only accessible static members and nested types 
            //declared in the specified type. Inherited members are not imported.
            double twoPowerFive = Pow(2, 5);

            Console.WriteLine("With Console");

            WriteLine("Without Console");


            //using static makes extension methods declared in the specified type available 
            //for extension method lookup. However, the names of the extension methods are 
            //not imported into scope for unqualified reference in code.

            //Methods with the same name imported from different types by different using 
            //static directives in the same compilation unit or namespace form a method group.
            //Overload resolution within these method groups follows normal C# rules.


        }
    }
}

using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Discards
{
    class Program
    {
        static void Main(string[] args)
        {

            //References:   https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#discards
            //              https://docs.microsoft.com/en-us/dotnet/csharp/discards
            //              https://www.c-sharpcorner.com/article/c-sharp-7-0-and-c-sharp-7-1-new-features-part-two/

            //Often when deconstructing a tuple or calling a method with out parameters, 
            //you're forced to define a variable whose value you don't care about and 
            //don't intend to use. C# adds support for discards to handle this scenario.
            //A discard is a write-only variable whose name is _ (the underscore character); 
            //you can assign all of the values that you intend to discard to the single variable. 
            //A discard is like an unassigned variable; apart from the assignment statement, 
            //the discard can't be used in code.

            //Discards are supported in the following scenarios:

            //When deconstructing tuples or user - defined types.
            //When calling methods with out parameters.
            //In a pattern matching operation with the is and switch statements.
            //As a standalone identifier when you want to explicitly identify the value of an assignment as a discard.


            //Tuple and object deconstruction:
            //The following example defines a QueryCityDataForYears method that returns
            //a 6 - tuple that contains data for a city for two different years.
            //The method call in the example is concerned only with the two population 
            //values returned by the method and so treats the remaining values in the tuple
            //as discards when it deconstructs the tuple.


            var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);

            Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");

            // The example displays the following output:
            //      Population change, 1960 to 2010: 393,149

            var p = new Person("John", "Quincy", "Adams", "Boston", "MA");

            // <Snippet1>
            // Deconstruct the person object.
            var (fName, _, city, _) = p;
            Console.WriteLine($"Hello {fName} of {city}!");
            // The example displays the following output:
            //      Hello John of Boston!
            // </Snippet1>

            // The example displays the following output:
            //    Hello John Adams of Boston, MA!


            //Discard with Out Paramater

            int a = 10, b = 20;
            Result(a, b, out int sum, out int _, out int _, out int _, out int _);
            Console.WriteLine($"Sum of {a} and {b} is {sum}");

            // datatype passing is also optional, and we can remove data type as well. 
            // Following is the code snippet for the same.

            int ax = 10, bx = 20;
            Result(ax, bx, out int sumx, out _, out _, out _, out _);
            Console.WriteLine($"Sum of {ax} and {bx} is {sumx}");


            //Pattern matching with switch and is
            //The discard pattern can be used in pattern matching with the is and switch keywords.
            //Every expression always matches the discard pattern.

            //The following example defines a ProvidesFormatInfo method that uses is statements to 
            //determine whether an object provides an IFormatProvider implementation and tests 
            //whether the object is null.It also uses the discard pattern to handle non-null objects 
            //of any other type.

            object[] objects = { CultureInfo.CurrentCulture,
                           CultureInfo.CurrentCulture.DateTimeFormat,
                           CultureInfo.CurrentCulture.NumberFormat,
                           new ArgumentException(), null };
            foreach (var obj in objects)
                ProvidesFormatInfo(obj);

            //A standalone discard
            //You can use a standalone discard to indicate any variable that you choose to ignore. 
            //The following example uses a standalone discard to ignore the Task object returned 
            //by an asynchronous operation. This has the effect of suppressing the exception that 
            //the operation throws as it is about to complete.

            //await ExecuteAsyncMethods();








        }

        //Note that _ is also a valid identifier. When used outside of a supported context, 
        //_ is treated not as a discard but as a valid variable. If an identifier named 
        //_ is already in scope, the use of _ as a standalone discard can result in:

        //Accidental modification of the value of the in-scope _ variable by assigning it the 
        //value of the intended discard.For example:

        private static void ShowValue(int _)
        {
            byte[] arr = { 0, 0, 1, 2 };
            _ = BitConverter.ToInt32(arr, 0);
            Console.WriteLine(_);
        }
        // The example displays the following output:
        //       33619968
        //A compiler error for violating type safety.For example:



        //private static bool RoundTrips(int _)
        //{
        //    string value = _.ToString();
        //    int newValue = 0;
        //    _ = Int32.TryParse(value, out newValue);
        //    return _ == newValue;
        //}
        // The example displays the following compiler error:
        //      error CS0029: Cannot implicitly convert type 'bool' to 'int'
        //Compiler error CS0136, "A local or parameter named '_' cannot be declared in this 
        //scope because that name is used in an enclosing local scope to define a local or parameter." 
        //For example:


        //public void DoSomething(int _)
        //{
        //    var _ = GetValue(); // Error: cannot declare local _ when one is already in scope
        //}
        // The example displays the following compiler error:
        // error CS0136:
        //       A local or parameter named '_' cannot be declared in this scope
        //       because that name is used in an enclosing local scope
        //       to define a local or parameter



        // The example displays output like the following:
        //       About to launch a task...
        //       Completed looping operation...
        private static async Task ExecuteAsyncMethods()
        {
            Console.WriteLine("About to launch a task...");
            _ = Task.Run(() =>
            {
                var iterations = 0;
                for (int ctr = 0; ctr < int.MaxValue; ctr++)
                    iterations++;
                Console.WriteLine("Completed looping operation...");
                throw new InvalidOperationException();
            });
            await Task.Delay(5000);
            Console.WriteLine("Exiting after 5 second delay");
        }

        // 

        private static void ProvidesFormatInfo(object obj)
        {
            switch (obj)
            {
                case IFormatProvider fmt:
                    Console.WriteLine($"{fmt} object");
                    break;
                case null:
                    Console.Write("A null object reference: ");
                    Console.WriteLine("Its use could result in a NullReferenceException");
                    break;
                case object _:
                    Console.WriteLine("Some object type without format information");
                    break;
            }
        }

        private static void Result(int x, int y, out int sum, out int diff, out int mult, out int div, out int modDiv)
        {
            sum = x + y;
            diff = x - y;
            mult = x * y;
            div = x / y;
            modDiv = x % y;
        }


        private static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
        {
            int population1 = 0, population2 = 0;
            double area = 0;

            if (name == "New York City")
            {
                area = 468.48;
                if (year1 == 1960)
                {
                    population1 = 7781984;
                }
                if (year2 == 2010)
                {
                    population2 = 8175133;
                }
                return (name, area, year1, population1, year2, population2);
            }

            return ("", 0, 0, 0, 0, 0);
        }
    }
}

using System;
using System.Collections.Generic;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reference: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#tuples
            //You may often write methods that need a simple structure containing more than one data element. 
            //To support these scenarios tuples were added to C#. Tuples are lightweight data structures 
            //that contain multiple fields to represent the data members. The fields aren't validated, and 
            //you can't define your own methods

            //You can create a tuple by assigning a value to each member, and optionally providing semantic 
            //names to each of the members of the tuple:
            //The namedLetters tuple contains fields referred to as Alpha and Beta. 
            //Those names exist only at compile time and aren't preserved, for example when inspecting the 
            //tuple using reflection at run time.

            var person = (1, "Bill", "Gates");

            Console.WriteLine(person.Item1);
            Console.WriteLine(person.Item2);
            Console.WriteLine(person.Item3);

            (double, int) t1 = (4.5, 3);
            Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}.");
            // Output:
            // Tuple with elements 4.5 and 3.

            (string Alpha, string Beta) namedLetters = ("a", "b");

            Console.WriteLine($"{namedLetters.Alpha}, {namedLetters.Beta}");

            //In a tuple assignment, you can also specify the names of the fields on the right-hand 
            //side of the assignment:

            var alphabetStart = (Alpha: "a", Beta: "b");
            Console.WriteLine($"{alphabetStart.Alpha}, {alphabetStart.Beta}");

            //There may be times when you want to unpackage the members of a tuple that were returned
            //from a method. You can do that by declaring separate variables for each of the values in 
            //the tuple.This unpackaging is called deconstructing the tuple:

            (int max, int min) = Range(10);
            Console.WriteLine(max);
            Console.WriteLine(min);

            // change property names
            (int personId, string fName, string lName) = GetPerson();
            Console.WriteLine(personId);
            Console.WriteLine(fName);
            Console.WriteLine(lName);


            //You can also provide a similar deconstruction for any type in .NET. You write a
            //Deconstruct method as a member of the class. That Deconstruct method provides 
            //a set of out arguments for each of the properties you want to extract. 
            //Consider this Point class that provides a deconstructor method that extracts 
            //the X and Y coordinates:

            //You can extract the individual fields by assigning a Point to a tuple:

            var p = new Point(3.14, 2.71);
            (double X, double Y) = p;
            Console.WriteLine(X);
            Console.WriteLine(Y);

            //Tuples as out parameters
            //Typically, you refactor a method that has out parameters into a method that returns a tuple. 
            //However, there are cases in which an out parameter can be of a tuple type.

            var limitsLookup = new Dictionary<int, (int Min, int Max)>()
            {
                [2] = (4, 10),
                [4] = (10, 20),
                [6] = (0, 23)
            };

            if (limitsLookup.TryGetValue(4, out (int Min, int Max) limits))
            {
                Console.WriteLine($"Found limits: min is {limits.Min}, max is {limits.Max}");
            }
            // Output:
            // Found limits: min is 10, max is 20


        }

        private static (int max, int min) Range(int number)
        {
            return (number - 1, number + 1);
        }

        static (int, string, string) GetPerson()
        {
            return (Id: 1, FirstName: "Bill", LastName: "Gates");
        }
    }
}

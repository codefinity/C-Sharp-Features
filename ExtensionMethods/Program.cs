using ExtensionMethods.Extensions;
using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //Extension methods enable you to "add" methods to existing types without 
            //creating a new derived type, recompiling, or otherwise modifying the original type. 
            //Extension methods are static methods, but they're called as if they were instance 
            //methods on the extended type. 

            //Extension methods cannot access private variables in the type they are extending.

            //Example of extension methods on existing types
            string str = "Hello Extension Methods";
            int count = str.WordCount();
            Console.WriteLine(count);

            //Example of extension methods of custom types
            MathUtility mathUtility = new MathUtility();
            int average = mathUtility.Average(1, 2, 3, 4, 5, 6, 7, 8);
            Console.WriteLine(average);


            //An extension method will never be called if it has the same signature as a method defined 
            //in the type.

            //Extension methods are brought into scope at the namespace level.For example, 
            //if you have multiple static classes that contain extension methods in a single 
            //namespace named Extensions, they'll all be brought into scope by the using Extensions; 
            //directive.

            //====Binding Extension Methods at Compile Time====
            //You can use extension methods to extend a class or interface, but not to override them.
            //An extension method with the same name and signature as an interface or class method will 
            //never be called.At compile time, extension methods always have lower priority than 
            //instance methods defined in the type itself.In other words, if a type has a method named 
            //Process(int i), and you have an extension method with the same signature, the compiler
            //will always bind to the instance method.When the compiler encounters a method invocation, 
            //it first looks for a match in the type's instance methods. If no match is found, it will 
            //search for any extension methods that are defined for the type, and bind to the first 
            //extension method that it finds. The following example demonstrates how the compiler determines 
            //which extension method or instance method to bind to.


            //Source: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods


        }
    }
}

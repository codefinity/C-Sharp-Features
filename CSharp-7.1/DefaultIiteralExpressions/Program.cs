using System;

namespace DefaultIiteralExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //References:
            //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-1#default-literal-expressions
            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/default

            //Default literal expressions are an enhancement to default value expressions. 
            //These expressions initialize a variable to the default value. Where you previously would write:

            Func<string, bool> whereClausePrevious = default(Func<string, bool>);


            Console.WriteLine(default(int));  // output: 0
            Console.WriteLine(default(object) is null);  // output: True

            DisplayDefaultOf<int?>();
            DisplayDefaultOf<System.Numerics.Complex>();
            DisplayDefaultOf<System.Collections.Generic.List<int>>();
            // Output:
            // Default value of System.Nullable`1[System.Int32] is null.
            // Default value of System.Numerics.Complex is (0, 0).
            // Default value of System.Collections.Generic.List`1[System.Int32] is null.

            void DisplayDefaultOf<T>()
            {
                var val = default(T);
                Console.WriteLine($"Default value of {typeof(T)} is {(val == null ? "null" : val.ToString())}.");
            }


            //You can now omit the type on the right - hand side of the initialization:

            Func<string, bool> whereClause = default;


            //Beginning with C# 7.1, you can use the default literal to produce the default 
            //value of a type when the compiler can infer the expression type. The default 
            //literal expression produces the same value as the 
            //default(T) expression where T is the inferred type. 
            //You can use the default literal in any of the following cases:

            //In the assignment or initialization of a variable.
            //In the declaration of the default value for an optional method parameter.
            //In a method call to provide an argument value.
            //In a return statement or as an expression in an expression-bodied member.
            //The following example shows the usage of the default literal:

            Display(InitializeArray<int>(3));  // output: [ 0, 0, 0 ]
            Display(InitializeArray<bool>(4, default));  // output: [ False, False, False, False ]

            System.Numerics.Complex fillValue = default;
            Display(InitializeArray(3, fillValue));  // output: [ (0, 0), (0, 0), (0, 0) ]




        }

        static void Display<T>(T[] values) => Console.WriteLine($"[ {string.Join(", ", values)} ]");
        public static T[] InitializeArray<T>(int length, T initialValue = default)
        {
            if (length < 0)
            {
                return default;
            }

            var array = new T[length];
            for (var i = 0; i < length; i++)
            {
                array[i] = initialValue;
            }
            return array;
        }
    }
}

using System;
using System.Threading.Tasks;
using static LambdaExpressions.VariableScopeWithLambdas;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //IMPORTANT
            //http://tutorials.jenkov.com/java/lambda-expressions.html
            //A lambda expression is thus a function which can be created without belonging to any class. 
            //A lambda expression can be passed around as if it was an object and executed on demand.

            //Lambda expressions are commonly used to implement simple event listeners / callbacks, 
            //or in functional programming with the Java Streams API.

            //A lambda expression, in the world of computer programming, is a function not bound to 
            //an identifier.That also means it can be used as a variable or passed in as a method parameter.

            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions
            //Lambda expressions can be written with a single or multiple lines.
            //They can be assigned to variables or inline. LINQ, one of my favorite C# features, 
            //uses lambda expression. I’ll provide some sample code in C#.


            //Any lambda expression can be converted to a delegate type. 
            //The delegate type to which a lambda expression can be converted is defined by the types of its 
            //parameters and return value. 

            //If a lambda expression doesn't return a value, it can be converted to one of the Action delegate types; 
            //otherwise, it can be converted to one of the Func delegate types. 

            //For example, a lambda expression that has two parameters and returns no value can be 
            //converted to an Action<T1,T2> delegate. 

            Action<int, int> sum = (num1, num2) => Console.WriteLine(num1 + num2);
            sum(2, 4);

            //A lambda expression that has one parameter and returns a value can be converted to a 
            //Func<T,TResult> delegate. In the following example, the lambda expression x => x * x, 
            //which specifies a parameter that's named x and returns the value of x squared, 
            //is assigned to a variable of a delegate type:

            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));
            // Output:
            // 25

            Func<int, int, int> multiply = (x, y) => x * y;
            Console.WriteLine(multiply(5, 2));
            // Output:
            // 25

            //*Expression lambda that has an expression as its body:

            //(input - parameters) => expression

            //*Statement lambda that has a statement block as its body:

            //(input - parameters) => { < sequence - of - statements > }

            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
            greet("World");
            // Output:
            // Hello World!

            //Predicate
            Predicate<int> equalsFive = x => x == 5;

            bool result = equalsFive(4);
            Console.WriteLine(result);   // False


            //Async Lambda Expressions

            //button1.Click += async (sender, e) =>
            //{
            //    await ExampleMethodAsync();
            //    textBox1.Text += "\r\nControl returned to Click event handler.\n";
            //};



            //===================================================================================

            //Lambdas can refer to outer variables.These are the variables that are in scope 
            //in the method that defines the lambda expression, or in scope in the type that 
            //contains the lambda expression.

            var game = new VariableCaptureGame();

            int gameInput = 5;
            game.Run(gameInput);

            int jTry = 10;
            bool resultX = game.isEqualToCapturedLocalVariable(jTry);
            Console.WriteLine($"Captured local variable is equal to {jTry}: {resultX}");

            int anotherJ = 3;
            game.updateCapturedLocalVariable(anotherJ);

            bool equalToAnother = game.isEqualToCapturedLocalVariable(anotherJ);
            Console.WriteLine($"Another lambda observes a new value of captured variable: {equalToAnother}");

            // Output:
            // Local variable before lambda invocation: 0
            // 10 is greater than 5: True
            // Local variable after lambda invocation: 10
            // Captured local variable is equal to 10: True
            // 3 is greater than 5: False
            // Another lambda observes a new value of captured variable: True

        }
    }
}

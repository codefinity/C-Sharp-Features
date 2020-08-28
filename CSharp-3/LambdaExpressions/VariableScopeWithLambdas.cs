using System;
using System.Collections.Generic;
using System.Text;

namespace LambdaExpressions
{
    public static class VariableScopeWithLambdas
    {

        //Lambdas can refer to outer variables.These are the variables that are in scope 
        //in the method that defines the lambda expression, or in scope in the type that 
        //contains the lambda expression.Variables that are captured in this manner are 
        //stored for use in the lambda expression even if the variables would otherwise go 
        //out of scope and be garbage collected. An outer variable must be definitely assigned 
        //before it can be consumed in a lambda expression.
        //The following example demonstrates these rules:

        public class VariableCaptureGame
        {
            internal Action<int> updateCapturedLocalVariable;
            internal Func<int, bool> isEqualToCapturedLocalVariable;

            public void Run(int input)
            {
                int j = 0;

                updateCapturedLocalVariable = x =>
                {
                    j = x;
                    bool result = j > input;
                    Console.WriteLine($"{j} is greater than {input}: {result}");
                };

                isEqualToCapturedLocalVariable = x => x == j;

                Console.WriteLine($"Local variable before lambda invocation: {j}");
                updateCapturedLocalVariable(10);
                Console.WriteLine($"Local variable after lambda invocation: {j}");
            }
        }


    }
}

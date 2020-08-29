using System;

namespace ThrowExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starting with C# 7.0, throw can be used as an expression as well as a statement. 
            //This allows an exception to be thrown in contexts that were previously unsupported. 
            //These include:

            //The conditional operator. The following example uses a throw expression to throw an 
            //ArgumentException if a method is passed an empty string array. 
            //Before C# 7.0, this logic would need to appear in an if/else statement.

            int x = 10;

            string arg = x >= 1 ? "Good" :
                                            throw new ArgumentException("You must supply an argument");


        }


        //the null-coalescing operator. In the following example, a throw expression is used with a 
        //null-coalescing operator to throw an exception if the string assigned to a Name property is null.

        string name;
        public string Name
        {
            get => name;
            set => name = value ??
                throw new ArgumentNullException(paramName: nameof(value), message: "Name cannot be null");
        }


        private object Square(int? numberToBeSquared) => (numberToBeSquared * numberToBeSquared)
                                                    ?? throw new ArgumentNullException(nameof(numberToBeSquared));






    }
}


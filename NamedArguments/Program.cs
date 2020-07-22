using System;

namespace NamedArguments
{
    class Program
    {
        static void Main(string[] args)
        {
            //Named arguments enable you to specify an argument for a particular 
            //parameter by associating the argument with the parameter's name rather 
            //than with the parameter's position in the parameter list

            //Named arguments free you from the need to remember or to look up the order 
            //of parameters in the parameter lists of called methods. The parameter for 
            //each argument can be specified by parameter name.


            // The method can be called in the normal way, by using positional arguments.
            PrintOrderDetails("Gift Shop", 31, "Red Mug");

            // Named arguments can be supplied for the parameters in any order.
            PrintOrderDetails(orderNum: 31, productName: "Red Mug", sellerName: "Gift Shop");
            PrintOrderDetails(productName: "Red Mug", sellerName: "Gift Shop", orderNum: 31);

            // Named arguments mixed with positional arguments are valid
            // as long as they are used in their correct position.
            PrintOrderDetails("Gift Shop", 31, productName: "Red Mug");
            PrintOrderDetails(sellerName: "Gift Shop", 31, productName: "Red Mug");    // C# 7.2 onwards
            PrintOrderDetails("Gift Shop", orderNum: 31, "Red Mug");                   // C# 7.2 onwards

            // However, mixed arguments are invalid if used out-of-order.
            // The following statements will cause a compiler error.
            // PrintOrderDetails(productName: "Red Mug", 31, "Gift Shop");
            // PrintOrderDetails(31, sellerName: "Gift Shop", "Red Mug");
            // PrintOrderDetails(31, "Red Mug", sellerName: "Gift Shop");

        }

        static void PrintOrderDetails(string sellerName, int orderNum, string productName)
        {
            if (string.IsNullOrWhiteSpace(sellerName))
            {
                throw new ArgumentException(message: "Seller name cannot be null or empty.", paramName: nameof(sellerName));
            }

            Console.WriteLine($"Seller: {sellerName}, Order #: {orderNum}, Product: {productName}");
        }
    }
}

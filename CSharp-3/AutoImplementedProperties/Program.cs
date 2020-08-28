using System;
using System.Diagnostics;

namespace AutoImplementedProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // Intialize a new object.
            Customer customer = new Customer(4987.63, "Northwind", 90108);

            // Modify a property.
            customer.TotalPurchases += 499.99;

            //Source: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
        }
    }
}

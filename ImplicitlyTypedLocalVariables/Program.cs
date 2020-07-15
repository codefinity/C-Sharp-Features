using AutoImplementedProperties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImplicitlyTypedLocalVariables
{
    class Program
    {
        //* var cannot be declared as global variable
        //private var globalVariable;

        static void Main(string[] args)
        {
            //Beginning in Visual C# 3.0, variables that are declared at method scope can have an implicit "type" var.
            //An implicitly typed local variable is strongly typed just as if you had declared the type yourself, 
            //but the compiler determines the type. 

            //The following two declarations of imp & exp are functionally equivalent:
            var imp = 10; // Implicitly typed.
            int exp = 10; // Explicitly typed.

            // i is compiled as an int
            var i = 5;

            // s is compiled as a string
            var s = "Hello";

            // a is compiled as int[]
            var a = new[] { 0, 1, 2 };

            // anon is compiled as an anonymous type
            var anon = new { Name = "Terry", Age = 34 };

            // list is compiled as List<int>
            var list = new List<int>();


            //** Important: A new type cannot be assigned once a type is defined initially.
            var impVar = 10;
            //impvar = "new string";

            //Cannot declare implicitly typed variable without any initialization like:
            //var locvar;

            //not allowed to use a null value in implicitly typed variable like:
            //var value = null;

            // Example #1: var is optional when
            // the select clause specifies a string
            string[] words = { "apple", "strawberry", "grape", "peach", "banana" };
            var wordQuery = from word in words
                            where word[0] == 'g'
                            select word;

            // Because each element in the sequence is a string,
            // not an anonymous type, var is optional here also.
            foreach (string qry in wordQuery)
            {
                Console.WriteLine(qry);
            }


            List<Customer> customers = new List<Customer>() { new Customer { CustomerId=1, Name = "", TotalPurchases=1},
                                                            new Customer {  CustomerId=1, Name = "", TotalPurchases=1},
                                                            new Customer {  CustomerId=1, Name = "", TotalPurchases=1},
                                                            new Customer {  CustomerId=1, Name = "", TotalPurchases=1}
                                                            };


            // Example #2: var is required because
            // the select clause specifies an anonymous type
            var custQuery = from cust in customers
                            where cust.City == "Phoenix"
                            select new { cust.Name, cust.Phone };

            // var must be used because each item
            // in the sequence is an anonymous type
            foreach (var item in custQuery)
            {
                Console.WriteLine("Name={0}, Phone={1}", item.Name, item.Phone);
            }


        }
    }
}

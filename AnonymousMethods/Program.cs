using System;

namespace AnonymousMethods
{
    class Program
    {
        public delegate void Print(int value);
        static void Main(string[] args)
        {
            //As the name suggests, an anonymous method is a method without a name.
            //Anonymous methods in C# can be defined using the delegate keyword and can be 
            //assigned to a variable of delegate type.

            Print print = delegate (int val) {
                Console.WriteLine("Inside Anonymous method. Value: {0}", val);
            };

            print(100);


            //Anonymous methods can access variables defined in an outer function.

            int i = 10;

            Print prnt2 = delegate (int val) {
                val += i;
                Console.WriteLine("Anonymous method: {0}", val);
            };

            prnt2(100);

            //Anonymous methods can also be passed to a method that accepts the delegate as a parameter.
            PrintHelperMethod(prnt2, 100);


        }

        public static void PrintHelperMethod(Print printDel, int val)
        {
            val += 10;
            printDel(val);
        }
    }
}

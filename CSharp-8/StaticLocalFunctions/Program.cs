using System;

namespace StaticLocalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            //You can now add the static modifier to local functions to ensure that local function 
            //doesn't capture (reference) any variables from the enclosing scope. 
            //Doing so generates CS8421, "A static local function can't contain a reference to<variable>."

            //IMPORTANT:
            //It forces the local function to be a pure function that does not modify the state of the caller.

            //Consider the following code. The local function LocalFunction accesses the variable y, 
            //declared in the enclosing scope(the method M).
            //Therefore, LocalFunction can't be declared with the static modifier:


            FuncOne();
            FuncTwo();

        }

        static int FuncOne()
        {
            int x;
            int y;
            LocalFunction();
            LocalFunction2();
            return y + x;

            //Can access the variable outside the function
            void LocalFunction() => y = 0;

            void LocalFunction2()
            {
                x = 100;
            }
        }

        static int FuncTwo()
        {
            int y = 5;
            int x = 7;
            return Add(x, y);

            static int Add(int left, int right) => left + right;

            //Cannot access the variable outside the function
            //static void LocalFunction() => y = 0;

            //static void LocalFunction2()
            //{
            //    x = 100;
            //}
        }
    }
}

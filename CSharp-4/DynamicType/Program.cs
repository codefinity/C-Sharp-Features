using System;

namespace DynamicType
{
    class Program
    {
        static void Main(string[] args)
        {
            //For example, if instance method exampleMethod1 in the following code has only one parameter, 
            //the compiler recognizes that the first call to the method, ec.exampleMethod1(10, 4), 
            //is not valid because it contains two arguments.The call causes a compiler error. 
            //The second call to the method, dynamic_ec.exampleMethod1(10, 4), is not checked by the 
            //compiler because the type of dynamic_ec is dynamic.Therefore, no compiler error is reported.
            //However, the error does not escape notice indefinitely.It is caught at run time and causes a 
            //run-time exception.

            ExampleClass ec = new ExampleClass();
            // The following call to exampleMethod1 causes a compiler error
            // if exampleMethod1 has only one parameter. Uncomment the line
            // to see the error.
            //ec.exampleMethod1(10, 4);

            dynamic dynamic_ec = new ExampleClass();
            // The following line is not identified as an error by the
            // compiler, but it causes a run-time exception.
            dynamic_ec.exampleMethod1(10, 4);

            // The following calls also do not cause compiler errors, whether
            // appropriate methods exist or not.
            dynamic_ec.someMethod("some argument", 7, null);
            dynamic_ec.nonexistentMethod();


            //Conversions

            //Conversions between dynamic objects and other types are easy. 
            //This enables the developer to switch between dynamic and non - dynamic behavior.

            //Any object can be converted to dynamic type implicitly, as shown in the following examples.


            dynamic d1 = 7;
            dynamic d2 = "a string";
            dynamic d3 = System.DateTime.Today;
            dynamic d4 = System.Diagnostics.Process.GetProcesses();

            //Conversely, an implicit conversion can be dynamically applied to any expression of type dynamic.


            int i = d1;
            string str = d2;
            DateTime dt = d3;
            System.Diagnostics.Process[] procs = d4;


            //Overload resolution with arguments of type dynamic

            //Overload resolution occurs at run time instead of at compile time if one or more of the arguments 
            //in a method call have the type dynamic, or if the receiver of the method call is of type dynamic.
            //In the following example, if the only accessible exampleMethod2 method is defined to take a 
            //string argument, sending d1 as the argument does not cause a compiler error, but it does cause 
            //a run-time exception.Overload resolution fails at run time because the run - time type of d1 is int, 
            //and exampleMethod2 requires a string.


            // Valid.
            ec.exampleMethod2("a string");

            // The following statement does not cause a compiler error, even though ec is not
            // dynamic. A run-time exception is raised because the run-time type of d1 is int.
            ec.exampleMethod2(d1);
            // The following statement does cause a compiler error.
            //ec.exampleMethod2(7);


            //Further Reference
            //https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/dynamic-language-runtime-overview
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/walkthrough-creating-and-using-dynamic-objects
            //https://visualstudiomagazine.com/Articles/2011/02/01/Understanding-the-Dynamic-Keyword-in-C4.aspx

            //Use of Dynamic
            //https://stackoverflow.com/questions/2690623/what-is-the-dynamic-type-in-c-sharp-4-0-used-for


            //var v/s dynamic
            //References:   https://www.c-sharpcorner.com/UploadFile/f0b2ed/dynamic-data-type-in-C-Sharp/
            //              https://www.c-sharpcorner.com/UploadFile/b1df45/var-vs-dynamic-keywords-in-C-Sharp/

            //1. Need of initialization for var is required at the time of declaration; 
            //In the case of dynamicthere is no need to initialize at the time of declaration.

            dynamic dynamicVariable;
            dynamicVariable = "No Initialization Required.";

            //Error
            //var varVariable;
            //varVariable = "Initialization Required";

            //2. Multiple Initialization with different Data Type
            //We can not change the data type for a var keyword.It means if we assign the integer 
            //value at time of declaration then further we can assign string, double, 
            //or other data type value for var keyword. 
            //In case of dynamic type there are no such types of restrictions, 
            //we can assign different types of value for dynamic type variable.

            dynamic dynamicVariable2 = "Initialized as String";
            dynamicVariable2 = 5; //Then a number is Assigned

            //Error
            var varVariable= "Initialized as String";
            //varVariable = 5; //Then a number is Assigned

        }

        //3. Function Parameter

        //We can’t use the var keyword as a parameter for any function
        //but the dynamic type can be used as parameter for any function.

        public void DynamicFunction(dynamic num1, dynamic num2)
        {
            Console.WriteLine(num1 + num2);
        }

        //Error
        //public void VarFunction(var num1, var num2)
        //{
        //    Console.WriteLine(num1 + num2);
        //}


        //4. Return Type
        //We can’t create a method with var as return type 
        //but we can create a method whose return type is dynamic.

        public dynamic DynamicAdd(int num1, int num2)
        {
            return num1 + num2;
        }

        //Error
        //public void VarAdd(int num1, int num2)
        //{
        //    return num1 + num2;
        //}

    }
}

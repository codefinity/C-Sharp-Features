using System;

namespace OptionalArguments
{
    class Program
    {
        static void Main(string[] args)
        {
            //The definition of a method, constructor, indexer, or delegate can specify that its 
            //parameters are required or that they are optional. Any call must provide arguments 
            //for all required parameters, but can omit arguments for optional parameters.


            //Optional parameters are defined at the end of the parameter list, after any required 
            //parameters. If the caller provides an argument for any one of a succession of optional 
            //parameters, it must provide arguments for all preceding optional parameters. 
            //Comma-separated gaps in the argument list are not supported. For example, 
            //in the following code, instance method ExampleMethod is defined with one required
            //and two optional parameters.


            // Instance anExample does not send an argument for the constructor's
            // optional parameter.
            OptionalParamClass anExample = new OptionalParamClass();
            anExample.ExampleMethod(1, "One", 1);
            anExample.ExampleMethod(2, "Two");
            anExample.ExampleMethod(3);

            // Instance anotherExample sends an argument for the constructor's
            // optional parameter.
            OptionalParamClass anotherExample = new OptionalParamClass("Provided name");
            anotherExample.ExampleMethod(1, "One", 1);
            anotherExample.ExampleMethod(2, "Two");
            anotherExample.ExampleMethod(3);

            // The following statements produce compiler errors.

            // An argument must be supplied for the first parameter, and it
            // must be an integer.
            //anExample.ExampleMethod("One", 1);
            //anExample.ExampleMethod();

            // You cannot leave a gap in the provided arguments.
            //anExample.ExampleMethod(3, ,4);
            //anExample.ExampleMethod(3, 4);

            // You can use a named parameter to make the previous
            // statement work.
            anExample.ExampleMethod(3, optionalint: 4);



            // The output from this example is the following:
            // Default name: 1, One, and 1.
            // Default name: 2, Two, and 10.
            // Default name: 3, default string, and 10.
            // Provided name: 1, One, and 1.
            // Provided name: 2, Two, and 10.
            // Provided name: 3, default string, and 10.
            // Default name: 3, default string, and 4.
        }
    }
}

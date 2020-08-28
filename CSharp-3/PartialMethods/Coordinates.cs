using System;
using System.Collections.Generic;
using System.Text;

namespace PartialMethods
{
    internal partial class Coordinates
    {
        //A partial class or struct may contain a partial method.One part of the class contains the 
        //signature of the method.An optional implementation may be defined in the same part or another part.
        //If the implementation is not supplied, then the method and all calls to the method are removed at 
        //compile time.


        //Partial methods enable the implementer of one part of a class to define a method, 
        //similar to an event. The implementer of the other part of the class can decide whether to 
        //implement the method or not.If the method is not implemented, then the compiler removes the 
        //method signature and all calls to the method.The calls to the method, including any results that 
        //would occur from evaluation of arguments in the calls, have no effect at run time. 
        //Therefore, any code in the partial class can freely use a partial method, even if the 
        //implementation is not supplied.No compile-time or run-time errors will result if the method is 
        //called but not implemented.

        //* Partial methods can have in or ref but not out parameters.

        //* Partial methods are implicitly private, and therefore they cannot be virtual.

        //* Partial methods cannot be extern, because the presence of the body determines whether they are 
        //defining or implementing.

        //* Partial methods can have static and unsafe modifiers.

        //* Partial methods can be generic.Constraints are put on the defining partial method declaration, 
        //and may optionally be repeated on the implementing one.Parameter and type parameter names do not
        //have to be the same in the implementing declaration as in the defining one.

        //* You can make a delegate to a partial method that has been defined and implemented, 
        //but not to a partial method that has only been defined.

        //Important: Partial method declarations must begin with the contextual keyword partial 
        //and the method must return void.

        //Source: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods

        //Partial method must always return void.
        partial void StartTime(string message);

        partial void StopTime(string message);

        public void PlotCoordinates()
        {
            //Note that excluding Coordinates.logger.cs file will not effect the flow even if 
            //the methods in this are used here.
            //compiler will not comple these methods.

            StartTime("Plotting started");

            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Coordinates Plotted: {0},{1}", latitude, longitude);

            StopTime("Plotting done in");
        }
    }
}

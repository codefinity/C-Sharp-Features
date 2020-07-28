using System;

namespace InferredTupleElementNames
{
    class Program
    {
        static void Main(string[] args)
        {

            //Reference: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-1#inferred-tuple-element-names

            //Inferred tuple element names

            //This feature is a small enhancement to the tuples feature introduced in C# 7.0. 
            //Many times when you initialize a tuple, the variables used for the right side 
            //of the assignment are the same as the names you'd like for the tuple elements:

            int countPrevious = 5;
            string labelPrevious = "Colors used in the map";
            var pairPrevious = (count: countPrevious, label: labelPrevious);

            //The names of tuple elements can be inferred from the variables used to initialize the tuple in C# 7.1:
            
            int count = 5;
            string label = "Colors used in the map";
            var pair = (count, label); // element names are "count" and "label"
        }
    }
}

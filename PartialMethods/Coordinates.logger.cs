using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PartialMethods
{
    //Note that excluding this file will not effect the flow even if the methods in this are used in
    //another partial class.
    internal partial class Coordinates
    {
        private Stopwatch stopwatch;

        partial void StartTime(string message)
        {
            Console.WriteLine(message);

            stopwatch = Stopwatch.StartNew(); 
            
        }

        partial void StopTime(string message)
        {
            stopwatch.Stop();

            long timeTaken = stopwatch.ElapsedMilliseconds;

            Console.WriteLine(message);
            Console.WriteLine("Time Taken: " + timeTaken);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClasses
{
    internal partial class Coordinates
    {
        public void PlotCoordinates()
        {
            Console.WriteLine("Coordinates Plotted: {0},{1}", latitude, longitude);
        }
    }
}

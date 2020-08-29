using System;
using System.Collections.Generic;
using System.Text;

namespace PatternMatching
{
    public class Triangle
    {
        public double Base { get; }
        public double Height { get; }

        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }
    }
}

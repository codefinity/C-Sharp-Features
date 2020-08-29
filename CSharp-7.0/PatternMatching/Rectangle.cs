using System;
using System.Collections.Generic;
using System.Text;

namespace PatternMatching
{
    public struct Rectangle
    {
        public double Length { get; }
        public double Height { get; }

        public Rectangle(double length, double height)
        {
            Length = length;
            Height = height;
        }
    }
}

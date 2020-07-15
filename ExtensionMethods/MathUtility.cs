using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ExtensionMethods
{
    public class MathUtility
    {
        public int Add(params int[] numbers)
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                sum = sum + number;
            }

            return sum;
        }

        public int Multiply(params int[] numbers)
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                sum = sum * number;
            }

            return sum;
        }

        public int Subtract(int a, int b)
        {

            return a - b;
        }

        public int Divide(int a, int b)
        {

            return a / b;
        }


    }
}

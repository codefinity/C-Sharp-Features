using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods.Extensions
{
    internal static class MathUtilityExtensions
    {
        public static int Average(this MathUtility mathUtility, params int[] numbers)
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                sum = sum + number;
            }

            return sum / numbers.Length;
        }


    }
}

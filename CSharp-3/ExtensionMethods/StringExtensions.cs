using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods.Extensions
{
    internal static class StringExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}

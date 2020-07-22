using System;

namespace StringInterpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            //String interpolation provides a more readable and convenient syntax to 
            //create formatted strings than a string composite formatting feature. 
            //The following example uses both features to produce the same output:

            string name = "Mark";
            var date = DateTime.Now;

            // Composite formatting:
            Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);
            // String interpolation:
            Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
            // Both calls produce the same output that is similar to:
            // Hello, Mark! Today is Wednesday, it's 19:40 now.


            //Structure of an interpolated string

            //To identify a string literal as an interpolated string, prepend it with the $ symbol.
            //You cannot have any white space between the $ and the " that starts a string literal.

            //The structure of an item with an interpolation expression is as follows:

            //{< interpolationExpression >[,< alignment >][:< formatString >]}

            Console.WriteLine($"|{"Left",-7}|{"Right",7}|");

            const int FieldWidthRightAligned = 20;
            Console.WriteLine($"{Math.PI,FieldWidthRightAligned} - default formatting of the pi number");
            Console.WriteLine($"{Math.PI,FieldWidthRightAligned:F3} - display only three decimal digits of the pi number");


            // Expected output is:
            // |Left   |  Right|
            //     3.14159265358979 - default formatting of the pi number
            //                3.142 - display only three decimal digits of the pi number

            //The following example shows how to specify alignment and uses 
            //pipe characters ("|") to delimit text fields:
            const int NameAlignment = -9;
            const int ValueAlignment = 7;

            double a = 3;
            double b = 4;
            Console.WriteLine($"Three classical Pythagorean means of {a} and {b}:");
            Console.WriteLine($"|{"Arithmetic",NameAlignment}|{0.5 * (a + b),ValueAlignment:F3}|");
            Console.WriteLine($"|{"Geometric",NameAlignment}|{Math.Sqrt(a * b),ValueAlignment:F3}|");
            Console.WriteLine($"|{"Harmonic",NameAlignment}|{2 / (1 / a + 1 / b),ValueAlignment:F3}|");

            // Expected output:
            // Three classical Pythagorean means of 3 and 4:
            // |Arithmetic|  3.500|
            // |Geometric|  3.464|
            // |Harmonic |  3.429|


            //Special characters
            //To include a brace, "{" or "}", in the text produced by an interpolated string, use two braces, 
            //"{{" or "}}".For more information, see Escaping Braces.

            //As the colon(":") has special meaning in an interpolation expression item, 
            //in order to use a conditional operator in an interpolation expression, 
            //enclose that expression in parentheses.

            //The following example shows how to include a brace in a result string and 
            //how to use a conditional operator in an interpolation expression:

            string nameX = "Horace";
            int age = 34;
            Console.WriteLine($"He asked, \"Is your name {name}?\", but didn't wait for a reply :-{{");
            Console.WriteLine($"{nameX} is {age} year{(age == 1 ? "" : "s")} old.");
            // Expected output is:
            // He asked, "Is your name Horace?", but didn't wait for a reply :-{
            // Horace is 34 years old.





        }
    }
}

using System;

namespace ExpressionBodiedFunctionMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("FN","LN");

            Console.WriteLine(student.FullName);

            Console.WriteLine(student.ToString());
        }
    }
}

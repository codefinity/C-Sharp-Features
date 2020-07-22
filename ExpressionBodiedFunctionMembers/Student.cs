using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionBodiedFunctionMembers
{
    internal class Student
    {
        //Many members that you write are single statements that could be single expressions.
        //Write an expression-bodied member instead.It works for methods and read-only properties.For example, an override of ToString() is often a great candidate:
        public override string ToString() => $"{LastName}, {FirstName}";

        //You can also use this syntax for read-only properties:
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<double> Grades { get; } = new List<double>();

        public string Addess { get; set; } = "Address";

        public string FirstName { get; }
        public string LastName { get; }

        public Student(string firstName, string lastName)
        {
            if (IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(message: "Cannot be blank", paramName: nameof(lastName));
            FirstName = firstName;
            LastName = lastName;
        }

        public bool IsNullOrWhiteSpace(string str)
        {
            if (str == null || str == "")
            {
                return true;

            }

            return false;
        }


    }
}

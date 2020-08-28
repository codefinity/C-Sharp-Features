using System;
using System.Collections.Generic;
using System.Text;

namespace NameOfExpression
{
    internal class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student(string firstName, string lastName)
        {
            if (IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(message: "Cannot be blank", paramName: nameof(lastName));
            FirstName = firstName;
            LastName = lastName;
        }


        public void ChangeName(string newLastName)
        {

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

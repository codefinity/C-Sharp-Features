using System;
using System.Collections.Generic;
using System.Text;

namespace ReadOnlyAutoProperties
{
    internal class Student
    {
        //Read-only auto-properties provide a more concise syntax to create immutable types. 
        //You declare the auto-property with only a get accessor:
        public string FirstName { get; }
        public string LastName { get; }

        //The FirstName and LastName properties can be set only in the body of the constructor of the same class
        public Student(string firstName, string lastName)
        {
            if (IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(message: "Cannot be blank", paramName: nameof(lastName));
            FirstName = firstName;
            LastName = lastName;
        }

        //Cannot be changed once assigned in the constructor
        public void ChangeName(string newLastName)
        {
            // Generates CS0200: Property or indexer cannot be assigned to -- it is read only
            //Error
            //LastName = newLastName;
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

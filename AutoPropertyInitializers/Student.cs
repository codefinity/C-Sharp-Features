using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPropertyInitializers
{
    internal class Student
    {
        //Auto-property initializers let you declare the initial value for an 
        //auto-property as part of the property declaration.

        //The Grades member is initialized where it's declared. That makes it easier to perform the 
        //initialization exactly once. The initialization is part of the property declaration, 
        //making it easier to equate the storage allocation with the public interface for Student objects.
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

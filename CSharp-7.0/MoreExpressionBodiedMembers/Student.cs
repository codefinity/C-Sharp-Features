using System;
using System.Collections.Generic;
using System.Text;

namespace MoreExpressionBodiedMembers
{
    public class Student
    {

        private string name;
        private string grade;
        private int age;
        

        //Constructors
        //An expression body definition for a constructor typically consists of a single assignment 
        //expression or a method call that handles the constructor's arguments or initializes instance state.

        //The following example defines a Location class whose constructor has a single string parameter 
        //named name.
        public Student() => name = "Harry";

        public Student(string studentName) => name = studentName;

        //public Student() => (name, age) = ("Harry", 20);

        public Student(string studentName, int studentAge) => (name, age) = (studentName, studentAge);


        //Methods
        //An expression-bodied method consists of a single expression that returns a value whose type 
        //matches the method's return type, or, for methods that return void, that performs some operation. 
        //For example, types that override the ToString method typically include a single expression that 
        //returns the string representation of the current object.
        //Note that the return keyword is not used in the ToString expression body definition.
        public override string ToString() => $"{name} {grade}".Trim();
        public void DisplayName() => Console.WriteLine(ToString());

        public double AgeInMonths() => (age * 12);

        public double Percentage(int totalMarks, int totalSubjects) => totalMarks / totalSubjects;

        //Read-only properties
        //Starting with C# 6, you can use expression body definition to implement a read-only property. 
        //To do that, use the following syntax:

        private string locationName;

        //The following example defines a Location class whose read-only Name property is implemented 
        //as an expression body definition that returns the value of the private locationName field:
        public string Name => locationName;

        //Properties
        //Starting with C# 7.0, you can use expression body definitions to implement property get and set 
        //accessors. The following example demonstrates how to do that:
        public string NameX
        {
            get => locationName;
            set => locationName = value;
        }


        //Destructors
        //Finalizers
        //An expression body definition for a finalizer typically contains cleanup statements, 
        //such as statements that release unmanaged resources.

        //The following example defines a finalizer that uses an expression body definition to 
        //indicate that the finalizer has been called.
        ~Student() => Console.WriteLine("\nDistructor Called");



        //Indexers
        //Like with properties, indexer get and set accessors consist of expression body definitions 
        //if the get accessor consists of a single expression that returns a value or the set accessor 
        //performs a simple assignment.

        //The following example defines a class named Sports that includes an internal String array that 
        //contains the names of a number of sports.Both the indexer get and set accessors are implemented 
        //as expression body definitions.

        private string[] types = { "Baseball", "Basketball", "Football",
                                      "Hockey", "Soccer", "Tennis",
                                      "Volleyball" };

        public string this[int i]
        {
            get => types[i];
            set => types[i] = value;
        }

    }
}

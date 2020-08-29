using System;

namespace OutVariableImprovement
{
    class Program
    {
        static void Main(string[] args)
        {
            //The existing syntax that supports out parameters has been improved in this version. 
            //You can now declare out variables in the argument list of a method call, rather than 
            //writing a separate declaration statement.


            //Reference: https://www.c-sharpcorner.com/article/out-variables-in-c-sharp-7-0/

            //Old Method
            //C# out parameter. Prior to C# 7.0, the out keyword was used to pass a method argument's reference. 
            //Before a variable is passed as an out argument, it must be declared. 
            string authorNameOldOut;
            string bookTitleOldOut;
            long publishedYearOldOut;

            GetStudentOldOut(out authorNameOldOut, out bookTitleOldOut, out publishedYearOldOut);

            Console.WriteLine("Author: {0}, Book: {1}, Year: {2}", authorNameOldOut, bookTitleOldOut, publishedYearOldOut);


            //New Method
            //Now, you can define a method's out parameters directly in the method. 
            GetStudentNewOut(out string authorName, out string bookTitle, out long publishedYear);
            
            Console.WriteLine("Author: {0}, Book: {1}, Year: {2}", authorName, bookTitle, publishedYear);

        }


        static void GetStudentOldOut(out string name, out string title, out long dateOfBirth)
        {
            name = "Sam";
            title = "Mr.";
            dateOfBirth = 2001;
        }

        static void GetStudentNewOut(out string name, out string title, out long dateOfBirth)
        {
            name = "Jenny";
            title = "Ms.";
            dateOfBirth = 2001;
        }
    }
}

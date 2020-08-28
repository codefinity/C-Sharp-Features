using System;

namespace NameOfExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            //nameof accepts the name of code element and returns a string literal of the same element.  
            //The nameof operator can take as a parameter like class name and its all members like method, 
            //variables, properties and return the string literal.  This avoids having hardcoded strings 
            //to be specified in our code as well as avoid explicitly use of reflection to get the names.
            //References:   https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6
            //              https://dailydotnettips.com/using-nameof-operator-in-c-6-0/

            Student student = new Student("FN", "LN");

            Console.WriteLine(nameof(student));
            Console.WriteLine(nameof(student.FirstName));
            Console.WriteLine(nameof(student.LastName));
            Console.WriteLine(nameof(student.ChangeName));


            var @new = 5;
            Console.WriteLine(nameof(@new)); // output: new


            //The nameof expression evaluates to the name of a symbol. It's a great way to get tools working 
            //whenever you need the name of a variable, a property, or a member field. 
            //One of the most common uses for nameof is to provide the name of a symbol that caused an exception:
            if (IsNullOrWhiteSpace(student.FirstName))
                throw new ArgumentException(message: "Cannot be blank", paramName: nameof(student.FirstName));


            //Another use is with XAML - based applications that implement the INotifyPropertyChanged interface:


            //public string LastName
            //        {
            //            get { return lastName; }
            //            set
            //            {
            //                if (value != lastName)
            //                {
            //                    lastName = value;
            //                    PropertyChanged?.Invoke(this,
            //                        new PropertyChangedEventArgs(nameof(LastName)));
            //                }
            //            }
            //        }
            //        private string lastName;



        }

        public static bool IsNullOrWhiteSpace(string str)
        {
            if (str == null || str == "")
            {
                return true;

            }

            return false;
        }
    }
}

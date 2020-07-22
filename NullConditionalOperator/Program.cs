using System;

namespace NullConditionalOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            //References:    https://www.informit.com/articles/article.aspx?p=2421572
            //              https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6


            //In the example, the variable first is assigned null if the person object is null.
            //Otherwise, it is assigned the value of the FirstName property.Most importantly, 
            //the ?. means that this line of code doesn't generate a NullReferenceException if the 
            //person variable is null. Instead, it short-circuits and returns null. 

            Person person = new Person() { FirstName = "FN", LastName = "LN", Age = 22 };

            var name = person?.FirstName;
            var age = person?.Age;

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);

            var firstName = person?.FirstName ?? "Unspecified";
            Console.WriteLine("First Name: " + firstName);

            var fullName = person?.GetFullName();

            Console.WriteLine("Full Name: " + fullName);

            //=====With Null=====

            person = null;

            var name1 = person?.FirstName;
            var age1 = person?.Age;

            Console.WriteLine("Name: " + name1);
            Console.WriteLine("Age: " + age1);

            //The following expression returns a string, regardless of the value of person.
            //You often use this construct with the null coalescing operator to assign default 
            //values when one of the properties is null.When the expression short-circuits, 
            //the null value returned is typed to match the full expression.

            var firstName1 = person?.FirstName ?? "Unspecified";
            Console.WriteLine("First Name: " + firstName1);

            //You can also use ?. to conditionally invoke methods. 
            //The most common use of member functions with the null conditional 
            //operator is to safely invoke delegates (or event handlers) that may be null. 
            //You'll call the delegate's Invoke method using the ?. operator to access the member

            var fullName1 = person?.GetFullName();

            Console.WriteLine("Full Name: " + fullName1);


            Person[] personArray =  { new Person { FirstName = "FN1", LastName = "LN1", Age = 22 },
                                        new Person { FirstName = "FN2", LastName = "LN1", Age = 22 },
                                        new Person { FirstName = "FN3", LastName = "LN1", Age = 22 },
                                        null,
                                        new Person { FirstName = "FN5", LastName = "LN1", Age = 22 },
                                        new Person { FirstName = "FN6", LastName = "LN1", Age = 22 }};

            var secondPersonName = personArray[1].FirstName;

            Console.WriteLine("First Person Name: " + secondPersonName);

            var forthPersonName = personArray?[3]?.FirstName;

            Console.WriteLine("Fourth Person Name: " + forthPersonName);


            //The ?[] syntax has the same semantics as the ?. operator: 
            //It's how you access the indexer on an array, or a class that implements an indexer. 
            //The rules for its behavior are the same. If people is null, thisName is assigned the value null.
            //If people[3] is null, thisName is assigned the value null. Otherwise, thisName is assigned the 
            //value of people[3].FirstName. However, if people is not null, but has fewer than four elements, 
            //accessing people[3] will still throw an OutOfRangeException.

            Person[] personArray1 = null;

            var fifthPersonName = personArray1?[3]?.FirstName;

            Console.WriteLine("Fourth Person Name: " + fifthPersonName);


        }
    }
}

using System;
using System.Collections.Generic;

namespace ObjectAndCollectionInitializers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Object initializers let you assign values to any accessible fields or properties of 
            //an object at creation time without having to invoke a constructor followed by lines 
            //of assignment statements. 
            //The object initializer syntax enables you to specify 
            //arguments for a constructor or omit the arguments(and parentheses syntax)

            Cat cat = new Cat { Age = 10, Name = "Fluffy" };
            Cat sameCat = new Cat("Fluffy") { Age = 10 };

            //Starting with C# 6, object initializers can set indexers, in addition to assigning fields and properties. 
            //Consider this basic Matrix class:
            var identity = new Matrix
            {
                [0, 0] = 1.0,
                [0, 1] = 0.0,
                [0, 2] = 0.0,

                [1, 0] = 0.0,
                [1, 1] = 1.0,
                [1, 2] = 0.0,

                [2, 0] = 0.0,
                [2, 1] = 0.0,
                [2, 2] = 1.0,
            };

            //Collection initializers
            List<int> digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> digits2 = new List<int> { 0 + 1, 12 % 3, MakeInt() };

            List<Cat> cats = new List<Cat>
            {
                new Cat{ Name = "Sylvester", Age=8 },
                new Cat{ Name = "Whiskers", Age=2 },
                new Cat{ Name = "Sasha", Age=14 }
            };

            //You can specify null as an element in a collection initializer if the collection's Add method allows it.

            List<Cat> moreCats = new List<Cat>
                {
                    new Cat{ Name = "Furrytail", Age=5 },
                    new Cat{ Name = "Peaches", Age=4 },
                    null
                };

            //You can specify indexed elements if the collection supports read / write indexing.
            var numbers = new Dictionary<int, string>
            {
                [7] = "seven",
                [9] = "nine",
                [13] = "thirteen"
            };


            //The preceding sample generates code that calls the Item[TKey] to set the values. 
            //Before C# 6, you could initialize dictionaries and other associative containers using 
            //the following syntax. Notice that instead of indexer syntax, with parentheses and an assignment, 
            //it uses an object with multiple values:

            var moreNumbers = new Dictionary<int, string>
                {
                    {19, "nineteen" },
                    {23, "twenty-three" },
                    {42, "forty-two" }
                };

        }

        public static int MakeInt()
        {
            return 10;
        }

    }
}

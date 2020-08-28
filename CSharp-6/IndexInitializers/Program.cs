using System;
using System.Collections.Generic;

namespace IndexInitializers
{
    class Program
    {
        static void Main(string[] args)
        {


            //Index Initializers is one of two features that make collection initializers 
            //more consistent with index usage.In earlier releases of C#, 
            //you could use collection initializers with sequence style collections, 
            //including Dictionary<TKey,TValue>, by adding braces around key and value pairs:


            Dictionary<int, string> messages = new Dictionary<int, string>
                                                    {
                                                        { 404, "Page not Found"},
                                                        { 302, "Page moved, but left a forwarding address."},
                                                        { 500, "The web server can't come out to play today."}
                                                    };
            //You can use them with Dictionary<TKey, TValue> collections and other types 
            //where the accessible Add method accepts more than one argument. 
            //The new syntax supports assignment using an index into the collection:


            Dictionary<int, string> webErrors = new Dictionary<int, string>
                                                        {
                                                            [404] = "Page not Found",
                                                            [302] = "Page moved, but left a forwarding address.",
                                                            [500] = "The web server can't come out to play today."
                                                        };
            //This feature means that associative containers can be initialized using syntax similar to 
            //what's been in place for sequence containers for several versions.


        }
    }
}

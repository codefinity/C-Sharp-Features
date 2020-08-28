using System;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //C# has a language-level asynchronous programming model, which allows for 
            //easily writing asynchronous code, without having to juggle callbacks or 
            //conform to a library that supports asynchrony. It follows what is known 
            //as the Task-based Asynchronous Pattern (TAP).
            //Reference: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/task-asynchronous-programming-model

            WebAccess webAccess = new WebAccess();

            Task<int> contentLength = webAccess.AccessTheWebAsync();

            Console.WriteLine("Content Length: " + contentLength.Result);


            //Further References
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/how-to-extend-the-async-walkthrough-by-using-task-whenall
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/how-to-make-multiple-web-requests-in-parallel-by-using-async-and-await
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/async-return-types

            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/handling-reentrancy-in-async-apps
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/using-async-for-file-access
            //https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap
            //Videos
            //https://channel9.msdn.com/search?term=async%20&lang-en=true
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/control-flow-in-async-programs


        }
    }
}

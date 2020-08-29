using System;
using System.Threading.Tasks;

namespace AsyncMainMethod
{
    class Program
    {
        //References:   https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-1#async-main
        //              https://www.stefangeiger.ch/2018/07/16/dotnet-core-async-main.html

        //async main method enables you to use await in your Main method. 


        //If the code does not return a value
        static async Task Main(string[] args)
        {
            var helloWorld = await GetHelloWorldAsync();
            Console.WriteLine(helloWorld);
        }

        //If the code returns a value
        //static async Task<string> Main(string[] args)
        //{
        //    var helloWorld = await GetHelloWorldAsync();
        //    return helloWorld;
        //}

        static Task<string> GetHelloWorldAsync()
        {
            return Task.FromResult("Hello Async World");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace CallerInfoAttributes
{
    internal class MessageLogger
    {
        public void LogMessage(string message,
                                [CallerMemberName] string memberName = "",
                                [CallerFilePath] string sourceFilePath = "",
                                [CallerLineNumber] int sourceLineNumber = 0)
        {
            //Accessing the information of the function that calls this method.

            Console.WriteLine("message: " + message);
            Console.WriteLine("member name: " + memberName);
            Console.WriteLine("source file path: " + sourceFilePath);
            Console.WriteLine("source line number: " + sourceLineNumber);
        }
    }
}

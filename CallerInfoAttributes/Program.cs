using System;

namespace CallerInfoAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            InfoProcesser infoProcesser = new InfoProcesser();

            infoProcesser.ProcessInfo();

            Console.ReadLine();
        }
    }
}

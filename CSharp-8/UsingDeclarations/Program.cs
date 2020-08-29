using System;
using System.Collections;
using System.Collections.Generic;

namespace UsingDeclarations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IEnumerable<string> listOfString = new List<string> {"One","Two", "Thee",
                                                                    "Four"," ", "Five", 
                                                                    "Six", "Seven","Eight", 
                                                                    "Nine" ,"Ten", " "};

            //New

            FileWriterUsing fileWriterUsing = new FileWriterUsing();
            fileWriterUsing.WriteLinesToFile(listOfString);


            //Previous

            FileWriterUsingPrev fileWriterUsingPrev = new FileWriterUsingPrev();
            fileWriterUsingPrev.WriteLinesToFile(listOfString);

            Console.ReadLine();
        }
    }
}

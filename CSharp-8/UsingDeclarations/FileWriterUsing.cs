using System;
using System.Collections.Generic;
using System.Text;

namespace UsingDeclarations
{
    internal class FileWriterUsing
    {
        public int WriteLinesToFile(IEnumerable<string> lines)
        {
            //-> A using declaration is a variable declaration preceded by the using keyword. 
            //-> It tells the compiler that the variable being declared should be disposed at the end of 
            //-> the enclosing scope.
            using var fileWriter = new FileWriter("WriteLinesUsing.txt");

            // Notice how we declare skippedLines after the using statement.
            int skippedLines = 0;

            skippedLines = fileWriter.WriteToFile(lines);

            // Notice how skippedLines is in scope here.
            return skippedLines;
            //-> fileWriter is disposed here

            //-> In both cases, the compiler generates the call to Dispose(). 
            //-> The compiler generates an error if the expression in the using 
            //-> statement isn't disposable.
        }

    }
}

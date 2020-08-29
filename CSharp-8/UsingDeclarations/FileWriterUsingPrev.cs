using System;
using System.Collections.Generic;
using System.Text;

namespace UsingDeclarations
{
    internal class FileWriterUsingPrev
    {
        public int WriteLinesToFile(IEnumerable<string> lines)
        {
            // We must declare the variable outside of the using block
            // so that it is in scope to be returned.
            int skippedLines = 0;
            using (var fileWriter = new FileWriter("WriteLinesUsingPrev.txt"))
            { 

                skippedLines = fileWriter.WriteToFile(lines);
            } //-> fileWriter is disposed here

            return skippedLines;
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UsingDeclarations
{
    internal class FileWriter : IDisposable
    {
        private readonly string filePath="";
        public FileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public int WriteToFile(IEnumerable<string> lines)
        {
            using var file = new StreamWriter(filePath);
            // Notice how we declare skippedLines after the using statement.
            int skippedLines = 0;
            foreach (string line in lines)
            {
                if (!line.Contains(" "))
                {
                    file.WriteLine(line);
                }
                else
                {
                    skippedLines++;
                }
            }
            // Notice how skippedLines is in scope here.
            return skippedLines;
            //-> file is disposed here

        }

        public void Dispose()
        {
            Console.WriteLine("IDisposable Has Run.....");
        }

    }
}

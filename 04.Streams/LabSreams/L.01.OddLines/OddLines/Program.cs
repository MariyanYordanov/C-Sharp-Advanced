using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {

            string inputFile = @"input.txt";
            string outputFile = @"..\..\..\output.txt";
            ExtractOddLines(inputFile, outputFile);
        }
        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader str = new StreamReader(inputFilePath);
            using StreamWriter sw = new StreamWriter(outputFilePath);

            int lineCounter = 0;
            string line = str.ReadLine();
            while (line != null)
            {
                if (lineCounter % 2 != 0)
                {
                    sw.WriteLine(line);
                }
                lineCounter++;
                line = str.ReadLine();
            }
        }
    }
}

namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);
            using StreamWriter writer = new StreamWriter(outputFilePath);
            int counter = 1;
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                int letterCount = 0;
                int punctuationCount = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (Char.IsLetter(line[i]))
                    {
                        letterCount++;
                    }
                    else if (Char.IsPunctuation(line[i]))
                    {
                        punctuationCount++;
                    }
                }
                writer.WriteLine($"Line{counter}: {line} ({letterCount})({punctuationCount})");
                counter++;
            }
            
        }
    }
}

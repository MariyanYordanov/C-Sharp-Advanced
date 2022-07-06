using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            string firstInputFilePath = @"..\..\..\input1.txt";
            string secondInputFilePath = @"..\..\..\input2.txt";
            string outputFilePath = @"..\..\..\output.txt";
            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }
        public static void MergeTextFiles(string firstInputFilePath, string
        secondInputFilePath, string outputFilePath)
        {
            using StreamReader readerFirst = new StreamReader(firstInputFilePath);
            using StreamReader readerSecond = new StreamReader(secondInputFilePath);
            using StreamWriter writer = new StreamWriter(outputFilePath);
            string first = readerFirst.ReadLine();
            string second = readerSecond.ReadLine();
            while (first != null)
            {
                writer.WriteLine($"{first}\n{second}");
                first = readerFirst.ReadLine();
                second = readerSecond.ReadLine();
            }

        }
    }
}

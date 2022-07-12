using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string bytesFilePath = @"..\..\..\bytes.txt";
            string binaryFilePath = @"..\..\..\example.png";
            string outputPath = @"..\..\..\output.bin";
            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using StreamReader readBytes = new StreamReader(bytesFilePath);
            byte[] byteArray = File.ReadAllBytes(binaryFilePath);
            List<string> byteList = new List<string>();
            StringBuilder sb = new StringBuilder();
            while (!readBytes.EndOfStream)
            {
                byteList.Add(readBytes.ReadLine());
            }

            foreach (var element in byteArray)
            {
                if (byteList.Contains(element.ToString()))
                {
                    sb.AppendLine(element.ToString());
                }
            }

            using StreamWriter streamWriter = new StreamWriter(outputPath);
            streamWriter.WriteLine(sb.ToString().Trim());
        }
    }
}

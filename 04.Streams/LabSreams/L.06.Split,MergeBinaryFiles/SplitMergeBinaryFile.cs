using System;
using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\example.png";
            string partOneFilePath = @"..\..\..\part-1.bin";
            string partTwoFilePath = @"..\..\..\part-2.bin";
            string joinedFilePath = @"..\..\..\example-joined.png";
            SplitBinaryFile(sourceFilePath,partOneFilePath,partTwoFilePath);
            MergeBinaryFiles(partOneFilePath,partTwoFilePath,joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string
        partOneFilePath, string partTwoFilePath)
        {
            using FileStream stream = new FileStream(sourceFilePath,FileMode.Open);
            using FileStream firstFile = new FileStream(partOneFilePath, FileMode.Create);
            long lenghtStream = (long)stream.Length;
            byte[] data = new byte[0];
            if (lenghtStream % 2 == 1)
            {
                data = new byte[lenghtStream / 2 + 1];
            }
            else
            {
                data = new byte[lenghtStream / 2];
            }

            stream.Read(data, 0, data.Length);
            firstFile.Write(data, 0, data.Length);
            long pointer = stream.Position;
            byte[] data2 = new byte[lenghtStream - pointer];
            using FileStream secondFile = new FileStream(partTwoFilePath, FileMode.Create);
            stream.Read(data2, 0, data2.Length);
            secondFile.Write(data2, 0, data2.Length);

        }
        public static void MergeBinaryFiles(string partOneFilePath, string
        partTwoFilePath, string joinedFilePath)
        {
            using FileStream stream1 = new FileStream(partOneFilePath, FileMode.Open);
            using FileStream stream2 = new FileStream(partTwoFilePath, FileMode.Open);
            using FileStream fileStream = new FileStream(joinedFilePath,FileMode.Create);
            byte[] data = new byte[stream1.Length + stream2.Length];
            byte[] data1 = new byte[stream1.Length];
            byte[] data2 = new byte[stream2.Length];
            stream1.Read(data1, 0, data1.Length);
            stream2.Read(data2, 0, data2.Length);
            fileStream.Write(data1, 0, data1.Length);
            fileStream.Write(data2, 0, data2.Length);
        }
    }
}

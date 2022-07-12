using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            FileStream streamReader = new FileStream(inputFilePath, FileMode.Open);
            FileStream streamWriter = new FileStream(outputFilePath, FileMode.Create);
            byte[] bytes = new byte[256];
            while (true)
            {
                int currentBytes = streamReader.Read(bytes, 0, bytes.Length);
                if (currentBytes == 0)
                {
                    break;
                }

                streamWriter.Write(bytes, 0, bytes.Length);
            }
        }
    }
}

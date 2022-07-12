﻿namespace FolderSize
{
    using System;
    using System.IO;

    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\TestFolder";
            string outputFilePath = @"..\..\..\output.txt";
            GetFolderSize(folderPath, outputFilePath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double sum = 0;
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] infos = dir.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo fileInfo in infos)
            {
                sum += fileInfo.Length;
            }

            sum = sum/1024;
            File.WriteAllText(outputFilePath, sum.ToString() + " KB");
        }
    }
}

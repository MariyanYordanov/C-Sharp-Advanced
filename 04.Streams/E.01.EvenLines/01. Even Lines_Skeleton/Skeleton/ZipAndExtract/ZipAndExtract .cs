﻿namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main(string[] args)
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using ZipArchive zipFile = ZipFile.Open(inputFilePath, ZipArchiveMode.Create);
            zipFile.CreateEntryFromFile(inputFilePath, zipArchiveFilePath);
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using ZipArchive zip = ZipFile.OpenRead(zipArchiveFilePath);
            var currentZip = zip.CreateEntry(fileName);
            currentZip.ExtractToFile(outputFilePath);
        }
    }
}

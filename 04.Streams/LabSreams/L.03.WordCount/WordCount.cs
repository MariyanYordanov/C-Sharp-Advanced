using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordsFilePath = @"..\..\..\words.txt";
            string textFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";
            CalculateWordCounts(wordsFilePath, textFilePath, outputFilePath);
        }
        public static void CalculateWordCounts(string wordsFilePath, string
        textFilePath, string outputFilePath)
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            using StreamReader wordsReader = new StreamReader(wordsFilePath);
            using StreamReader textReader = new StreamReader(textFilePath);
            using StreamWriter writer = new StreamWriter(outputFilePath);
            string text = File.ReadAllText(textFilePath).ToLower();
            string[] wordToFind = wordsReader.ReadLine().Split();
            foreach (var word in wordToFind)
            {
                string pattern = $"(?<=[^a-zA-Z]){word}(?=[^a-zA-Z])";
                Regex reg = new Regex(pattern);
                MatchCollection matchCollection = reg.Matches(text);
                int counter = 1;
                foreach (Match match in matchCollection)
                {
                    if (!list.ContainsKey(match.Value))
                    {
                        list.Add(match.Value, counter);
                    }
                    else
                    {
                        list[match.Value] += counter;
                    }
                }
            }

            var ordered = list.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            foreach (var item in ordered)
            {
                writer.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}

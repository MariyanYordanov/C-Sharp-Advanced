using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static void CalculateWordCounts(string wordsFilePath, string
        textFilePath, string outputFilePath)
        {
            Dictionary<string, int> orderedWords = new Dictionary<string, int>();
            using (StreamReader wordsReader = new StreamReader(wordsFilePath))
            {
                using (StreamReader textReader = new StreamReader(textFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        int counter = 1;
                        string[] wordToFind = wordsReader.ReadLine().Split();
                        for (int i = 0; i < wordToFind.Length; i++)
                        {
                            string text = File.ReadAllText(textFilePath).ToLower();
                            string[] textToFind = text.Split().ToArray();
                            counter = 1;
                            for (int j = 0; j < textToFind.Length; j++)
                            {
                                if (wordToFind[i] == textToFind[j])
                                {
                                    if (!orderedWords.ContainsKey(wordToFind[i]))
                                    {
                                        orderedWords.Add(wordToFind[i], counter);
                                    }
                                    else if(orderedWords.ContainsKey(wordToFind[i]))
                                    {
                                        orderedWords[wordToFind[i]] = counter;
                                    }
                                    
                                    counter++;
                                }
                            }

                        }

                        orderedWords = orderedWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
                        foreach (var item in orderedWords)
                        {
                            writer.WriteLine($"{item.Key} - {item.Value}");
                        }

                    }
                }
            }
        }
    }
}

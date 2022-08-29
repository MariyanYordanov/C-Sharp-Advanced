using System;
using System.Collections.Generic;
using System.Text;

namespace FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] vowelsArr = Console.ReadLine().ToCharArray();
            Queue<char> vowels = new Queue<char>();
            foreach (var vowel in vowelsArr)
            {
                if (vowel != ' ')
                {
                    vowels.Enqueue(vowel);
                }
            }

            char[] consonantsArr = Console.ReadLine().ToCharArray();
            Stack<char> consonants = new Stack<char>();
            foreach (var consonant in consonantsArr)
            {
                if (consonant != ' ')
                {
                    consonants.Push(consonant);
                }
            }

            //char[] pear = new char[]{ 'p', 'e', 'a', 'r' };
            //char[] flour = new char[]{ 'f', 'l', 'o', 'u', 'r' };
            //char[] pork = new char[]{ 'p', 'o', 'r', 'k' };
            //char[] olive = new char[]{ 'o', 'l', 'i', 'v', 'e' };
            string[] words = new string[] { "pear", "flour", "pork", "olive" };
            //List<char[]> words = new List<char[]>() { pear, flour, pork, olive };
            List<char[]> findedWords = new List<char[]>();
            while (consonants.Count > 0)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Contains(vowels.Peek()))
                    {
                        List<char> vs = new List<char>();
                        vs.Add(vowels.Peek());
                    }
                }

                vowels.Enqueue(vowels.Dequeue());
                consonants.Pop();
            }

            foreach (var word in words)
            {
                if (word != null)
                {
                    findedWords.Remove(word);
                }
                
            }

            Console.WriteLine($"Words found: {findedWords.Count}");
            Console.WriteLine(string.Join("\n", findedWords));
        }
    }
}



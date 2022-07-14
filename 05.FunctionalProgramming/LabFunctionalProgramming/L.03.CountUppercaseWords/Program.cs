using System;
using System.Linq;

namespace L._03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] text = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Where(x => Char.IsUpper(x[0])).ToArray();
            //Console.WriteLine(string.Join("\n", text));
            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int i = 0; i < text.Length; i++)
            {
                Func<string, bool> func = IsUpper;
                if (func.Invoke(text[i]))
                {
                    Console.WriteLine(text[i]);
                }
                
            }
            
        }

        static bool IsUpper(string word)
        {
            return Char.IsUpper(word[0]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace E._05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charDic = new Dictionary<char, int>();
            char[] input = Console.ReadLine().ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (!charDic.ContainsKey(input[i]))
                {
                    charDic.Add(input[i],0);
                }

                charDic[input[i]]++;
            }

            charDic = charDic.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var item in charDic)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}

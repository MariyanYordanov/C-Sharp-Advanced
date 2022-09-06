using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackSmith
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> steel = new Queue<int>(Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> carbon = new Stack<int>(Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<int, string> swordsToFind = new Dictionary<int, string>()
            {
                { 70, "Gladius" },
                { 80, "Shamshir" },
                { 90, "Katana" },
                { 110, "Sabre" },
                { 150, "Broadsword" },
            };

            Dictionary<string, int> forgedSwords = new Dictionary<string, int>();

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int sum = steel.Peek() + carbon.Peek();
                if (swordsToFind.ContainsKey(sum))
                {
                    if (!forgedSwords.ContainsKey(swordsToFind[sum]))
                    {
                        forgedSwords.Add(swordsToFind[sum], 1);
                        steel.Dequeue();
                        carbon.Pop();
                    }
                    else if (forgedSwords.ContainsKey(swordsToFind[sum]))
                    {
                        forgedSwords[swordsToFind[sum]] += 1;
                        steel.Dequeue();
                        carbon.Pop();
                    }
                    
                }
                else
                {
                    steel.Dequeue();
                    int newValue = 5 + carbon.Pop();
                    carbon.Push(newValue);
                }
            }

            
            if (forgedSwords.Count > 0)
            {
                Console.WriteLine($"You have forged {forgedSwords.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ",steel)}"); 
            }

            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }

            foreach (var sword in forgedSwords.OrderBy(x => x.Key))
            {
                if (sword.Value > 0)
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}

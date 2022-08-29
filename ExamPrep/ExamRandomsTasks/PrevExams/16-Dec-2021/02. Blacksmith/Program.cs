using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] queue = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] stack = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> steel = new Queue<int>(queue);
            Stack<int> carbon = new Stack<int>(stack);
            Dictionary<int, string> swords = new Dictionary<int, string>()
            {
                { 70,"Gladius"},
                { 80,"Shamshir"},
                { 90,"Katana"},
                { 110,"Sabre"},
                { 150,"Broadsword"},
            };

            Dictionary<string,int> forgedSwords = new Dictionary<string, int>();
            bool hasSteel = true;
            bool hasCarbon = true;
            while (true)
            {
                if (steel.Count() == 0)
                {
                    hasSteel = false;
                    break;
                }

                if (carbon.Count() == 0)
                {
                    hasCarbon = false;
                    break;
                }

                int sum = steel.Peek() + carbon.Peek();
                if (swords.ContainsKey(sum))
                {
                    steel.Dequeue();
                    carbon.Pop();
                    if (!forgedSwords.ContainsKey(swords[sum]))
                    {
                        forgedSwords.Add(swords[sum], 1);
                    }
                    else
                    {
                        forgedSwords[swords[sum]]++;
                    }
                }
                else
                {
                    steel.Dequeue();
                    int newValue = carbon.Pop() + 5;
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

            if (hasSteel)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (hasCarbon)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var sword in forgedSwords.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}

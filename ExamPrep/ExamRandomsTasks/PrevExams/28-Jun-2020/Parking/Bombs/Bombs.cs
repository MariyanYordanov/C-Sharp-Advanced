using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            int[] effectsInput= Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] casingsInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> effects = new Queue<int>(effectsInput);

            Stack<int> casings = new Stack<int>(casingsInput);

            Dictionary<int, string> bombs = new Dictionary<int, string>() 
            {
                {40,"Datura Bombs"},
                {60,"Cherry Bombs"},
                {120,"Smoke Decoy Bombs"}
            };

            Dictionary<string, int> pouch = new Dictionary<string, int>()
            {
                {"Datura Bombs",0},
                {"Cherry Bombs",0},
                {"Smoke Decoy Bombs",0}
            };

            bool isFillPouch = false;
            while (effects.Count > 0 && casings.Count > 0)
            {
                int sum = effects.Peek() + casings.Peek();
                if (bombs.ContainsKey(sum))
                {
                    effects.Dequeue();
                    casings.Pop();
                    pouch[bombs[sum]] += 1;
                }
                else
                {
                    int newValue = casings.Pop() - 5;
                    casings.Push(newValue);
                }

                if (pouch.All(x => x.Value >= 3))
                {
                    isFillPouch = true;
                    break;
                }
            }

            if (isFillPouch)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",effects)}");
            }

            if (casings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ",casings)}");
            }

            foreach (var bomb in pouch.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] queueBasket = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] stackBasket = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> ingredient = new Queue<int>(queueBasket);
            Stack<int> freshness = new Stack<int>(stackBasket);
            Dictionary<int, string> dishes = new Dictionary<int, string>()
            {
                {150, "Dipping sauce"},
                {250,"Green salad"},
                {300, "Chocolate cake"},
                {400, "Lobster"}
            };

            Dictionary<string, int> coocked = new Dictionary<string, int>();
            
            while (ingredient.Count > 0 && freshness.Count > 0)
            {
                if (ingredient.Peek() == 0)
                {
                    ingredient.Dequeue();
                    continue;
                }
                int multiplication = ingredient.Peek() * freshness.Peek();
                if (dishes.ContainsKey(multiplication))
                {
                    ingredient.Dequeue();
                    freshness.Pop();
                    if (!coocked.ContainsKey(dishes[multiplication]))
                    {
                        coocked.Add(dishes[multiplication], 1);
                    }
                    else
                    {
                        coocked[dishes[multiplication]]++;
                    }
                    
                }
                else if (!dishes.ContainsKey(multiplication))
                {
                    freshness.Pop();
                    int temp = ingredient.Dequeue() + 5;
                    ingredient.Enqueue(temp);
                }
            }

            if (coocked.Count >= 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredient.Count > 0)
            {
                Console.WriteLine($" Ingredients left: {ingredient.Sum()}");
            }

            foreach (var dish in coocked.OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}

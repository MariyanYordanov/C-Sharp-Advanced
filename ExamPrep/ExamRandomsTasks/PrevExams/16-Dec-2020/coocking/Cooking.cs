using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Cooking
    {
        static void Main(string[] args)
        {

            int[] first = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] second = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> liquids = new Queue<int>(first);
            Stack<int> ingredients = new Stack<int>(second);
            Dictionary<int, string> bakery = new Dictionary<int, string>()
            {
                { 25, "Bread"},
                { 50, "Cake"},
                { 75, "Pastry"},
                { 100, "Fruit Pie"}
            };
            Dictionary<string, int> cooked = new Dictionary<string, int>()
            {
                {"Bread", 0},
                {"Cake", 0},
                {"Fruit Pie",0},
                {"Pastry",0}
            };
            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int sum = liquids.Peek() + ingredients.Peek();
                if (bakery.ContainsKey(sum))
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    cooked[bakery[sum]] += 1;
                }
                else
                {
                    liquids.Dequeue();
                    int newValue = 3 + ingredients.Pop();
                    ingredients.Push(newValue);
                }
            }

            if (cooked.Any(x => x.Value == 0))
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }

            if (liquids.Count == 0 )
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ",ingredients)}");
            }

            foreach (var item in cooked)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}

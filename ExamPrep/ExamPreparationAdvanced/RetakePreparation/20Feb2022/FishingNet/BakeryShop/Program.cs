using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray());

            Stack<double> flour = new Stack<double>(Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray());

            Dictionary<double, string> products = new Dictionary<double, string>()
            {
                { 50, "Croissant"},
                { 40, "Muffin"},
                { 30, "Baguette"},
                { 20, "Bagel"},
            };

            Dictionary<string, int> bakedproducts = new Dictionary<string, int>();

            while (water.Count > 0 && flour.Count > 0)
            {
                double sum = water.Peek() + flour.Peek();
                double percent = water.Peek() * 100 / sum;
                if (products.ContainsKey(percent))
                {
                    if (!bakedproducts.ContainsKey(products[percent]))
                    {
                        bakedproducts.Add(products[percent],1);
                        water.Dequeue();
                        flour.Pop();
                    }
                    else if (bakedproducts.ContainsKey(products[percent]))
                    {
                        bakedproducts[products[percent]] += 1;
                        water.Dequeue();
                        flour.Pop();
                    }
                    
                }
                else
                {
                    if (!bakedproducts.ContainsKey("Croissant"))
                    {
                        bakedproducts.Add("Croissant", 1);
                    }
                    else
                    {
                        bakedproducts["Croissant"] += 1;
                    }
                    
                    double nessecceryAmount = flour.Peek() - water.Peek();
                    water.Dequeue();
                    flour.Pop();
                    flour.Push(nessecceryAmount);
                }
            }

            foreach (var item in bakedproducts
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (water.Count == 0)
            {
                Console.WriteLine($"Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }

            if (flour.Count == 0)
            {
                Console.WriteLine($"Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ",flour)}");
            }
        }
    }
}

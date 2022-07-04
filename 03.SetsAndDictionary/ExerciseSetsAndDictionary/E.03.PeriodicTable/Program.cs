using System;
using System.Collections.Generic;
using System.Linq;

namespace E._03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> elements = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] element = Console.ReadLine().Split();
                for (int j = 0; j < element.Length; j++)
                {
                    elements.Add(element[j]);
                }
            }
            elements = elements.OrderBy(x => x).ToHashSet();
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace E._02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                first.Add(num);
            }

            for (int i = 0; i < m; i++)
            {
                int num = int.Parse(Console.ReadLine());
                second.Add(num);
            }

            List<int> result = first.Intersect(second).ToList();

            Console.WriteLine(string.Join(" ",result));
        }
    }
}

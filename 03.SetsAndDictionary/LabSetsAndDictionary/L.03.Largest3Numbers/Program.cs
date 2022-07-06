using System;
using System.Collections.Generic;
using System.Linq;

namespace L._03.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).Take(3).ToArray();
            Console.WriteLine(string.Join(" ",n));
        }
    }
}

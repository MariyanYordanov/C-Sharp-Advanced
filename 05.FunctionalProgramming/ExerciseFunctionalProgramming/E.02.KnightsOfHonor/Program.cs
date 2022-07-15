using System;
using System.Collections.Generic;
using System.Linq;

namespace E._02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Action<List<string>> print = names => names.ForEach(x => Console.WriteLine($"Sir {x}"));
            print(names);
        }
    }
}

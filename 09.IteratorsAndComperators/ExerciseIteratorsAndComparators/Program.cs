using System;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseIteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] integerElements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int, int, int> customComperar = (x, y) =>
            {
                return (x % 2 == 0 && y % 2 != 0)
                ? -1
                : (x % 2 != 0 && y % 2 == 0)
                ? 1
                : x > y
                ? 1
                : x < y
                ? -1
                : 0;
            };

            Array.Sort(integerElements, (x,y) => customComperar(x,y));

            Console.WriteLine(string.Join(" ",integerElements));
        }
    }
}

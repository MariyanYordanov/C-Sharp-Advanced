using System;
using System.Linq;

namespace E._04.EvenOrOddSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] interval = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int start = interval[0];
            int end = interval[1];
            string operation = Console.ReadLine();
            Predicate<int> isEven = number => number % 2 == 0;
            Predicate<int> isOdd = number => number % 2 != 0;
            for (int i = start; i <= end; i++)
            {
                if (operation == "odd" && isOdd(i))
                {
                    Console.Write(i + " ");
                }
                else if(operation == "even" && isEven(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}

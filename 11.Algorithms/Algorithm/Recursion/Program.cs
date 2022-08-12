using System;
using System.Linq;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int index = 0;
            Console.WriteLine(Sum(numbers, index));
            // second task
            //long number = long.Parse(Console.ReadLine());
            //ConsoleWriteLine(Factorielnumber());
        }

        private static int Sum(int[] numbers, int index)
        {
            if (index == numbers.Length - 1)
            {
                return numbers[index];
            }

            return numbers[index] + Sum(numbers, index + 1);
        }

        private static long Factoriel(long number)
        {
            if (number == 1)
            {
                return 1;
            }
            return number * Factoriel(number - 1);
        }
    }
}

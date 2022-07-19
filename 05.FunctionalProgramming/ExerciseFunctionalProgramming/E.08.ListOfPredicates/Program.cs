using System;
using System.Linq;

namespace E._08.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> isDiv = (number, divider) => number % divider == 0;
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 1; i <= n; i++)
            {
                bool isDivider = false;
                foreach (var number in numbers)
                {
                    if (isDiv(i, number))
                    {
                        isDivider = true;
                    }
                    else
                    {
                        isDivider = false;
                        break;
                    }
                }

                if (isDivider)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}

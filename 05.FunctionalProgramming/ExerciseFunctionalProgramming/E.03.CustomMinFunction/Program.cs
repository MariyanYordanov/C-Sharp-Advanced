using System;
using System.Linq;

namespace E._03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> minimum = x =>
            {
                int minValue = int.MaxValue;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] < minValue)
                    {
                        minValue = numbers[i];
                    }
                }

                return minValue;
            };

            Console.WriteLine(minimum(numbers));
        }

    }
}

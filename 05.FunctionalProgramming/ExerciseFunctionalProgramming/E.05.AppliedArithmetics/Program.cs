using System;
using System.Linq;

namespace E._05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string commands = Console.ReadLine();
            Action<int[]> add = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] += 1;
                };
            };
            Action<int[]> subtract = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] -= 1;
                };
            };
            Action<int[]> multiply = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] *= 2;
                };
            };
            Action<int[]> print = numbers => Console.WriteLine(string.Join(" ", numbers));
            while (commands != "end")
            {
                if (commands == "add")
                {
                    add(numbers);
                }
                else if (commands == "subtract")
                {
                    subtract(numbers);
                }
                else if (commands == "multiply")
                {
                    multiply(numbers);
                }
                else if (commands == "print")
                {
                    print(numbers);
                }

                commands = Console.ReadLine();
            }
        }
    }
}

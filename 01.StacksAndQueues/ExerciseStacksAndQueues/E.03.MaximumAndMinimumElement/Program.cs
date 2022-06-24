using System;
using System.Collections.Generic;
using System.Linq;

namespace E._03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < N; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (input[0] == 1)
                {
                    int x = input[1];
                    stack.Push(x);
                }

                if (input[0] == 2 && stack.Count > 0)
                {
                    stack.Pop();
                }

                if (input[0] == 3 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                }

                if (input[0] == 4 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }

            }

            Console.WriteLine(string.Join(", ",stack));
            
        }
    }
}

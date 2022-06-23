using System;
using System.Collections.Generic;
using System.Linq;

namespace L._05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(arr);

            while (queue.Count > 0)
            {
                int element = queue.Dequeue();
                if (element % 2 == 0)
                {
                    if (queue.Count == 0)
                    {
                        Console.Write(element);
                    }
                    else
                    {
                        Console.Write(element + ", ");
                    }
                }
            }
        }
    }
}

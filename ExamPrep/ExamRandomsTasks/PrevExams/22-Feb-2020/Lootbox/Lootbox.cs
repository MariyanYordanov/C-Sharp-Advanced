using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Lootbox
    {
        static void Main(string[] args)
        {
            int[] firstBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(firstBox);
            Stack<int> stack = new Stack<int>(secondBox);
            int myCollection = 0;
            while (true)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }

                if (stack.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }

                int sum = queue.Peek() + stack.Peek();
                if (sum % 2 == 0)
                {
                    myCollection += sum;
                    queue.Dequeue();
                    stack.Pop();
                }
                else
                {
                    queue.Enqueue(stack.Pop());
                }
            }

            if (myCollection >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {myCollection}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {myCollection}");
            }
        }
    }
}

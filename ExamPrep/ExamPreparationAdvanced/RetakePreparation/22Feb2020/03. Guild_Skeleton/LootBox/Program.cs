using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] firstLootBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondLootBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(firstLootBox);
            Stack<int> stack = new Stack<int>(secondLootBox);
            int sumItems = 0;

            while (queue.Count > 0 && stack.Count > 0)
            {
                int sum = queue.Peek() + stack.Peek();
                if (sum % 2 == 0)
                {
                    sumItems += sum;
                    queue.Dequeue();
                    stack.Pop();
                }
                else
                {
                    int element = stack.Pop();
                    queue.Enqueue(element);
                }

            }

            if (queue.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sumItems > 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumItems}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] capacity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] plates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> capacityQueue = new Queue<int>(capacity);
            Stack<int> platesStack = new Stack<int>(plates);
            int wastedFood = 0;
            while (platesStack.Count > 0 && capacityQueue.Count > 0)
            {
                int diff = platesStack.Peek() - capacityQueue.Peek();
                if (diff >= 0)
                {
                    wastedFood += platesStack.Pop() - capacityQueue.Dequeue();
                }
                else
                {
                    int current = capacityQueue.Peek();
                    current -= platesStack.Pop();
                    while (current > 0)
                    {
                        current -= platesStack.Pop();
                    }
                    wastedFood += Math.Abs(current);
                    capacityQueue.Dequeue();
                }
               
            }

            if (capacityQueue.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ",platesStack)}");
            }
            else if (platesStack.Count == 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ",capacityQueue)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}

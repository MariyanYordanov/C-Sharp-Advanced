using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> cups = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray().Reverse());
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                if (bottles.Peek() >= cups.Peek())
                {
                    wastedWater += bottles.Peek() - cups.Peek();
                    cups.Pop();
                    bottles.Pop();
                }
                else
                {
                    int cup = cups.Peek();
                    int bottle = bottles.Peek();
                    int rest = cup - bottle;
                    cups.Pop();
                    cups.Push(rest);
                    bottles.Pop();
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else if (bottles.Count == 0)
            {
                cups.Reverse();
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}

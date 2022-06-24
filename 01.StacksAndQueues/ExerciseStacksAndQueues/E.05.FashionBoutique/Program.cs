using System;
using System.Collections.Generic;
using System.Linq;

namespace E._05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int capacityRack = int.Parse(Console.ReadLine());
            int sum = 0;
            int counter = 1;
            while (stack.Count > 0)
            {
                sum += stack.Peek();
                if (sum <= capacityRack)
                {
                    stack.Pop();
                }
                else
                {
                    sum = 0;
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}

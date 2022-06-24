using System;
using System.Collections.Generic;
using System.Linq;

namespace E._04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Console.WriteLine(orders.Max());

            while (orders.Count > 0)
            {
                if (quantityFood >= orders.Peek())
                {
                    int servedOrder = orders.Dequeue();
                    quantityFood -= servedOrder;
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}

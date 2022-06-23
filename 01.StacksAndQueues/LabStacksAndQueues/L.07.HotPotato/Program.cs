using System;
using System.Collections.Generic;
using System.Linq;

namespace L._07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            Queue<string> queue = new Queue<string>(input);
            int toss = int.Parse(Console.ReadLine());
            int counter = 1;
            while (queue.Count > 1)
            {
                string kid = queue.Dequeue();
                if (counter % toss != 0)
                {
                    queue.Enqueue(kid);
                }
                else
                {
                    Console.WriteLine($"Removed {kid}");
                }

                counter++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}

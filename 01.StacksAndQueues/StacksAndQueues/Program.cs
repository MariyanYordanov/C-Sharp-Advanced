using System;
using System.Collections.Generic;
using System.Linq;

namespace StaksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray(); ;
            Stack<int> stack = new Stack<int>();
            stack.Push(numbers[0]);
            stack.Push(numbers[1]);
            stack.Push(numbers[2]);

            foreach (var item in stack)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine(" Moment condition");

            stack.Pop();
            
            Console.WriteLine("-> After Peek() - the lats element is:", stack.Peek());
            
            Console.WriteLine(stack.Contains(10));
            
            Console.WriteLine(stack.Count());

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--------------");

            Queue<string> queue = new Queue<string>();

            queue.Enqueue("My");
            queue.Enqueue("car");
            queue.Enqueue(" is ");
            queue.Enqueue("Honda");

            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            queue.Dequeue();

            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}

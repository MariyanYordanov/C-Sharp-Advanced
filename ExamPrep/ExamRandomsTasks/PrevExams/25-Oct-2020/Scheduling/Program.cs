using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] tasksInput = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int[] threadsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int task = int.Parse(Console.ReadLine());
            Stack<int> tasks = new Stack<int>(tasksInput);
            Queue<int> threads = new Queue<int>(threadsInput);
            while (tasks.Count > 0 && threads.Count > 0)
            {
                if (tasks.Peek() == task)
                {
                    Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasks.Pop()}");
                    break;
                }

                if (threads.Peek() >= tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace L._02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            foreach (var item in input)
            {
                stack.Push(item);
            }

            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                string[] token = command.Split().ToArray();
                if (token[0] == "add")
                {
                    int firstNum = int.Parse(token[1]);
                    int secondtNum = int.Parse(token[2]);
                    stack.Push(firstNum);
                    stack.Push(secondtNum);
                }
                else if (token[0] == "remove")
                {
                    int removeNums = int.Parse(token[1]);
                    if (removeNums < stack.Count)
                    {
                        for (int i = 0; i < removeNums; i++)
                        {
                            stack.Pop();
                        }
                    }
                    
                }

                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}

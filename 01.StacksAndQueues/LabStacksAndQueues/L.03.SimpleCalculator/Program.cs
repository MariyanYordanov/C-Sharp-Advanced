using System;
using System.Collections.Generic;
using System.Linq;

namespace L._03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            input = input.Reverse().ToArray();
            Stack<string> stack = new Stack<string>();
            foreach (string item in input)
            {
                stack.Push(item);
            }

            int result = int.Parse(stack.Peek());
            stack.Pop();
            string lastOperator = "";
            while (stack.Count > 0)
            {
                string lastElement = stack.Peek();
                if (lastElement != "+" && lastElement != "-")
                {
                    int lastDigit = int.Parse(lastElement);
                    if (lastOperator == "-")
                    {
                        result -= lastDigit;
                    }
                    else
                    {
                        result += lastDigit;
                    }
                }
                else if (lastElement == "-")
                {
                    lastOperator = "-";
                }
                else if (lastElement == "+")
                {
                    lastOperator = "+";
                }

                stack.Pop();
            }

            Console.WriteLine(result);
        }
    }
}

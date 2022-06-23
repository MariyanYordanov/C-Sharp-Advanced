using System;
using System.Collections.Generic;
using System.Linq;

namespace L._01.Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> myStack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                myStack.Push(input[i]);
            }

            myStack.Reverse();

            foreach (var item in myStack)
            {
                Console.Write(item);
            }

        }
    }
}

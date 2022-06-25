using System;
using System.Collections.Generic;

namespace E._08.Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charArr = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < charArr.Length; i++)
            {
                char currentChar = charArr[i];
                if (currentChar == '{' || currentChar == '[' || currentChar == '(')
                {
                    stack.Push(currentChar);
                }
                else if (currentChar == '}' || currentChar == ']' || currentChar == ')')
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return; 
                    }
                    char topChar = stack.Peek();
                    if ((topChar == '{' && currentChar == '}') || (topChar == '[' && currentChar == ']') || (topChar == '(' && currentChar == ')'))
                    {
                        stack.Pop();
                    }
                    else 
                    { 
                        break; 
                    }
                }
            }

            Console.WriteLine(stack.Count > 0 ? "NO" : "YES");
        }

    }
}

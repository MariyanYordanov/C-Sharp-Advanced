using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace E._09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            Stack<string> textRemoved = new Stack<string>();
            textRemoved.Push(text.ToString());
            int n = int.Parse(Console.ReadLine());
            for (int index = 0; index < n; index++)
            {
                string[] commands = Console.ReadLine().Split();
                string commandName = commands[0];
                if (commandName == "1")
                {
                    string argument = commands[1];
                    text.Append(argument);
                    textRemoved.Push(text.ToString());
                }
                else if (commandName == "2")
                {
                    int argument = int.Parse(commands[1]);
                    text.Remove(text.Length - argument, argument);
                    textRemoved.Push(text.ToString());
                }
                else if (commandName == "3")
                {
                    int argument = int.Parse(commands[1]);
                    Console.WriteLine(text.ToString().ElementAt(argument - 1));
                    
                }
                else if (commandName == "4")
                {
                    text.Clear();
                    textRemoved.Pop();
                    text.Append(textRemoved.Peek());
                }      
            }
        }
    }
}

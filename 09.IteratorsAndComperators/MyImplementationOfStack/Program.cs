using System;
using System.Linq;

namespace MyImplementationOfStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> numbers = new MyStack<int>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                var tokens = input.Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);
                
                if (tokens[0] == "Push")
                {
                    foreach (var item in tokens.Skip(1))
                    {
                        numbers.Push(int.Parse(item));
                    }
                }
                else if (tokens[0] == "Pop")
                {
                    try
                    {
                        numbers.Pop();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}

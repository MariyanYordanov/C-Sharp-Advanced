using System;

namespace E._02.GenericBoxOfInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Box<int> numbers = new Box<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                numbers.Items.Add(input);
            }

            Console.WriteLine(numbers);
        }
    }
}

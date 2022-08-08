using System;

namespace E._04.GenericSwapMethodInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Items.Add(input);
            }

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int firstCmd = int.Parse(commands[0]);
            int secondCmd = int.Parse(commands[1]);
            box.Swap(firstCmd, secondCmd);
            Console.WriteLine(box.ToString());
        }
    }
}

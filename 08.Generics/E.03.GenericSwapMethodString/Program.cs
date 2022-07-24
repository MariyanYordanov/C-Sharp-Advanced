using System;

namespace E._03.GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
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

using System;

namespace E._05.GenericCountMethodString
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

            string stringElements = Console.ReadLine();
            Console.WriteLine(box.CountBigger(stringElements));
        }
    }
}

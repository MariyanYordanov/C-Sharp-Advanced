using System;

namespace E._01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> print = names => Console.WriteLine(string.Join("\n", names));
            print(names);
        }
    }
}

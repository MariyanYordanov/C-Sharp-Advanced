using System;

namespace E._07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isLongEnough = (name, lenght) => name.Length <= lenght;
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            foreach (var name in names)
            {
                if (isLongEnough(name, n))
                {
                    Console.WriteLine(name);
                }
            }
            
        }
    }
}

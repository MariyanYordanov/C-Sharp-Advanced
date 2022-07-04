using System;
using System.Collections.Generic;
using System.Linq;

namespace E._01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                usernames.Add(input);
            }

            usernames.ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}

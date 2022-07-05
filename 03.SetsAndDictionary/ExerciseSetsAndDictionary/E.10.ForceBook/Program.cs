using System;
using System.Collections.Generic;
using System.Linq;

namespace E._10.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] inputArray = input.Split(" | ");
                    string forceSide = inputArray[0];
                    string forceUser = inputArray[1];
                    if (!users.ContainsKey(forceUser))
                    {
                        users.Add(forceUser, forceSide);
                    }

                }
                else if(input.Contains("->"))
                {
                    string[] inputArray = input.Split(" -> ");
                    string forceUser = inputArray[0];
                    string forceSide = inputArray[1];
                    if (users.ContainsKey(forceUser))
                    {
                        users[forceUser] = forceSide;
                    }
                    else
                    {
                        users.Add(forceUser, forceSide);
                        
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                input = Console.ReadLine();
            }

            var sorted = users.GroupBy(x => x.Value).OrderByDescending(x => x.Count()).ThenBy(x => x.Key);

            foreach (var side in sorted)
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Count()}");
                var order = side.OrderBy(x => x.Key);
                foreach (var member in order)
                {
                    Console.WriteLine($"! {member.Key}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace E._09.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            string action = Console.ReadLine();
            while (action != "Party!")
            {
                string[] operations = action.Split();
                string command = operations[0];
                string token = operations[1];
                string criteria = operations[2];
                if (command == "Double")
                {
                    List<string> doublePeople = people.FindAll(GetPredicate(token, criteria));
                    if (doublePeople.Count <= 0)
                    {
                        action = Console.ReadLine();
                        continue;
                    }
                    int findIndex = people.FindIndex(GetPredicate(token, criteria));
                    people.InsertRange(findIndex, doublePeople);
                }
                else
                {
                    people.RemoveAll(GetPredicate(token, criteria));
                }

                action = Console.ReadLine();
            }

            if (people.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        private static Predicate<string> GetPredicate(string token, string criteria)
        {
            if (token == "StartsWith")
            {
                return x => x.StartsWith(criteria);
            }

            if (token == "EndsWith")
            {
                return x => x.EndsWith(criteria);
            }

            return x => x.Length == int.Parse(criteria);
        }
    }
}

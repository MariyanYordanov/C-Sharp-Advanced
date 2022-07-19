using System;
using System.Collections.Generic;
using System.Linq;

namespace E._10.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Predicate<string>> allFilters = new Dictionary<string, Predicate<string>>();
            List<string> names = Console.ReadLine().Split().ToList(); 
            string input = Console.ReadLine();
            while (input != "Print")
            {
                string[] commands = input.Split(";");
                string operations = commands[0];
                string filterType = commands[1];
                string filterParameter = commands[2];
                if (operations == "Add filter")
                {
                    allFilters.Add(filterType + filterParameter, GetPredicate(filterType, filterParameter));
                }
                else if (operations == "Remove filter")
                {
                    allFilters.Remove(filterType + filterParameter);
                }

                input = Console.ReadLine();
            }

            foreach (var (key,value) in allFilters)
            {
                names.RemoveAll(value);
            }

            Console.WriteLine(string.Join(" ",names));
        }

        private static Predicate<string> GetPredicate(string filterType, string filterParameter)
        {
            if (filterType == "Starts with")
            {
                return x => x.StartsWith(filterParameter);
            }
            else if (filterType == "Ends with")
            {
                return x => x.EndsWith(filterParameter);
            }
            else if (filterType == "Length")
            {
                return x => x.Length == int.Parse(filterParameter);
            }
            else if (filterType == "Contains")
            {
                return x => x.Contains(filterParameter);
            }
            else
            {
                return null;
            }
        }
    }
}

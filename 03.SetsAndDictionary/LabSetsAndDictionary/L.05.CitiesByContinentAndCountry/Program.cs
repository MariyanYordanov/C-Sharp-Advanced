using System;
using System.Collections.Generic;
using System.Linq;

namespace L._05.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] splited = Console.ReadLine().Split().ToArray();
                string continent = splited[0];
                string country = splited[1];
                string town = splited[2];
                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }

                continents[continent][country].Add(town);
            }
            
            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.Write($"    {country.Key} -> ");
                    for (int i = 0; i < country.Value.Count; i++)
                    {
                        if (i == 0)
                        {
                            Console.Write($"{country.Value[i]}");
                        }
                        else
                        {
                            Console.Write($", {country.Value[i]}");
                        }

                    }

                    Console.WriteLine();
                }
                
            }
        }
    }
}

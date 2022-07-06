using System;
using System.Collections.Generic;
using System.Linq;

namespace L._04.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> markets = new Dictionary<string, Dictionary<string, double>>();
            string input = Console.ReadLine();
            while (input != "Revision")
            {
                string[] splited = input.Split(", ").ToArray();
                string market = splited[0];
                string product = splited[1];
                double price = double.Parse(splited[2]);
                if (!markets.ContainsKey(market))
                {
                    markets.Add(market, new Dictionary<string, double>());
                }

                markets[market].Add(product, price);

                input = Console.ReadLine();
            }

            markets = markets.OrderBy(x => x.Key).ToDictionary(x=> x.Key, y => y.Value);
            foreach (var market in markets)
            {
                Console.WriteLine($"{market.Key}->");
                foreach (var product in market.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}

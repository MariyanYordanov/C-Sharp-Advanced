using System;

namespace E._08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] person = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, string, string> personThreeuple =
                new Threeuple<string, string, string>
                ($"{person[0]} {person[1]}", $"{person[2]}",$"{person[3]}");

            string[] drunk = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            bool isDrunk = drunk[2] == "drunk";

            Threeuple<string, int, bool> drunkThreeuple =
                new Threeuple<string, int, bool>
                ($"{drunk[0]}", int.Parse(drunk[1]), isDrunk);

            string[] balance = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, double, string> balanceThreeuple =
                new Threeuple<string, double, string>
                ($"{balance[0]}",double.Parse(balance[1]), $"{balance[2]}");

            Console.WriteLine(personThreeuple.ToString());
            Console.WriteLine(drunkThreeuple.ToString());
            Console.WriteLine(balanceThreeuple.ToString());
        }

    }
}

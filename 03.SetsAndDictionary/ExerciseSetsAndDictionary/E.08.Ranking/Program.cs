using System;
using System.Collections.Generic;
using System.Linq;

namespace E._08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPasword = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] inputArray = input.Split(":");
                string contest = inputArray[0];
                string password = inputArray[1];
                if (!contestPasword.ContainsKey(contest))
                {
                    contestPasword.Add(contest,password);
                }

                contestPasword[contest] = password;
                input = Console.ReadLine();
            }

            string data = Console.ReadLine();
            while (data != "end of submissions")
            {
                string[] dataArray = data.Split("=>");
                string contest = dataArray[0];
                string password = dataArray[1];
                string username = dataArray[2];
                int points = int.Parse(dataArray[3]);
                if (contestPasword.ContainsKey(contest) && contestPasword[contest] == password)
                {
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int>());
                    }

                    if (!users[username].ContainsKey(contest))
                    {
                        users[username].Add(contest, points);
                    }

                    if (points > users[username][contest])
                    {
                        users[username][contest] = points;
                    }
                    
                }

                data = Console.ReadLine();
            }

            int maxPoints = 0;
            string userWhitMaxPoints = "";
            foreach (var user in users)
            {
                int points = user.Value.Values.Sum();
                if (points > maxPoints)
                {
                    maxPoints = points;
                    userWhitMaxPoints = user.Key;
                }
            }

            Console.WriteLine($"Best candidate is {userWhitMaxPoints } with total {maxPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}");
                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
                
            }
        }
    }
}

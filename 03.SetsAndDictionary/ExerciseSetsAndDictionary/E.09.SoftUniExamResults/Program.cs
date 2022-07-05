using System;
using System.Collections.Generic;
using System.Linq;

namespace E._09.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> contest  = new Dictionary<string, List<string>>();
            Dictionary<string, List<int>> user = new Dictionary<string, List<int>>();
            string input = Console.ReadLine();
            while (input != "exam finished")
            {
                string[] inputArray = input.Split("-");
                if (inputArray.Length == 3)
                {
                    string username = inputArray[0];
                    string language = inputArray[1];
                    int points = int.Parse(inputArray[2]);
                    if (!contest.ContainsKey(language))
                    {
                        contest.Add(language, new List<string>());
                    }

                    contest[language].Add(username);

                    if (!user.ContainsKey(username))
                    {
                        user.Add(username, new List<int>());
                    }

                    user[username].Add(points);
                }
                else if (inputArray.Length == 2)
                {
                    string bannedUser = inputArray[0];
                    if (user.ContainsKey(bannedUser))
                    {
                        user.Remove(bannedUser);
                    }
                    
                }
               
                input = Console.ReadLine();
            }

            var sortedUsers = user.OrderByDescending(x => x.Value.Max()).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine("Results:");
            foreach (var submission in sortedUsers)
            {
                Console.WriteLine($"{submission.Key} | {submission.Value.Max()}");
            }

            var sortedSubmitions = contest.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine("Submissions:");
            foreach (var language in sortedSubmitions)
            {
                Console.WriteLine($"{language.Key} - {language.Value.Count}");
            }
        }
    }
}

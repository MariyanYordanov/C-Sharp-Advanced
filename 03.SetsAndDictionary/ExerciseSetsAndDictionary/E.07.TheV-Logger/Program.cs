using System;
using System.Collections.Generic;
using System.Linq;

namespace E._07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            //string input = Console.ReadLine();
            //string following = "following";
            //string followers = "followers";
            //while (input != "Statistics")
            //{
            //    string[] cmd = input.Split().ToArray();
            //    string user = cmd[0];
            //    string action = cmd[1];
            //    string starUser = cmd[2];

            //    if (action == "joined" && !vloggers.ContainsKey(user))
            //    {
            //        vloggers.Add(user, new Dictionary<string, HashSet<string>>());
            //        vloggers[user].Add(following, new HashSet<string>());
            //        vloggers[user].Add(followers, new HashSet<string>());
            //    }

            //    else if (action == "followed" && vloggers.ContainsKey(user) && vloggers.ContainsKey(starUser) && starUser != user)
            //    {
            //        vloggers[user][following].Add(starUser);
            //        vloggers[starUser][followers].Add(user);
            //    }

            //    input = Console.ReadLine();
            //}

            //Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            //var sortedVlogers = vloggers.OrderByDescending(x => x.Value[followers].Count).ThenBy(x => x.Value[following].Count);
            //int counter = 1;
            //foreach (var vlogger in sortedVlogers)
            //{
            //    Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value[followers].Count} followers, {vlogger.Value[following].Count} following");
            //    if (counter == 1)
            //    {
            //        foreach (var follower in vlogger.Value[followers].OrderBy(x => x))
            //        {
            //            Console.WriteLine($"*  {follower} ");
            //        }
            //    }

            //    counter++;
            //}

            // SOLUTION WHIT CLASSES 

            Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();
            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string[] cmd = input.Split().ToArray();
                string user = cmd[0];
                string action = cmd[1];
                string starUser = cmd[2];

                if (action == "joined" && !vloggers.ContainsKey(user))
                {
                    vloggers.Add(user, new Vlogger());
                }

                else if (action == "followed" && vloggers.ContainsKey(user) && vloggers.ContainsKey(starUser) && starUser != user)
                {
                    vloggers[user].Following.Add(starUser);
                    vloggers[starUser].Followers.Add(user);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var sortedVlogers = vloggers.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count);
            int counter = 1;
            foreach (var vlogger in sortedVlogers)
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower} ");
                    }
                }

                counter++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        public List<Player> players;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            players = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => players.Count;

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);
            return players.Remove(player);
        }
        
        public void PromotePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);
            if (player != null && player.Rank != "Member")
            {
                players[players.IndexOf(player)].Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);
            if (player != null && player.Rank != "Trial")
            {
                players[players.IndexOf(player)].Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            players = players.Where(x => x.Class != @class).ToList();
            Player[] playerArray = players.Where(x => x.Class == @class).ToArray();
            return playerArray;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Players in the guild: {Name}");
            foreach (var player in players)
            {
                stringBuilder.AppendLine(player.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}

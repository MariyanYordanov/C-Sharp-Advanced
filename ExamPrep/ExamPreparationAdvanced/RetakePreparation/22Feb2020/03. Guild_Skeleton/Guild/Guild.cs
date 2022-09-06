using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private readonly List<Player> roster;
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roster.Count;

        public void AddPlayer(Player player) 
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        { 
            var playerToRemove = roster.FirstOrDefault(x => x.Name == name);
            if (playerToRemove == null)
            {
                return false;
            }
            else
            {
                roster.Remove(playerToRemove);
                return true;
            }
        }
        public void PromotePlayer(string name)
            => roster.FirstOrDefault(x => x.Name == name).Rank = "Member";

        public void DemotePlayer(string name)
            => roster.FirstOrDefault(x => x.Name == name).Rank = "Trial";

        public Player[] KickPlayersByClass(string @class) 
        {
            Player[] listWithPlayersToRemove = roster
                .Where(x => x.Class == @class)
                .ToArray();

            for (int i = 0; i < listWithPlayersToRemove.Length; i++)
            {
                if (roster.Contains(listWithPlayersToRemove[i]))
                {
                    roster.Remove(listWithPlayersToRemove[i]);
                }
            }

            return listWithPlayersToRemove;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in roster)
            {
                sb.AppendLine($"{player}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

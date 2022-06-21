using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    internal class Guild
    {
        private List<Player> roster;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roster.Count;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        public void AddPlayer (Player player)
        {
            // ¤ adds an entity to the roster if there is room for it
            if (Count < Capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer (string name)
        {
            // ¤ removes a player by given name, if such exists, and returns bool
            return roster.Remove(roster.FirstOrDefault(x => x.Name == name));
        }
        public void PromotePlayer (string name)
        {
            // ¤ promote (set his rank to "Member") the first player with the given name.
            // If the player is already a "Member", do nothing.
            Player player = roster.FirstOrDefault(x => x.Name == name);
            if (player != null && player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer (string name)
        {
            // ¤ demote (set his rank to "Trial") the first player with the given name.
            // If the player is already a "Trial",  do nothing.
            Player player = roster.FirstOrDefault (x => x.Name == name);
            if (player != null && player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string @class)
        {
            Player[] kickPlayer = this.roster.FindAll(x => x.Class == @class).ToArray();
            this.roster.RemoveAll(p => p.Class == @class);
            return kickPlayer;
        }
        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Player in the guild: {Name}");

            for (int i = 0; i < roster.Count; i++)
            {
                output.AppendLine(roster[i].ToString());
            }
            return output.ToString();
        }
    }
}

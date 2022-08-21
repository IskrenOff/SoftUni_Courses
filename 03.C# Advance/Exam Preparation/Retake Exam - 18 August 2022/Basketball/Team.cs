using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        private string name;
        private int openPositions;
        private char group;

        public int Count => players.Count;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                name = value;
            }
        }

        public int OpenPositions
        {
            get => openPositions;
            private set
            {
                openPositions = value;
            }
        }

        public char Group
        {
            get => group;
            private set 
            {
                group = value; 
            }
        }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            if (openPositions <= 0)
            {
                return "There are no more open positions.";
            }
            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            openPositions--;
            players.Add(player);
            return $"Successfully added {player.Name} to the team. Remaining open positions: {openPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            bool result = false;

            var playerToRemove = players.FirstOrDefault(x => x.Name == name); 

            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
                openPositions++;
                result = true;
            }

            return result;
            
        }
        public int RemovePlayerByPosition(string position)
        {
            //int cnt = 0;
            //
            //foreach (var player in players)
            //{
            //    if (player.Position == position)
            //    {
            //        players.Remove(player);
            //        cnt++;
            //    }
            //}
            //
            //return cnt;

            Player[] kickPlayer = players.FindAll(x => x.Position == position).ToArray();
            players.RemoveAll(x => x.Position == position);
            openPositions += kickPlayer.Length;
            return kickPlayer.Length;
        }

        public Player RetirePlayer(string name)
        {
            //return players.Find(x => x.Name == name && x.Retired == true);
            Player retired = players.FirstOrDefault(p => p.Name == name);

            if (retired != null)
            {
                retired.Retired = true;
            }
            
            return retired;
        }

        public List<Player> AwardPlayer(int games)
        {

            
            return players.FindAll(p => p.Games >= games);

            
        }

        public string Report()
        {
            List<Player> notRetaried = new List<Player> (players.FindAll(x => !x.Retired));

            StringBuilder output = new StringBuilder();

            output.AppendLine($"Active players competing for Team {name} from Group {group}:");

            foreach (var player in notRetaried)
            {
                output.AppendLine($"{player}");
            }

            return output.ToString().TrimEnd();
        }
    }
}

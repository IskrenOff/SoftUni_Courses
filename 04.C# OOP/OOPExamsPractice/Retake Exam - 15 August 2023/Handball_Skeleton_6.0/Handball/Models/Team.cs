using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public abstract class Team : ITeam
    {
        private string name;
        private int pointsEarned;
        private List<IPlayer> players;

        protected Team(string name)
        {
            this.Name = name;
            this.pointsEarned = 0;
            this.players = new List<IPlayer>();
        }

        public string Name 
        {
            get => name;
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }

        }

        public int PointsEarned => pointsEarned;
        

        public double OverallRating => this.Players.Count == 0 ? 0 :Math.Round(this.players.Average(p => p.Rating),2);

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Draw()
        {
            this.pointsEarned++;
            this.players.FirstOrDefault(p => p.GetType().Name == nameof(Goalkeeper)).IncreaseRating();
        }

        public void Lose()
        {
            foreach (var player in this.Players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
            this.players.Add(player);
        }

        public void Win()
        {
            this.pointsEarned += 3;
            foreach (var player in this.players) 
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Team: {this.Name} Points: {this.PointsEarned}");
            sb.Append($"--Overall rating: {OverallRating}");
            sb.Append($"--Players: ");

            if (this.players.Any())
            {
                var names = this.players.Select(p => p.Name);
                sb.Append(string.Join(", ", names));
            }
            else
            {
                sb.Append("none");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

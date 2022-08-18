using System;
using System.Text;

namespace Basketball
{
    public class Player
    {
        private string name;
        private string position;
        private double rating;
        private int games;
        private bool retired;

        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;
        }

        public string Name
        {
            get => name;
            private set
            {
                name = value;
            }
        }

        public string Position
        {
            get => position;
            private set
            {
                position = value;
            }
        }

        public double Rating
        {
            get => rating; 
            private set
            {
                rating = value;
            }
        }

        public int Games
        {
            get => games; 
            private set
            {
                games = value;
            }
        }
        public bool Retired
        {
            get => retired;
            set
            {
                retired = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"-Player: {name}");
            sb.AppendLine($"--Position: {position}");
            sb.AppendLine($"--Rating: {rating}");
            sb.AppendLine($"--Games played: {games}");

            return sb.ToString().TrimEnd();
        }
    }
}

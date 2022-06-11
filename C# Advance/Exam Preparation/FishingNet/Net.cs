using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
        private string material;
        private int capacity;

        public Net(string material, int capacity)
        {
            this.material = material;
            this.capacity = capacity;
        }
        public string Material
        {
            get { return this.material; }
            set { this.material = value; }
        }
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }
        public int Count => this.Fish.Count;
        public List<Fish> Fish
        {
            get => this.fish;
            private set {}
        }
        public string AddFish (Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <=0)
            {
                return "Invalid fish.";
            }
            if(Count == Capacity)
            {
                return "Fishing net is full";
            }
            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish (double weight)
        {
            Fish fish = this.Fish.FirstOrDefault(x => x.Weight == weight);
            if (fish != null)
            {
                return this.Fish.Remove(fish);
            }
            return false;
        }
        public Fish GetFish (string fishType)
        {
            Fish fish = this.Fish.FirstOrDefault(x => x.FishType == fishType);
            return fish;
        }
        public Fish GetBiggestFish ()
        {
            double longestFish = this.Fish.Max(c => c.Length);
            Fish fish = this.Fish.FirstOrDefault(x => x.Length == longestFish);
            return fish;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");
            foreach (var fish in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

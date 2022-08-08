namespace FishingNet
{
    public class Fish
    {
        private string fishType;
        private double length;
        private double weight;

        public Fish(string fishType, double length, double weight)
        {
            this.fishType = fishType;
            this.length = length;
            this.weight = weight;
        }

        public string FishType
        {
            get { return fishType; }
            set { fishType = value; }
        }
        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public override string ToString()
        {
            return $"There is a {this.fishType}, {this.length} cm. long, and {this.weight} gr. in weight.";
        }      

    }
}

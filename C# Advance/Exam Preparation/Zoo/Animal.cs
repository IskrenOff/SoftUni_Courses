namespace Zoo
{
    public class Animal
    {
        private string species;
        private string diet;
        private double weight;
        private double length;

        public Animal(string species, string diet, double weight, double leght)
        {
            this.species = species;
            this.diet = diet;
            this.weight = weight;
            this.length = leght;
        }

        public string Species
        {
            get { return species; }
            set { species = value; }
        }
        public string Diet
        {
            get { return diet; }
            set { diet = value; }
        }
        public double Weight
        {   
            get { return weight; } 
            set { weight = value; } 
        }
        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        public override string ToString() => $"The {this.Species} is a {this.Diet} and weighs {this.Weight} kg.";
    }
}

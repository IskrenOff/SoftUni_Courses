using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;

        private string name;
        private int capacity;

        public Zoo()
        {
            this.animals = new List<Animal>();
        }
        public Zoo(string name, int capacity) : this()
        {
            this.name = name;
            this.capacity = capacity;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
		public List<Animal> Animals
        {
			get => this.animals;
			private set {}
			
        }

		public string AddAnimal(Animal animal)
		{
			if (string.IsNullOrWhiteSpace(animal.Species))
			{
				return "Invalid animal species.";
			}
			else if (!((animal.Diet.ToLower().Equals("herbivore")) || (animal.Diet.ToLower().Equals("carnivore"))))
			{
				return "Invalid animal diet.";
			}
			else if (this.Capacity.Equals(this.animals.Count))
			{
				return "The zoo is full.";
			}

			this.animals.Add(animal);
			return $"Successfully added {animal.Species} to the zoo.";
		}

		public IEnumerable<Animal> GetAnimalsByDiet(string diet)
		{
			return this.animals.Where(x => x.Diet == diet).ToList();
		}

		public Animal GetAnimalByWeight(double weight)
		{
			return this.animals.FirstOrDefault(x => x.Weight == weight);
		}

		public string GetAnimalCountByLength(double minimumLength, double maximumLength)
		{
			List<Animal> countList = this.animals.Where(x => (x.Length >= minimumLength) && (x.Length <= maximumLength)).ToList();
			return $"There are {countList.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
		}

		public int RemoveAnimals(string species)
		{
			List<Animal> newAnumals = this.animals.Where(x => x.Species != species).ToList();
			int result = this.animals.Count - newAnumals.Count;
			this.animals = newAnumals;
			return result;
		}
	}
}

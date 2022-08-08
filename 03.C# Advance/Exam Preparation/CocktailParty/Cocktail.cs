using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    internal class Cocktail
    {
        private List<Ingredient> ingredients;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingredients = new List<Ingredient>();
        }

        public int CurrentAlcoholLevel => ingredients.Sum(x => x.Alcohol);
        public void Add(Ingredient ingredient)
        {
            if (!ingredients.Contains(ingredients.Find(x => x.Name == ingredient.Name)) &&
                CurrentAlcoholLevel + ingredient.Alcohol <= MaxAlcoholLevel)
            {
                ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            Ingredient toRemove = ingredients.FirstOrDefault(x => x.Name == name);

            if (toRemove == null)
            {
                return false;
            }
            ingredients.Remove(toRemove);
            return true;
        }
        public Ingredient FindIngredient(string name)
        {
            return ingredients.FirstOrDefault(x => x.Name == name);
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            int mostAlcohol = ingredients.Select(x => x.Alcohol).Max();
            var max = ingredients.Find(ingredients => ingredients.Alcohol == mostAlcohol);
            return max;
        }
        public string Report()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in ingredients)
            {
                output.AppendLine(ingredient.ToString());
            }
            return output.ToString().TrimEnd();
        }
    }
}

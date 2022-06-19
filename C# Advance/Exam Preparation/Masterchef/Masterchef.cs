using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    internal class Masterchef
    {
        static void Main(string[] args)
        {
            Queue<int> ingredientsValues = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            Stack<int> freshnessValues = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            Dictionary<string, int> dishes = new Dictionary<string, int>();

            while (ingredientsValues.Count != 0 && freshnessValues.Count != 0)
            {
                int totalFreshnessLevel = ingredientsValues.Peek() * freshnessValues.Peek();

                if (totalFreshnessLevel == 150)
                {
                    if (!dishes.ContainsKey("Dipping sauce"))
                    {
                        dishes.Add("Dipping sauce",1);
                    }
                    else
                    {
                        dishes["Dipping sauce"]++;
                    }
                    ingredientsValues.Dequeue();
                    freshnessValues.Pop();
                }
                else if (totalFreshnessLevel == 250)
                {
                    if (!dishes.ContainsKey("Green salad"))
                    {
                        dishes.Add("Green salad", 1);
                    }
                    else
                    {
                        dishes["Green salad"]++;
                    }
                    ingredientsValues.Dequeue();
                    freshnessValues.Pop();
                }
                else if (totalFreshnessLevel == 300)
                {
                    if (!dishes.ContainsKey("Chocolate cake"))
                    {
                        dishes.Add("Chocolate cake", 1);
                    }
                    else
                    {
                        dishes["Chocolate cake"]++;
                    }
                    ingredientsValues.Dequeue();
                    freshnessValues.Pop();
                }
                else if (totalFreshnessLevel == 400)
                {
                    if (!dishes.ContainsKey("Lobster"))
                    {
                        dishes.Add("Lobster", 1);
                    }
                    else
                    {
                        dishes["Lobster"]++;
                    }
                    ingredientsValues.Dequeue();
                    freshnessValues.Pop();
                }
                else
                {
                    if (ingredientsValues.Peek() == 0)
                    {
                        ingredientsValues.Dequeue();
                        continue;
                    }
                    int token = ingredientsValues.Dequeue() + 5;
                    freshnessValues.Pop();
                    ingredientsValues.Enqueue(token);
                }
            }

            if (dishes.Keys.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
                if (ingredientsValues.Count > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredientsValues.Sum()}");
                }
                foreach (var dish in dishes.OrderBy(x => x.Key))
                {
                    Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                }
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
                if (ingredientsValues.Count > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredientsValues.Sum()}");
                }
                foreach (var dish in dishes.OrderBy(x => x.Key))
                {
                    Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                }
            }
        }
    }
}

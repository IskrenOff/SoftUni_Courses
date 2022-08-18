using System;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string separator = ", ";

            Queue<int> coffeeQuantities = new Queue<int>
                (Console.ReadLine()
                .Split(separator,StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> milkQuantities = new Stack<int>
                (Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string,int> recipes = new Dictionary<string, int>()
            {
                {"Cortado", 50},
                {"Espresso", 75},
                {"Capuccino", 100},
                {"Americano", 150},
                {"Latte", 200},
            };

            Dictionary<string, int> drinks = new Dictionary<string, int>();

            while (coffeeQuantities.Any() && milkQuantities.Any() )
            {
                int quantity = coffeeQuantities.Peek() + milkQuantities.Peek();

                if (quantity == 50)
                {
                    coffeeQuantities.Dequeue();
                    milkQuantities.Pop();

                    if (!drinks.ContainsKey("Cortado"))
                    {
                        drinks.Add("Cortado", 1);
                    }
                    else
                    {
                        drinks["Cortado"]++;
                    }
                }
                else if (quantity == 75)
                {
                    coffeeQuantities.Dequeue();
                    milkQuantities.Pop();

                    if (!drinks.ContainsKey("Espresso"))
                    {
                        drinks.Add("Espresso", 1);
                    }
                    else
                    {
                        drinks["Espresso"]++;
                    }
                }
                else if (quantity == 100)
                {
                    coffeeQuantities.Dequeue();
                    milkQuantities.Pop();

                    if (!drinks.ContainsKey("Capuccino"))
                    {
                        drinks.Add("Capuccino", 1);
                    }
                    else
                    {
                        drinks["Capuccino"]++;
                    }
                }
                else if (quantity == 150)
                {
                    coffeeQuantities.Dequeue();
                    milkQuantities.Pop();

                    if (!drinks.ContainsKey("Americano"))
                    {
                        drinks.Add("Americano", 1);
                    }
                    else
                    {
                        drinks["Americano"]++;
                    }
                }
                else if (quantity == 200)
                {
                    coffeeQuantities.Dequeue();
                    milkQuantities.Pop();

                    if (!drinks.ContainsKey("Latte"))
                    {
                        drinks.Add("Latte", 1);
                    }
                    else
                    {
                        drinks["Latte"]++;
                    }
                }
                else
                {
                    coffeeQuantities.Dequeue();
                    int token = milkQuantities.Pop();
                    milkQuantities.Push(token - 5);
                }
            }

            if (coffeeQuantities.Count == 0 && milkQuantities.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
                Console.WriteLine("Coffee left: none");
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");

                if (coffeeQuantities.Count == 0)
                {
                    Console.WriteLine("Coffee left: none");
                }
                else
                {
                    Console.WriteLine($"Coffee left: {string.Join(", ",coffeeQuantities)}");
                }
                if (milkQuantities.Count == 0)
                {
                    Console.WriteLine("Milk left: none");
                }
                else
                {
                    Console.WriteLine($"Milk left: {string.Join(", ", milkQuantities)}");
                }
            }

            foreach (var item in drinks.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}

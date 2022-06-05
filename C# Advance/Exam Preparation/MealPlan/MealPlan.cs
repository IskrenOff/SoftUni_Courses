using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    internal class MealPlan
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mealsCalories = new Dictionary<string, int>
            {
                    {"salad", 350},
                    {"soup", 490},
                    {"pasta", 680},
                    {"steak", 790}
            };

            Queue<string> meals = new Queue<string>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries));

            Stack<int> caloriesStackPerDay = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int mealsCnt = meals.Count;

            while ((meals.Count > 0) && (caloriesStackPerDay.Count > 0))
            {
                int currentCallories = caloriesStackPerDay.Pop();

                int currentMealCallories = mealsCalories[meals.Peek()];

                if (currentCallories - currentMealCallories >= 0)
                {
                    currentCallories -= currentMealCallories;
                    meals.Dequeue();
                    caloriesStackPerDay.Push(currentCallories);
                }
                else if (caloriesStackPerDay.Count > 0)
                {
                    currentCallories -= currentMealCallories;
                    currentCallories += caloriesStackPerDay.Pop();
                    if (currentCallories > 0)
                    {
                        caloriesStackPerDay.Push(currentCallories);
                        meals.Dequeue();
                    }

                    if (caloriesStackPerDay.Count == 0)
                    {
                        meals.Dequeue();
                    }
                }
                else
                {
                    if (caloriesStackPerDay.Count == 0)
                    {
                        meals.Dequeue();
                    }
                }
            }

            if (caloriesStackPerDay.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {mealsCnt} meals.\nMeals left: {string.Join(", ", meals)}.");
            }
            else
            {
                Console.WriteLine($"John had {mealsCnt} meals.\nFor the next few days, he can eat {string.Join(", ", caloriesStackPerDay)} calories.");
            }
        }      
    }
}

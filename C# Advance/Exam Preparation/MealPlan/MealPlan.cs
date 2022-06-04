using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    internal class MealPlan
    {
        static void Main(string[] args)
        {
            List<string> meals = Console.ReadLine().Split(' ').ToList();
            int[] caloriesPerDay = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Dictionary<string, int> mealsData = new Dictionary<string, int>
            {
                {"salad" , 350},
                {"soup" , 490},
                {"pasta" , 680},
                {"steak" , 790},
            };

            // Fill the Stack with calories intake per day
            Stack<int> caloriesStackPerDay = new Stack<int>(caloriesPerDay);

            for (int i = 0; i < meals.Count; i++)
            {
                switch (meals[i])
                {
                    case "salad":
                        int currentCalories = caloriesStackPerDay.Pop();
                        
                        if (currentCalories >= mealsData[meals[i]])
                        {
                            currentCalories -= mealsData[meals[i]];
                        }
                        else if (currentCalories < mealsData[meals[i]])
                        {
                            currentCalories = mealsData[meals[i]] - currentCalories;
                        }
                        else if (currentCalories <= 0)
                        {
                            mealsData[meals[i]] -= currentCalories;

                            if (mealsData[meals[i]] <= 0)
                            {
                                mealsData.Remove(meals[i]);
                            }
                        }
                        else
                        {
                            caloriesStackPerDay.Push(currentCalories);
                        }
                        break;
                    case "soup":
                        int currentCalories2 = caloriesStackPerDay.Pop();

                        if (currentCalories2 >= mealsData[meals[i]])
                        {
                            currentCalories2 -= mealsData[meals[i]];
                        }
                        else if (currentCalories2 < mealsData[meals[i]])
                        {
                            currentCalories2 = mealsData[meals[i]] - currentCalories2;
                        }
                        else if (currentCalories2 <= 0)
                        {
                            mealsData[meals[i]] -= currentCalories2;

                            if (mealsData[meals[i]] <= 0)
                            {
                                mealsData.Remove(meals[i]);
                            }
                        }
                        else
                        {
                            caloriesStackPerDay.Push(currentCalories2);
                        }
                        break;
                    case "pasta":
                        break;
                    case "steak":
                        int currentCalories3 = caloriesStackPerDay.Pop();

                        if (currentCalories3 >= mealsData[meals[i]])
                        {
                            currentCalories3 -= mealsData[meals[i]];
                        }
                        else if (currentCalories3 < mealsData[meals[i]])
                        {
                            currentCalories = mealsData[meals[i]] - currentCalories3;
                        }
                        else if (currentCalories3 <= 0)
                        {
                            mealsData[meals[i]] -= currentCalories3;

                            if (mealsData[meals[i]] <= 0)
                            {
                                mealsData.Remove(meals[i]);
                            }
                        }
                        else
                        {
                            caloriesStackPerDay.Push(currentCalories3);
                        }
                        break;
                }
            }
        }
    }
}

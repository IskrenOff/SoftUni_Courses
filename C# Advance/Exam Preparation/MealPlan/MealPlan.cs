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

            int mealsCnt = 0;

            // Fill the Stack with calories intake per day
            Stack<int> caloriesStackPerDay = new Stack<int>(caloriesPerDay);

            for (int i = 0; i < meals.Count; i++)
            {
                switch (meals[i])
                {
                    case "salad":
                        int currentCalories = caloriesStackPerDay.Pop();
                        currentCalories -= mealsData[meals[i]];
                        
                        if (currentCalories < mealsData[meals[i]])
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
                        JohnCalories(mealsData,caloriesStackPerDay,meals);
                        break;
                    case "pasta":
                        break;
                    case "steak":
                        
                        break;
                }
            }
        }

        public static void JohnCalories(Dictionary<string, int> mealsData, Stack<int> caloriesStackPerDay, List<string> meals)
        {
            for (int i = 0; i < meals.Count; i++)
            {
                int currentCalories = caloriesStackPerDay.Pop();


            }
        }
    }
}

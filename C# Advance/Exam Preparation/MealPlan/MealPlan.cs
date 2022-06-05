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
            // Calories per meal
            int salad = 350;
            int soup = 490;
            int pasta = 680;
            int steak = 790;
            // Meals counter
            int mealsCnt = 0;

            // Fill the Stack with calories intake per day
            Stack<int> caloriesStackPerDay = new Stack<int>(caloriesPerDay);

            for (int i = 0; i < meals.Count; i++)
            {
                switch (meals[i])
                {
                    case "salad":
                        int currentCalories = caloriesStackPerDay.Pop();
                        if (currentCalories >= salad)
                        {
                            currentCalories -= salad;
                            mealsCnt ++;
                            meals.Remove(meals[i]);
                            i--;

                            if (currentCalories > 0)
                            {
                                caloriesStackPerDay.Push(currentCalories);
                            }
                        }
                        else
                        {
                            mealsCnt ++;
                            salad -= currentCalories;
                            if (caloriesStackPerDay.Count > 0)
                            {
                                currentCalories = caloriesStackPerDay.Pop() - salad;
                                caloriesStackPerDay.Push(currentCalories);
                            }
                            meals.Remove(meals[i]);
                            i--;
                        }
                        
                        break;
                    case "soup":
                        int currentCalories2 = caloriesStackPerDay.Pop();
                        if (currentCalories2 >= soup)
                        {
                            currentCalories2 -= soup;
                            mealsCnt++;
                            meals.Remove(meals[i]);
                            i--;

                            if (currentCalories2 > 0)
                            {
                                caloriesStackPerDay.Push(currentCalories2);
                            }
                        }
                        else
                        {
                            mealsCnt++;
                            soup -= currentCalories2;
                            if (caloriesStackPerDay.Count > 0)
                            {
                                currentCalories = caloriesStackPerDay.Pop() - soup;
                                caloriesStackPerDay.Push(currentCalories);
                            }
                            meals.Remove(meals[i]);
                            i--;
                        }
                        break;
                    case "pasta":
                        int currentCalories3 = caloriesStackPerDay.Pop();
                        if (currentCalories3 >= pasta)
                        {
                            currentCalories3 -= pasta;
                            mealsCnt++;
                            meals.Remove(meals[i]);
                            i--;

                            if (currentCalories3 > 0)
                            {
                                caloriesStackPerDay.Push(currentCalories3);
                            }
                        }
                        else
                        {
                            mealsCnt++;
                            pasta -= currentCalories3;
                            if (caloriesStackPerDay.Count > 0)
                            {
                                currentCalories = caloriesStackPerDay.Pop() - pasta;
                                caloriesStackPerDay.Push(currentCalories);
                            }
                            meals.Remove(meals[i]);
                            i--;
                        }
                        break;
                    case "steak":
                        int currentCalories4 = caloriesStackPerDay.Pop();
                        if (currentCalories4 >= steak)
                        {
                            currentCalories4 -= steak;
                            mealsCnt++;
                            meals.Remove(meals[i]);
                            i--;

                            if (currentCalories4 > 0)
                            {
                                caloriesStackPerDay.Push(currentCalories4);
                            }
                        }
                        else
                        {
                            mealsCnt++;
                            steak -= currentCalories4;
                            if (caloriesStackPerDay.Count > 0)
                            {
                                currentCalories = caloriesStackPerDay.Pop() - steak;
                                caloriesStackPerDay.Push(currentCalories);
                            }
                            meals.Remove(meals[i]);
                            i--;
                        }
                        break;
                }
                if (meals.Count == 0 || caloriesStackPerDay.Count == 0)
                {
                    break;
                }
            }

            if (caloriesStackPerDay.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {mealsCnt} meals.\nMeals left: {string.Join(", ",meals)}.");
            }
            else
            {
                Console.WriteLine($"John had {mealsCnt} meals.\nFor the next few days, he can eat {string.Join(", ",caloriesStackPerDay)} calories.");
            }
        }      
    }
}

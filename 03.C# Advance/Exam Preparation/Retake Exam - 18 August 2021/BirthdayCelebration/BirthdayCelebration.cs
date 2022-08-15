using System;
using System.Linq;
using System.Collections.Generic;

namespace BirthdayCelebration
{
    internal class BirthdayCelebration
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            Stack<int> platesOffood = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            int wastedFood = 0;

            while (guests.Any() && platesOffood.Any())
            {
                int currentGuest = guests.Peek();
                int currentPlate = platesOffood.Peek();

                while (currentGuest > 0 && platesOffood.Any())
                {
                    currentGuest -= platesOffood.Pop();
                }

                if (currentGuest < 0)
                {
                    wastedFood += currentGuest;
                    guests.Dequeue();
                }
                else if (currentGuest == 0)
                {
                    guests.Dequeue();
                }
            }

            Console.WriteLine(platesOffood.Any()
                ? $"Plates: {string.Join(" ", platesOffood)}"
                : $"Guests: {string.Join(" ", guests)}");
            Console.WriteLine($"Wasted grams of food: {Math.Abs(wastedFood)}");
        }
    }
}

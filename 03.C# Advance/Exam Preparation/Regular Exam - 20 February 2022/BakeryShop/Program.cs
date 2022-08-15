using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Croissant – consists of 50 % water and 50 % flour
            // Muffin – consists of 40 % water and 60 % flour
            // Baguette – consists of 30 % water and 70 % flour
            // Bagel – consists of 20 % water and 80 % flour

            Dictionary<string, int> showcaseOnBakery = new Dictionary<string, int>()
            {
                {"Croissant", 0 },
                {"Muffin" , 0},
                {"Baguette", 0},
                {"Bagel", 0}
            };

            Queue<double> waterStorage = new Queue<double>  // Storage for water supplies
                (Console.ReadLine()
                .Split(' ')
                .Select(double.Parse));
            Stack<double> flourStorage = new Stack<double>  // Storage for flour supplies
                (Console.ReadLine()
                .Split(' ')
                .Select(double.Parse));

            while (waterStorage.Count > 0 && flourStorage.Count > 0)
            {
                double water = waterStorage.Peek();
                double flour = flourStorage.Peek();
                double result = water + flour;
                double[] waterAndFlouerRatio = new double[2];
                waterAndFlouerRatio[0] = (water / result) * 100;
                waterAndFlouerRatio[1] = (flour / result) * 100;

                if (waterAndFlouerRatio[0] == 50 && waterAndFlouerRatio[1] == 50)
                {
                    showcaseOnBakery["Croissant"]++;
                    waterStorage.Dequeue();
                    flourStorage.Pop();
                }
                else if (waterAndFlouerRatio[0] == 40 && waterAndFlouerRatio[1] == 60)
                {
                    showcaseOnBakery["Muffin"]++;
                    waterStorage.Dequeue();
                    flourStorage.Pop();
                }
                else if (waterAndFlouerRatio[0] == 30 && waterAndFlouerRatio[1] == 70)
                {
                    showcaseOnBakery["Baguette"]++;
                    waterStorage.Dequeue();
                    flourStorage.Pop();
                }
                else if (waterAndFlouerRatio[0] == 20 && waterAndFlouerRatio[1] == 80)
                {
                    showcaseOnBakery["Bagel"]++;
                    waterStorage.Dequeue();
                    flourStorage.Pop();
                }
                else
                {
                    double currentWater = waterStorage.Dequeue();
                    double currentFlour = flourStorage.Pop();
                    double waterAndFlourDiff = currentFlour - currentWater;
                    showcaseOnBakery["Croissant"]++;
                    flourStorage.Push(waterAndFlourDiff);
                }
            }

            foreach (var product in showcaseOnBakery.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
            }
            if (waterStorage.Count > 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ",waterStorage)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flourStorage.Count > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ",flourStorage)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLinesInput = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfLinesInput; i++)
            {
                string[] clothesData = Console.ReadLine().Split(" -> ");
                string color = clothesData[0];
                string[] clothes = clothesData[1].Split(',');


                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 1);
                    }
                    else
                    {
                        wardrobe[color][item]++;
                    }
                }
              
            }

            string[] searchData = Console.ReadLine()
                .Split(' ');

            string searchColor = searchData[0];
            string searchClothe = searchData[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                Dictionary<string, int> clothes = color.Value;

                foreach (var cloth in clothes)
                {
                    if (cloth.Key == searchClothe && color.Key == searchColor)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}

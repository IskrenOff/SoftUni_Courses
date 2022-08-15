using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    internal class Lootbox
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> claimetItems = new Dictionary<string, int>()
            {
                {"Loot", 0}
            };

            while (firstLootBox.Count != 0 && secondLootBox.Count != 0)
            {
                int sum = firstLootBox.Peek() + secondLootBox.Peek();

                if (sum % 2 == 0)
                {
                    claimetItems["Loot"] += sum;
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else
                {
                    int tmp = secondLootBox.Pop();
                    firstLootBox.Enqueue(tmp);
                }
            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (claimetItems.Values.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimetItems.Values.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimetItems.Values.Sum()}");
            }
        }
    }
}

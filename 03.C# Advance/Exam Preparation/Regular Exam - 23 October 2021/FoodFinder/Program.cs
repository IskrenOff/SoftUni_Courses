using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> vowelsCollection = new Queue<string>(Console.ReadLine().Split(' '));
            Stack<string> consonantsCollection = new Stack<string>(Console.ReadLine().Split(' '));

            Dictionary<string, List <string>> map = new Dictionary<string, List<string>>()
            {
                {"pear", new List<string> {"p","e","a","r"}},
                {"flour", new List<string> {"f","l","o","u","r"}},
                {"pork", new List<string> {"p","o","r","k"}},
                {"olive", new List<string> {"o","l","i","v","e"}},
            };


            while (consonantsCollection.Count != 0)
            {
                string vowel = vowelsCollection.Dequeue();
                string consonants = consonantsCollection.Pop();

                foreach (var item in map)
                {
                    if (item.Value.Contains(vowel))
                    {
                        item.Value.Remove(vowel);
                    }
                    if (item.Value.Contains(consonants))
                    {
                        item.Value.Remove(consonants);
                    }
                    vowelsCollection.Enqueue(vowel);
                }
            }
            int cnt = 0;
            foreach (var item in map)
            {
                if (item.Value.Count == 0)
                {
                    cnt++;
                }
            }
            Console.WriteLine($"Words found: {cnt}");

            foreach (var item in map)
            {
                if (item.Value.Count == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }

        }
    }
}

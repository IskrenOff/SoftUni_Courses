using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            
            int n = input[0];  //Length of  first set
            int m = input[1];  //Length of second set

            HashSet <int> firtsSet = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                firtsSet.Add(int.Parse(Console.ReadLine()));
            }

            HashSet <int> secondSet = new HashSet<int>();
            for (int i = 0; i < m; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firtsSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firtsSet));
        }
    }
}

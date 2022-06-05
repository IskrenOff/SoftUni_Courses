using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    internal class PeriodicTable
    {
        static void Main(string[] args)
        {
            int numberOfElements = int.Parse(Console.ReadLine());

            SortedSet<string> setOfElements = new SortedSet<string>();

            for (int i = 0; i < numberOfElements; i++)
            {
                string[] elements = Console.ReadLine().Split(' ');

                for (int j = 0; j < elements.Length; j++)
                {
                    setOfElements.Add(elements[j]);
                }
            }

            Console.WriteLine(string.Join(" ",setOfElements));
        }
    }
}

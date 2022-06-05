using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    internal class EvenTimes
    {
        static void Main(string[] args)
        {
            int cntOfIntegers = int.Parse(Console.ReadLine());

            Dictionary<int, int> integerCollection = new Dictionary<int, int>();

            for (int i = 0; i < cntOfIntegers; i++)
            {
                int integer = int.Parse(Console.ReadLine());

                if (!integerCollection.ContainsKey(integer))
                {
                    integerCollection.Add(integer, 1);
                }
                else
                {
                    integerCollection[integer]++;
                }
            }

            foreach (var item in integerCollection)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}

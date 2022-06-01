using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    internal class CustomMinFunction
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> smallestNumber = number => numbers.Min();
            Console.WriteLine(smallestNumber(numbers));
        }
    }
}

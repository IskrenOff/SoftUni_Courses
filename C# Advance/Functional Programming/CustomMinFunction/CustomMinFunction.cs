using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    internal class CustomMinFunction
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            Func<int , int> smallestNumber = number => input.Min();
            Console.WriteLine(smallestNumber);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    internal class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            // ADD 1 to each number
            Func<List<int>, List<int>> add = list => list.Select(number => number += 1).ToList();

            // MULTIPLY each number by 2
            Func<List<int> , List<int>> multiply = list => list.Select(number => number *= 2).ToList();

            // SUBTRACT 1 from each number
            Func<List<int>, List<int>> subtract = list => list.Select(numbers => numbers -= 1).ToList();

            // PRINT the collection
            Action<List<int>> print = list => Console.WriteLine(string.Join(" ", list));

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }


                command = Console.ReadLine();
            }
        }
    }
}

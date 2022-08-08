using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    internal class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int startNumber = int.Parse(input.Split(' ')[0]);
            int endNumber = int.Parse(input.Split(' ')[1]);

            List<int> numbers = new List<int>();

            for (int number = startNumber; number <= endNumber; number++)
            {
                numbers.Add(number);
            }

            string type = Console.ReadLine();

            Predicate<int> predicate = null;

            switch (type)
            {
                case "even":
                    predicate = number => number % 2 == 0;
                    break;
                case "odd":
                    predicate = number => number % 2 != 0;
                    break;
            }

            Console.WriteLine(string.Join(" ", numbers.FindAll(predicate)));
        }
    }
}

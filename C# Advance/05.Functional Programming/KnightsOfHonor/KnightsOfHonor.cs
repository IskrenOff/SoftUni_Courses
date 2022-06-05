using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsOfHonor
{
    internal class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(' ').ToList();

            Action<string> print = name => Console.WriteLine("Sir " + name);
            list.ForEach(print);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionPoint
{
    internal class ActionPoint
    {
        static void Main(string[] args)
        {
            // Split the first line from console
            List<string> list = Console.ReadLine().Split(' ').ToList();

            Action<string> printName = name => Console.WriteLine(name);
            list.ForEach(printName);
        }
    }
}

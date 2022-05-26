using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersOfUsernames = int.Parse(Console.ReadLine());

            HashSet <string> usernames = new HashSet<string>();

            for (int i = 0; i < numbersOfUsernames; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine,usernames));
        }
    }
}

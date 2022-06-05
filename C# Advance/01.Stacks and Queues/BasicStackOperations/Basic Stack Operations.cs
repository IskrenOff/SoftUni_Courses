using System;
using System.Collections.Generic;
using System.Linq;


namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] comands = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int n = comands[0];
            int s = comands[1];
            int x = comands[2];

            Stack<int> stack = new Stack<int>();
            
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)  
                .ToArray();

            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}

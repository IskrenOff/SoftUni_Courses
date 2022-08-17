using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    internal class Scheduling
    {
        static void Main()
        {
            string separator = ", ";

            Stack<int> taskValues = new Stack<int>
                (Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> threadValues = new Queue<int>
                (Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int target = int.Parse(Console.ReadLine());


            while (true)
            {
                int task = taskValues.Peek();
                int thread = threadValues.Peek();

                if (target == task)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {target}");
                    Console.WriteLine(string.Join(' ', threadValues));
                    break;
                }
                else if (task > thread)
                {
                    threadValues.Dequeue();
                }
                else
                { 
                    taskValues.Pop();
                    threadValues.Dequeue();
                }
            }
        }
    }
}

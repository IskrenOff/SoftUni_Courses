using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    internal class WarmWinter
    {
        static void Main(string[] args)
        {
            Stack<int> hatsCollection = new Stack<int>(Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> scarvesCollection = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int setSum = 0;

            List<int> sets = new List<int>();

            while (hatsCollection.Count != 0 && scarvesCollection.Count != 0)
            {
                int hat = hatsCollection.Peek();
                int scarf = scarvesCollection.Peek();

                if (hat > scarf)
                {
                    setSum = hat + scarf;
                    sets.Add(setSum);
                    hatsCollection.Pop();
                    scarvesCollection.Dequeue();
                }
                else if (hat < scarf)
                {
                    hatsCollection.Pop();
                }
                else if (hat == scarf)
                {
                    int tmp = hatsCollection.Pop() + 1;
                    hatsCollection.Push(tmp);
                    scarvesCollection.Dequeue();
                }
            }

            int mostExpensivSet = int.MinValue;

            for (int i = 0; i < sets.Count; i++)
            {
                if (sets[i] > mostExpensivSet)
                {
                        mostExpensivSet = sets[i];
                }
            }

            Console.WriteLine($"The most expensive set is: {mostExpensivSet}");
            Console.WriteLine(string.Join(' ',sets));
        }
    }
}

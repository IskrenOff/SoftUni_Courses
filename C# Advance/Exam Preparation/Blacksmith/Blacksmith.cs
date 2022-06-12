using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Blacksmith
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            // Collection for all swords and resources needed to forge them
            Dictionary<string, int> swordsResources = new Dictionary<string, int>()
            {
                {"Gladius", 70},
                {"Shamshir", 80},
                {"Katana", 90},
                {"Sabre", 110},
                {"Broadsword", 150}
            };

            // Collection to take all forged swords
            Dictionary<string, int> forgedSwords = new Dictionary<string, int>();

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int resourcesForSword = steel.Peek() + carbon.Peek();

                if (resourcesForSword == 70)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    if (!forgedSwords.ContainsKey("Gladius"))
                    {
                        forgedSwords.Add("Gladius", 1);
                    }
                    else
                    {
                        forgedSwords["Gladius"]++;
                    }                   
                }
                else if (resourcesForSword == 80)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    if (!forgedSwords.ContainsKey("Shamshir"))
                    {
                        forgedSwords.Add("Shamshir", 1);
                    }
                    else
                    {
                        forgedSwords["Shamshir"]++;
                    }
                }
                else if (resourcesForSword == 90)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    if (!forgedSwords.ContainsKey("Katana"))
                    {
                        forgedSwords.Add("Katana", 1);
                    }
                    else
                    {
                        forgedSwords["Katana"]++;
                    }
                }
                else if (resourcesForSword == 110)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    if (!forgedSwords.ContainsKey("Sabre"))
                    {
                        forgedSwords.Add("Sabre", 1);
                    }
                    else
                    {
                        forgedSwords["Sabre"]++;
                    }
                }
                else if (resourcesForSword == 150)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    if (!forgedSwords.ContainsKey("Broadsword"))
                    {
                        forgedSwords.Add("Broadsword", 1);
                    }
                    else
                    {
                        forgedSwords["Broadsword"]++;
                    }
                }
                else
                {
                    steel.Dequeue();
                    int token = carbon.Pop();
                    carbon.Push(token + 5);
                }
            }

            if (forgedSwords.Count > 0)
            {
                Console.WriteLine($"You have forged {forgedSwords.Values.Sum()} swords.");
                if (steel.Count == 0)
                {
                    Console.WriteLine("Steel left: none");
                }
                else
                {
                    Console.WriteLine($"Steel left: {string.Join(", ",steel)}");
                }
                if (carbon.Count == 0)
                {
                    Console.WriteLine("Carbon left: none");
                }
                else
                {
                    Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
                }
                foreach (var sword in forgedSwords.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
                if (steel.Count == 0)
                {
                    Console.WriteLine("Steel left: none");
                }
                else
                {
                    Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
                }
                if (carbon.Count == 0)
                {
                    Console.WriteLine("Carbon left: none");
                }
                else
                {
                    Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class TilesMaster
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> locations = new Dictionary<string, int>(); 

            while (whiteTiles.Count != 0 && greyTiles.Count != 0)
            {
                int whiteTileArea = whiteTiles.Peek();
                int greyTileArea = greyTiles.Peek();

                if (whiteTileArea + greyTileArea == 40 && whiteTileArea == greyTileArea)
                {
                    if (!locations.ContainsKey("Sink"))
                    {
                        locations.Add("Sink", 1);
                    }
                    else
                    {
                        locations["Sink"]++;
                    }
                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
                else if (whiteTileArea + greyTileArea == 50 && whiteTileArea == greyTileArea)
                {
                    if (!locations.ContainsKey("Oven"))
                    {
                        locations.Add("Oven", 1);
                    }
                    else
                    {
                        locations["Oven"]++;
                    }
                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
                else if (whiteTileArea + greyTileArea == 60 && whiteTileArea == greyTileArea)
                {
                    if (!locations.ContainsKey("Countertop"))
                    {
                        locations.Add("Countertop", 1);
                    }
                    else
                    {
                        locations["Countertop"]++;
                    }
                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
                else if (whiteTileArea + greyTileArea == 70 && whiteTileArea == greyTileArea)
                {
                    if (!locations.ContainsKey("Wall"))
                    {
                        locations.Add("Wall", 1);
                    }
                    else
                    {
                        locations["Wall"]++;
                    }
                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
                else if (whiteTileArea != greyTileArea)
                {
                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                    whiteTileArea = whiteTileArea / 2;
                    whiteTiles.Push(whiteTileArea);
                    greyTiles.Enqueue(greyTileArea);
                }
                else
                {
                    if (!locations.ContainsKey("Floor"))
                    {
                        locations.Add("Floor", 1);
                    }
                    else
                    {
                        locations["Floor"]++;
                    }
                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ",whiteTiles)}");
            }
            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            foreach (var homeLocations in locations.OrderByDescending(x => x.Value).ThenBy(c => c.Key))
            {
                Console.WriteLine($"{homeLocations.Key}: {homeLocations.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    internal class CountSymbols
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine()
                .ToCharArray();

            SortedDictionary<char, int> dictionaryOfSymbols = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!dictionaryOfSymbols.ContainsKey(text[i]))
                {
                    dictionaryOfSymbols.Add(text[i], 1);
                }
                else
                {
                    dictionaryOfSymbols[text[i]]++;
                }
            }

            foreach (var symbol in dictionaryOfSymbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}

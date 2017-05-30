using System;
using System.Collections.Generic;

namespace E04_CountSymbols
{
    public class CountSymbols
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            var symbolCounts = new SortedDictionary<char, int>();
            foreach (var symbol in text)
            {
                if (!symbolCounts.ContainsKey(symbol))
                {
                    symbolCounts[symbol] = 0;
                }
                symbolCounts[symbol]++;
            }
            foreach (var kvp in symbolCounts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}

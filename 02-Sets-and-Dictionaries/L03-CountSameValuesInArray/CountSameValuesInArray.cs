using System;
using System.Collections.Generic;
using System.Linq;

namespace L03_CountSameValuesInArray
{
    public class CountSameValuesInArray
    {
        public static void Main()
        {
            var counts = GetNumberCounts();
            PrintCounts(counts);
        }

        private static void PrintCounts(SortedDictionary<decimal, int> counts)
        {
            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }

        private static SortedDictionary<decimal, int> GetNumberCounts()
        {
            var numbers = Console.ReadLine()
                         .Trim()
                         .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                         .Select(decimal.Parse)
                         .ToArray();
            var counts = new SortedDictionary<decimal, int>();
            foreach (var number in numbers)
            {
                if (!counts.ContainsKey(number))
                {
                    counts[number] = 0;
                }
                counts[number]++;
            }

            return counts;
        }
    }
}

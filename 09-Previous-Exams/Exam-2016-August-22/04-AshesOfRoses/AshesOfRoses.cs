using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04_AshesOfRoses
{
    public class AshesOfRoses
    {
        public static void Main()
        {
            var roseGrowingRegions = GetRoseGrowingRegions();
            PrintRoses(roseGrowingRegions);
        }

        private static void PrintRoses(SortedDictionary<string, SortedDictionary<string, long>> roseGrowingRegions)
        {
            var orderedRegions = roseGrowingRegions
                                .OrderByDescending(r => r.Value.Values.Sum()); // total roses
            foreach (var region in orderedRegions)
            {
                Console.WriteLine(region.Key); // region
                region.Value
                      .OrderBy(c => c.Value) // roses per color
                      .ToList()
                      .ForEach(c => Console.WriteLine($"*--{c.Key} | {c.Value}")); // color, amount
            }
        }

        private static SortedDictionary<string, SortedDictionary<string, long>> GetRoseGrowingRegions()
        {
            var roseGrowigRegions = new SortedDictionary<string, SortedDictionary<string, long>>();
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Icarus, Ignite!") break;

                // Input Validation
                var pattern = "^Grow <(?<r>[A-Z][a-z]+)> <(?<c>[A-Za-z0-9]+)> (?<a>[0-9]+)$";
                if (!Regex.IsMatch(input, pattern)) continue;

                var match = Regex.Match(input, pattern);
                var region = match.Groups["r"].Value;
                var color = match.Groups["c"].Value;
                var amount = long.Parse(match.Groups["a"].Value);

                // Alternative Validation
                //if (!IsValidInput(input)) continue;
                //var tokens = input
                //            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                //            .Skip(1)
                //            .Select(x => x.Trim('<').Trim('>'))
                //            .ToList();
                //var region = tokens[0];
                //var color = tokens[1];
                //var amount = long.Parse(tokens[2]);

                if (!roseGrowigRegions.ContainsKey(region))
                {
                    roseGrowigRegions[region] = new SortedDictionary<string, long>();
                }
                if (!roseGrowigRegions[region].ContainsKey(color))
                {
                    roseGrowigRegions[region][color] = 0;
                }
                roseGrowigRegions[region][color] += amount;
            }
            return roseGrowigRegions;
        }

        private static bool IsValidInput(string input)
        {
            if (!input.StartsWith("Grow ")) return false;

            var tokens = Regex.Split(input, " ")
                        .Skip(1)
                        .ToList();
            if (tokens.Count != 3) return false;

            var region = tokens[0];
            var color = tokens[1];
            long amount;
            var isNumber = long.TryParse(tokens[2], out amount);

            return  Regex.IsMatch(region, "^<[A-Z][a-z]+>$") &&
                    Regex.IsMatch(color, "^<[A-Za-z0-9]+>$") &&
                    isNumber;
        }
    }
}

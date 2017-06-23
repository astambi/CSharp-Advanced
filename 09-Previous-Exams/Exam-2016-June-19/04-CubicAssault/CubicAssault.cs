using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_CubicAssault
{
    public class CubicAssault
    {
        public const int convertedAmount = 1000000;

        public static void Main()
        {
            var meteors = GetMeteors();
            PrintMeteors(meteors);
        }

        private static void PrintMeteors(SortedDictionary<string, SortedDictionary<string, long>> meteors)
        {
            var regions = meteors
                .Select(m => new
                {
                    RegionName = m.Key,
                    BlackMeteors = m.Value["Black"]
                })
                .OrderByDescending(r => r.BlackMeteors)
                .ThenBy(r => r.RegionName.Length); // sorted dictionary
            foreach (var r in regions)
            {
                Console.WriteLine(r.RegionName);
                meteors[r.RegionName]
                    .OrderByDescending(t => t.Value) // sorted dictionary
                    .ToList()
                    .ForEach(t => Console.WriteLine($"-> {t.Key} : {t.Value}"));
            }
        }

        private static SortedDictionary<string, SortedDictionary<string, long>> ConvertMeteors(SortedDictionary<string, SortedDictionary<string, long>> meteors, string region, string meteorType)
        {
            var conversionTable = new Dictionary<string, string>();
            conversionTable["Green"] = "Red";
            conversionTable["Red"] = "Black";

            while (conversionTable.ContainsKey(meteorType) && meteors[region][meteorType] >= convertedAmount)
            {
                var increase = meteors[region][meteorType] / convertedAmount;
                meteors[region][meteorType] %= convertedAmount;
                meteorType = conversionTable[meteorType];
                meteors[region][meteorType] += increase;
            }
            return meteors;
        }

        private static SortedDictionary<string, SortedDictionary<string, long>> GetMeteors()
        {
            var meteors = new SortedDictionary<string, SortedDictionary<string, long>>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Count em all") break;

                var tokens = input
                            .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
                var region = tokens[0];
                var meteorType = tokens[1];
                var amount = int.Parse(tokens[2]);

                if (!meteors.ContainsKey(region))
                {
                    meteors[region] = new SortedDictionary<String, long>();
                    meteors[region]["Black"] = 0;
                    meteors[region]["Green"] = 0;
                    meteors[region]["Red"] = 0;
                }
                meteors[region][meteorType] += amount;
                meteors = ConvertMeteors(meteors, region, meteorType);
            }
            return meteors;
        }
    }
}

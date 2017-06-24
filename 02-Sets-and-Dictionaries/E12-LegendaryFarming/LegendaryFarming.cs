using System;
using System.Collections.Generic;
using System.Linq;

namespace E12_LegendaryFarming
{
    public class LegendaryFarming
    {
        public const int requiredQty = 250;

        public static void Main()
        {
            var keyMaterials = new SortedDictionary<string, int>()
            {
                { "shards", 0 }, { "fragments", 0 }, { "motes", 0 }
            };
            var junkItems = new SortedDictionary<string, int>();
            bool isFarming = true;

            while (isFarming)
            {
                var args = Console.ReadLine()
                          .Trim()
                          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < args.Length; i += 2)
                {
                    var quantity = int.Parse(args[i]);
                    var item = args[i + 1].ToLower();

                    if (keyMaterials.ContainsKey(item))
                    {
                        keyMaterials[item] += quantity;
                        if (keyMaterials[item] >= requiredQty)
                        {
                            keyMaterials[item] -= requiredQty;
                            PrintCollectedItems(keyMaterials, junkItems, item);
                            isFarming = false;
                            break;
                        }
                    }
                    else
                    {
                        AddJunkItem(junkItems, quantity, item);
                    }
                }
            }
        }

        private static void PrintCollectedItems(SortedDictionary<string, int> keyMaterials, SortedDictionary<string, int> junkItems, string item)
        {
            // legendary item
            var legendaryItems = new Dictionary<string, string>()
            {
                { "shards", "Shadowmourne" }, { "fragments", "Valanyr" }, { "motes", "Dragonwrath" }
            };
            Console.WriteLine($"{legendaryItems[item]} obtained!");

            // key materials
            var keyMaterialsDesc = keyMaterials.OrderByDescending(x => x.Value);
            foreach (var kvp in keyMaterialsDesc)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            // junk items
            foreach (var kvp in junkItems)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        private static void AddJunkItem(SortedDictionary<string, int> junkItems, int quantity, string item)
        {
            if (!junkItems.ContainsKey(item))
            {
                junkItems[item] = 0;
            }
            junkItems[item] += quantity;
        }
    }
}

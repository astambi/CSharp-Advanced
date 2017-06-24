using System;
using System.Collections.Generic;
using System.Linq;

namespace E14_DragonArmy
{
    public class DragonArmy
    {
        private const int defaultDamage = 45;
        private const int defaultHealth = 250;
        private const int defaultArmor = 10;

        public static void Main()
        {
            PrintDragonStats(GetDragons());
        }

        private static void PrintDragonStats(Dictionary<string, SortedDictionary<string, int[]>> dragons)
        {
            foreach (var dragonType in dragons)
            {
                // dragon type average stats  
                Console.WriteLine($"{dragonType.Key}::" +
                    $"({dragonType.Value.Select(x => x.Value[0]).Average():f2}" +
                    $"/{dragonType.Value.Select(x => x.Value[1]).Average():f2}" +
                    $"/{dragonType.Value.Select(x => x.Value[2]).Average():f2})");
                // dragon stats
                foreach (var dragon in dragonType.Value)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }

        private static Dictionary<string, SortedDictionary<string, int[]>> GetDragons()
        {
            var dragons = new Dictionary<string, SortedDictionary<string, int[]>>();
            int dragonsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < dragonsCount; i++)
            {
                var args = Console.ReadLine()
                          .Trim()
                          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var type = args[0];
                var name = args[1];
                var damage = args[2] == "null" ? defaultDamage : int.Parse(args[2]);
                var health = args[3] == "null" ? defaultHealth : int.Parse(args[3]);
                var armor = args[4] == "null" ? defaultArmor : int.Parse(args[4]);

                if (!dragons.ContainsKey(type))
                {
                    dragons[type] = new SortedDictionary<string, int[]>();
                }
                dragons[type][name] = new[] { damage, health, armor }; // add or update
            }
            return dragons;
        }
    }
}

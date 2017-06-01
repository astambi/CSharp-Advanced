using System;
using System.Collections.Generic;

namespace E06_MinersTask
{
    public class MinersTask
    {
        public static void Main()
        {
            var resources = GetResources();
            PrintResources(resources);
        }

        private static void PrintResources(Dictionary<string, long> resources)
        {
            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }

        private static Dictionary<string, long> GetResources()
        {
            var resources = new Dictionary<string, long>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "stop") break;

                if (!resources.ContainsKey(input))
                {
                    resources[input] = 0;
                }
                resources[input] += int.Parse(Console.ReadLine());
            }
            return resources;
        }        
    }
}

using System;
using System.Collections.Generic;

namespace E06_MinersTask
{
    public class MinersTask
    {
        public static void Main()
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
            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}

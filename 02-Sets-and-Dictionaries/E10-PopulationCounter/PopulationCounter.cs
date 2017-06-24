using System;
using System.Collections.Generic;
using System.Linq;

namespace E10_PopulationCounter
{
    public class PopulationCounter
    {
        public static void Main()
        {
            PrintPopulation(GetCountriesPopulation());
        }

        private static void PrintPopulation(Dictionary<string, Dictionary<string, long>> populationCounter)
        {
            var countriesPopulationDesc = populationCounter
                                        .Select(x => new
                                        {
                                            Country = x.Key,
                                            Population = x.Value.Values.Sum()
                                        })
                                        .OrderByDescending(x => x.Population);
            foreach (var kvp in countriesPopulationDesc)
            {
                Console.WriteLine($"{kvp.Country} (total population: {kvp.Population})");
                var cityPopulationDesc = populationCounter[kvp.Country]
                                        .OrderByDescending(x => x.Value); // population DESC
                foreach (var cityPopulation in cityPopulationDesc)
                {
                    Console.WriteLine($"=>{cityPopulation.Key}: {cityPopulation.Value}"); // city - city population
                }
            }
        }

        private static Dictionary<string, Dictionary<string, long>> GetCountriesPopulation()
        {
            // country, city, city population
            var populationCounter = new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "report") break;

                var args = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                var city = args[0];
                var country = args[1];
                var cityPopulation = int.Parse(args[2]);

                if (!populationCounter.ContainsKey(country))
                {
                    populationCounter[country] = new Dictionary<string, long>();
                }
                populationCounter[country][city] = cityPopulation;
            }
            return populationCounter;
        }
    }
}

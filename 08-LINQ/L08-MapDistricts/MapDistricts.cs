using System;
using System.Collections.Generic;
using System.Linq;

namespace L08_MapDistricts
{
    public class MapDistricts
    {
        public static void Main()
        {
            var populationData = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var minPopulation = long.Parse(Console.ReadLine());

            var population = GetPopulationInCities(populationData);
            var filteredCities = population
                                .Where(p => p.Value.Sum() > minPopulation)
                                .OrderByDescending(p => p.Value.Sum())
                                .ToDictionary(p => p.Key, p => p.Value);

            foreach (var city in filteredCities)
            {
                var cityDistricts = city.Value
                                        .OrderByDescending(d => d)
                                        .Take(5);
                Console.WriteLine("{0}: {1}", city.Key, string.Join(" ", cityDistricts));
            }
        }

        private static Dictionary<string, List<long>> GetPopulationInCities(string[] districts)
        {
            var population = new Dictionary<string, List<long>>();
            foreach (var district in districts)
            {
                var tokens = district
                            .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                var city = tokens[0];
                var districtPopulation = long.Parse(tokens[1]);

                if (!population.ContainsKey(city))
                {
                    population[city] = new List<long>();
                }
                population[city].Add(districtPopulation);
            }
            return population;
        }
    }
}

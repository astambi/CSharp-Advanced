using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace E13_SrabskoUnleashed
{
    public class SrabskoUnleashed
    {
        public static void Main()
        {
            PrintRevenues(GetConcerts());
        }

        private static void PrintRevenues(Dictionary<string, Dictionary<string, decimal>> concerts)
        {            
            foreach (var kvp in concerts)
            {
                Console.WriteLine(kvp.Key); // venues
                var singersRevenuesDesc = concerts[kvp.Key].OrderByDescending(x => x.Value);
                foreach (var singer in singersRevenuesDesc)
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}"); // singer, revenues
                }
            }
        }

        private static Dictionary<string, Dictionary<string, decimal>> GetConcerts()
        {
            // venue, singer, revenues
            var concerts = new Dictionary<string, Dictionary<string, decimal>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;

                var match = Regex.Match(input, @"(.+) @(.+) (\d+) (\d+)");
                if (match == null || match.Groups.Count != 5) continue;

                var singer = match.Groups[1].Value;
                var venue = match.Groups[2].Value;
                var ticketPrice = int.Parse(match.Groups[3].Value);
                var ticketsCount = int.Parse(match.Groups[4].Value);

                if (!concerts.ContainsKey(venue))
                {
                    concerts[venue] = new Dictionary<string, decimal>();
                }
                if (!concerts[venue].ContainsKey(singer))
                {
                    concerts[venue][singer] = 0;
                }
                concerts[venue][singer] += ticketPrice * ticketsCount;
            }

            return concerts;
        }
    }
}

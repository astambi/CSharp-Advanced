using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_ChampionsLeague
{
    public class ChampionsLeague
    {
        public static void Main()
        {
            var competitors = new Dictionary<string, SortedSet<string>>();
            var wins = new SortedDictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "stop") break;

                var tokens = input
                            .Split(new[] { '|', ':' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim())
                            .ToList();
                var teams = tokens.Take(2).ToList();
                var goals = tokens.Skip(2).Select(int.Parse).ToList();

                wins = UpdateWins(wins, teams, goals);
                competitors = UpdateCompetitors(competitors, teams);
            }

            PrintResult(wins, competitors);
        }

        private static void PrintResult(SortedDictionary<string, int> wins, Dictionary<string, SortedSet<string>> competitors)
        {
            var orderedTeams = wins.OrderByDescending(t => t.Value);
            foreach (var team in orderedTeams)
            {
                Console.WriteLine(team.Key);
                Console.WriteLine($"- Wins: {team.Value}");
                Console.WriteLine($"- Opponents: {string.Join(", ", competitors[team.Key])}");
            }
        }

        private static Dictionary<string, SortedSet<string>> UpdateCompetitors(Dictionary<string, SortedSet<string>> competitors, List<string> teams)
        {
            foreach (var team in teams)
            {
                if (!competitors.ContainsKey(team))
                {
                    competitors[team] = new SortedSet<string>();
                }
            }
            competitors[teams[0]].Add(teams[1]);
            competitors[teams[1]].Add(teams[0]);
            return competitors;
        }

        private static SortedDictionary<string, int> UpdateWins(SortedDictionary<string, int> wins, List<string> teams, List<int> goals)
        {
            foreach (var team in teams)
            {
                if (!wins.ContainsKey(team))
                {
                    wins[team] = 0;
                }
            }
            var team1Goals = goals[0] + goals[3];
            var team2Goals = goals[1] + goals[2];
            var team1GoalsAwaySoil = goals[3];
            var team2GoalsAwaySoil = goals[1];

            if (team1Goals > team2Goals)                        wins[teams[0]] += 1; // team1
            else if (team1Goals < team2Goals)                   wins[teams[1]] += 1; // team2
            else if (team1GoalsAwaySoil > team2GoalsAwaySoil)   wins[teams[0]] += 1; // team1
            else                                                wins[teams[1]] += 1; // team2
            return wins;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_KnightGame
{
    public class KnightGame
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var knights = GetKnights(size);             // knight row => list knight cols
            var threats = GetThreats(size, knights);    // knight alias, threatened knights count
            var removedKnights = 0;

            while (threats.Any(x => x.Value != 0))      // while there are threatened knights
            {
                // remove most threatening knight
                removedKnights++;
                var mostSevereThreat = threats
                                      .OrderByDescending(t => t.Value) // threatened knights count
                                      .First();
                var coordinates = mostSevereThreat.Key
                                 .Split('-')
                                 .Select(int.Parse)
                                 .ToList();
                var removedKnightRow = coordinates[0];
                var removedKnightCol = coordinates[1];
                // update Knights
                knights[removedKnightRow].Remove(removedKnightCol);
                if (knights[removedKnightRow].Count == 0)
                {
                    knights.Remove(removedKnightRow);
                }
                threats.Remove(mostSevereThreat.Key);
                // update Threats
                threats = GetThreats(size, knights);
            }

            Console.WriteLine(removedKnights);
        }

        private static Dictionary<string, int> GetThreats(int size, Dictionary<int, List<int>> knights)
        {
            var threats = new Dictionary<string, int>();
            foreach (var knight in knights)
            {
                var row = knight.Key;
                foreach (var col in knight.Value)
                {
                    var currentKnight = GetKnightAlias(row, col);
                    if (!threats.ContainsKey(currentKnight))
                    {
                        threats[currentKnight] = 0;
                    }
                    // search for threatened knights
                    if (IsKnight(knights, size, row - 2, col - 1)) threats[currentKnight]++;
                    if (IsKnight(knights, size, row - 2, col + 1)) threats[currentKnight]++;

                    if (IsKnight(knights, size, row + 2, col - 1)) threats[currentKnight]++;
                    if (IsKnight(knights, size, row + 2, col + 1)) threats[currentKnight]++;

                    if (IsKnight(knights, size, row - 1, col - 2)) threats[currentKnight]++;
                    if (IsKnight(knights, size, row - 1, col + 2)) threats[currentKnight]++;

                    if (IsKnight(knights, size, row + 1, col - 2)) threats[currentKnight]++;
                    if (IsKnight(knights, size, row + 1, col + 2)) threats[currentKnight]++;
                }
            }
            return threats;
        }

        private static bool IsKnight(Dictionary<int, List<int>> knights, int size, int row, int col)
        {
            if (!IsInsideBoard(size, row, col))     return false;
            if (!knights.ContainsKey(row))          return false;
            if (!knights[row].Contains(col))        return false;
            return true;
        }

        private static string GetKnightAlias(int row, int col)
        {
            return row + "-" + col;
        }

        private static bool IsInsideBoard(int size, int row, int col)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }

        private static Dictionary<int, List<int>> GetKnights(int size)
        {
            var knights = new Dictionary<int, List<int>>();
            for (int row = 0; row < size; row++)
            {
                var rowInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < rowInput.Length; col++)
                {
                    if (rowInput[col] == 'K')
                    {
                        if (!knights.ContainsKey(row))
                        {
                            knights[row] = new List<int>();
                        }
                        knights[row].Add(col);
                    }
                }
            }
            return knights;
        }
    }
}

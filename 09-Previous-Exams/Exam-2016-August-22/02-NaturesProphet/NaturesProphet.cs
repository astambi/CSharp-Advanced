using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_NaturesProphet
{
    public class NaturesProphet
    {
        public static void Main()
        {
            var garden = GetGarden();
            var flowers = PlantFlowers();
            garden = BloomFlowers(garden, flowers);
            PrintGarden(garden);
        }

        private static int[][] BloomFlowers(int[][] garden, Dictionary<int, HashSet<int>> flowers)
        {
            foreach (var flower in flowers)
            {
                var gardenRows = garden.Length;
                var gardenCols = garden[0].Length;

                var flowerRow = flower.Key;
                foreach (var flowerCol in flower.Value)
                {
                    for (int c = 0; c < gardenCols; c++)
                    {
                        garden[flowerRow][c] += 1;
                    }
                    for (int r = 0; r < gardenRows; r++)
                    {
                        garden[r][flowerCol] += 1;
                    }
                    garden[flowerRow][flowerCol] -= 1;
                }                
            }

            return garden;
        }
        
        private static Dictionary<int, HashSet<int>> PlantFlowers()
        {
            var flowers = new Dictionary<int, HashSet<int>>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Bloom Bloom Plow") break;

                var position = input
                              .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();
                var row = position[0];
                var col = position[1];

                if (!flowers.ContainsKey(row))
                {
                    flowers[row] = new HashSet<int>();
                }
                flowers[row].Add(col);
            }
            return flowers;
        }

        private static void PrintGarden(int[][] garden)
        {
            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static int[][] GetGarden()
        {
            var dimensions = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();
            var rows = dimensions[0];
            var cols = dimensions[1];
            var garden = new int[rows][];

            for (int r = 0; r < rows; r++)
            {
                garden[r] = new int[cols];
                for (int c = 0; c < cols; c++)
                {
                    garden[r][c] = 0;
                }
            }
            return garden;
        }
    }
}

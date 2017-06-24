using System;
using System.Linq;

namespace E11_ParkingSystem
{
    public class ParkingSystem
    {
        public static void Main()
        {
            // TODO Memory Limit 80/100

            var matrix = GetMatrix();

            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (input == "stop") break;

                var args = input
                          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();
                var entryRow = args[0]; // entry col = 0
                var targetRow = args[1];
                var targetCol = args[2];
                var foundFreeParkingSpot = false;

                switch (matrix[targetRow][targetCol])
                {
                    case false:
                        foundFreeParkingSpot = true; break;
                    case true:
                        if (!matrix[targetRow].Skip(1).Any(x => x == false)) break;

                        var minDiff = 1; // min distance from target parking spot (targetCol)
                        while (!foundFreeParkingSpot && IsValidTargetCol(matrix, targetCol, minDiff))
                        {
                            if (IsValidParkingSpot(matrix, targetRow, targetCol - minDiff) &&
                                !matrix[targetRow][targetCol - minDiff])
                            {
                                foundFreeParkingSpot = true;
                                targetCol -= minDiff;
                                break;
                            }
                            if (IsValidParkingSpot(matrix, targetRow, targetCol + minDiff) &&
                                !matrix[targetRow][targetCol + minDiff])
                            {
                                foundFreeParkingSpot = true;
                                targetCol += minDiff;
                                break;
                            }
                            minDiff++;
                        }
                        break;
                }

                PrintOutcome(matrix, entryRow, targetRow, targetCol, foundFreeParkingSpot);
            }
        }

        private static bool IsValidTargetCol(bool[][] matrix, int targetCol, int minDiff)
        {
            return targetCol - minDiff >= 1 || targetCol + minDiff < matrix[0].Length;
        }

        private static bool IsValidParkingSpot(bool[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 1 && col < matrix[0].Length; // col 0 is reserved
        }

        private static void PrintOutcome(bool[][] matrix, int entryRow, int targetRow, int targetCol, bool isFreeParkingSpot)
        {
            if (isFreeParkingSpot)
            {
                matrix[targetRow][targetCol] = true;
                var distance = CalcDistanceToParkingLot(entryRow, targetRow, targetCol);
                Console.WriteLine(distance);
            }
            else
            {
                Console.WriteLine($"Row {targetRow} full");
            }
        }

        private static long CalcDistanceToParkingLot(int entryRow, int targetRow, int targetCol)
        {
            return Math.Abs(targetRow - entryRow) + targetCol + 1;
        }

        private static bool[][] GetMatrix()
        {
            var size = Console.ReadLine()
                      .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();
            var matrix = new bool[size[0]][];
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new bool[size[1]];
            }
            return matrix;
        }
    }
}

using System;
using System.Linq;

namespace E02_DiagonalDifference
{
    public class DiagonalDifference
    {
        public static void Main()
        {
            var matrix = GetMatrix();
            PrintDiagonalsDiff(CalcDiagonalsDifference(matrix));
        }

        public static void PrintDiagonalsDiff(long difference)
        {
            Console.WriteLine(difference);
        }               

        public static long CalcDiagonalsDifference(int[][] matrix)
        {
            long sumPrimaryDiagonal = 0;
            long sumSecondaryDiagonal = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                sumPrimaryDiagonal += matrix[row][row];
                sumSecondaryDiagonal += matrix[row][matrix.Length - 1 - row];
            }

            return Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal);
        }

        public static int[][] GetMatrix()
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new int[size][];

            for (int row = 0; row < size; row++)
            {
                matrix[row] = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            }

            return matrix;
        }
    }
}

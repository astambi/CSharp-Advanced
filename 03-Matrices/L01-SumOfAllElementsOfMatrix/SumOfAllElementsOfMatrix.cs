using System;
using System.Linq;

namespace L01_SumOfAllElementsOfMatrix
{
    public class SumOfAllElementsOfMatrix
    {
        public static void Main()
        {
            PrintSumMatrixElements(GetMatrix());
        }

        public static void PrintSumMatrixElements(int[][] matrix)
        {
            Console.WriteLine(matrix.Length);                   // rows
            Console.WriteLine(matrix[0].Length);                // cols
            Console.WriteLine(CalcSumMatrixElements(matrix));   // sum elements
        }

        public static long CalcSumMatrixElements(int[][] matrix)
        {
            long sum = 0;
            foreach (var row in matrix)
            {
                sum += row.Sum();
            }
            return sum;
        }

        public static int[][] GetMatrix()
        {
            var matrixSize = Console.ReadLine()
                            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            var matrix = new int[matrixSize[0]][];
            for (int row = 0; row < matrixSize[0]; row++)
            {
                matrix[row] = Console.ReadLine()
                            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            }
            return matrix;
        }
    }
}

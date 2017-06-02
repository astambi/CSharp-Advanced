using System;
using System.Collections.Generic;
using System.Linq;

namespace L02_SquareWithMaximumSum
{
    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            var matrix = GetMatrix();
            PrintMaxSumMatrix(matrix, FindMaxMatrix(matrix));
        }

        public static void PrintMaxSumMatrix(int[][] matrix, int[] maxMatrixRowCol)
        {
            var matrixRow = maxMatrixRowCol[0];
            var matrixCol = maxMatrixRowCol[1];

            for (var row = matrixRow; row <= matrixRow + 1; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row].Skip(matrixCol).Take(2)));
            }
            Console.WriteLine(CalcMatrixSum(matrix, matrixRow, matrixCol));
        }

        public static long CalcMatrixSum(int[][] matrix, int row, int col)
        {
            return  matrix[row][col] +
                    matrix[row][col + 1] +
                    matrix[row + 1][col] +
                    matrix[row + 1][col + 1];
        }

        public static int[] FindMaxMatrix(int[][] matrix)
        {
            var maxMatrix = new Stack<int[]>();
            maxMatrix.Push(new int[] { 0, 0 }); // first top-left submatrix

            long maxSum = long.MinValue;
            for (var row = 0; row < matrix.Length - 1; row++)
            {
                for (var col = 0; col < matrix[row].Length - 1; col++)
                {
                    var currentSum = CalcMatrixSum(matrix, row, col);
                    if (maxSum < currentSum) // add first max matrix found
                    {
                        maxSum = currentSum;
                        maxMatrix.Clear();
                        maxMatrix.Push(new int[] { row, col });
                    }
                }
            }
            return maxMatrix.Peek(); // top-left row, col
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

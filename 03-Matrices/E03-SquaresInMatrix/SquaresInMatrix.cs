using System;
using System.Linq;

namespace E03_SquaresInMatrix
{
    public class SquaresInMatrix
    {
        public static void Main()
        {
            char[][] matrix = GetMatrix();
            Console.WriteLine(CountSquaresInMatrix(matrix));        
        }

        private static int CountSquaresInMatrix(char[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            int squaresCount = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (IsSquareOfEqualChars(matrix, row, col))
                    {
                        squaresCount++;
                    }
                }
            }
            return squaresCount; 
        }

        private static bool IsSquareOfEqualChars(char[][] matrix, int row, int col)
        {
            var cell = matrix[row][col];
            return  cell == matrix[row][col + 1] &&
                    cell == matrix[row + 1][col] &&
                    cell == matrix[row + 1][col + 1];
        }

        private static char[][] GetMatrix()
        {
            var size = Console.ReadLine()
                      .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();
            var rows = size[0];
            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x[0])
                            .ToArray();
            }

            return matrix;
        }
    }
}

using System;

namespace L04_PascalTriangle
{
    public class PascalTriangle
    {
        public static void Main()
        {
            PrintMatrix(GetPascalTriangle());
        }

        public static void PrintMatrix(long[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        public static long[][] GetPascalTriangle()
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new long[size][];

            for (int row = 0; row < size; row++)
            {
                matrix[row] = new long[row + 1];
                matrix[row][0] = 1;
                matrix[row][row] = 1;

                if (row < 2) continue;

                for (int col = 1; col < row; col++)
                {
                    matrix[row][col] = matrix[row - 1][col - 1] + matrix[row - 1][col];
                }
            }

            return matrix;
        }
    }
}

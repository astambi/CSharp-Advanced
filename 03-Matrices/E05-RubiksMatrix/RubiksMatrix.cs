using System;
using System.Linq;

namespace E05_RubiksMatrix
{
    public class RubiksMatrix
    {
        public static void Main()
        {
            var matrix = GetMatrix();
            var modifiedMatrix = RotateMatrix(matrix);
            SwapModifiedMatrixToOriginal(modifiedMatrix, matrix);
            //PrintMatrix(modifiedMatrix);
        }

        private static void SwapModifiedMatrixToOriginal(int[][] modifiedMatrix, int[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (modifiedMatrix[row][col] == matrix[row][col])
                    {
                        Console.WriteLine("No swap required");
                        continue;
                    }
                    // swap elements
                    for (int searchRow = row; searchRow < rows; searchRow++)
                    {
                        bool isMatch = false;
                        for (int searchCol = 0; searchCol < cols; searchCol++)
                        {
                            if (modifiedMatrix[searchRow][searchCol] == matrix[row][col])
                            {
                                modifiedMatrix[searchRow][searchCol] = modifiedMatrix[row][col];
                                modifiedMatrix[row][col] = matrix[row][col];
                                Console.WriteLine($"Swap ({row}, {col}) with ({searchRow}, {searchCol})");
                                isMatch = true;
                                break;
                            }
                        }
                        if (isMatch) break;
                    }
                }
            }
        }

        private static int[][] CopyMatrix(int[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            var matrixCopy = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrixCopy[row] = matrix[row].ToArray();
            }
            return matrixCopy;
        }

        private static int[][] RotateMatrix(int[][] matrix)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            var modifiedMatrix = CopyMatrix(matrix);

            for (int command = 0; command < commandsCount; command++)
            {
                var args = Console.ReadLine()
                          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();
                var rotatedRowCol = int.Parse(args[0]);
                var direction = args[1];
                var movesCount = int.Parse(args[2]);

                if (direction == "up" || direction == "down")
                {
                    modifiedMatrix = RotateMatrixCol(modifiedMatrix, rotatedRowCol, direction, movesCount);
                }
                else if (direction == "left" || direction == "right")
                {
                    modifiedMatrix = RotateMatrixRow(modifiedMatrix, rotatedRowCol, direction, movesCount);
                }
            }
            return modifiedMatrix;
        }

        private static int[][] RotateMatrixRow(int[][] matrix, int rotatedRow, string direction, int movesCount)
        {
            var modifiedMatrix = CopyMatrix(matrix);
            var rows = matrix.Length;
            var cols = matrix[0].Length;

            // direction RIGHT => increase COL index, direction LEFT => decrease COL index
            // keep ROW index upchanged
            movesCount %= rows;
            if (direction == "left")
            {
                movesCount = -movesCount;
            }

            for (int col = 0; col < rows; col++)
            {
                var modifiedCol = (col + movesCount) % cols;
                while (modifiedCol < 0)
                {
                    modifiedCol += cols;
                }
                modifiedMatrix[rotatedRow][modifiedCol] = matrix[rotatedRow][col];
            }
            return modifiedMatrix;
        }

        private static int[][] RotateMatrixCol(int[][] matrix, int rotatedCol, string direction, int movesCount)
        {
            var modifiedMatrix = CopyMatrix(matrix);
            var rows = matrix.Length;
            var cols = matrix[0].Length;

            // direction DOWN => increase ROW index, direction UP => decrease ROW index
            // keep COL index unchanged
            movesCount %= rows;
            if (direction == "up")
            {
                movesCount = -movesCount;
            }

            for (int row = 0; row < rows; row++)
            {
                var modifiedRow = (row + movesCount) % rows;
                while (modifiedRow < 0)
                {
                    modifiedRow += rows;
                }
                modifiedMatrix[modifiedRow][rotatedCol] = matrix[row][rotatedCol];
            }
            return modifiedMatrix;
        }

        public static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static int[][] GetMatrix()
        {
            var size = Console.ReadLine()
                      .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();
            var rows = size[0];
            var cols = size[1];
            var matrix = new int[rows][];
            var number = 1;
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = number++;
                }
            }
            return matrix;
        }
    }
}

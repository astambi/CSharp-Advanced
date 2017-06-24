using System;
using System.Linq;

namespace _02_Monopoly
{
    public class Monopoly
    {
        public static decimal money;
        public static int turns;
        public static int hotels;

        public const decimal hotelIncome = 10m;

        public static void Main()
        {
            var matrix = GetMatrix();
            InitializePlayer();
            MovePlayer(matrix);
            PrintGameResult();
        }

        private static void MovePlayer(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if (row % 2 == 0) // direction Right
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        UpdateGameResult(matrix, row, col);
                    }
                }
                else // direction Left
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        UpdateGameResult(matrix, row, col);
                    }
                }
            }
        }

        private static void PrintGameResult()
        {
            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");
        }

        private static void UpdateGameResult(char[][] matrix, int row, int col)
        {
            switch (matrix[row][col])
            {
                case 'H':
                    Console.WriteLine($"Bought a hotel for {money}. Total hotels: {++hotels}.");
                    money = 0;
                    break;
                case 'J':
                    Console.WriteLine($"Gone to jail at turn {turns}.");
                    turns += 2;
                    money += hotels * hotelIncome * 2;
                    break;
                case 'S':
                    var spentMoney = Math.Min(money, (row + 1) * (col + 1));
                    money -= spentMoney;
                    Console.WriteLine($"Spent {spentMoney} money at the shop.");
                    break;
                default: break;
            }
            turns++;
            money += hotels * hotelIncome;
        }

        private static void InitializePlayer()
        {
            money = 50;
            turns = 0;
            hotels = 0;
        }

        private static char[][] GetMatrix()
        {
            var dimensions = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();
            var rows = dimensions[0];
            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }
            return matrix;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace E04_Find_Evens_Or_Odds
{
    public class FindEvensOrOdds
    {
        public static void Main()
        {
            var range = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .OrderBy(n => n)
                        .ToList();
            var oddEven = Console.ReadLine().ToLower();

            Predicate<int> isEven = n => n % 2 == 0;

            var numbers = GetNumbers(range, oddEven, isEven);
            if (numbers.Count != 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static List<int> GetNumbers(List<int> range, string oddEven, Predicate<int> isEven)
        {
            var numbers = new List<int>();
            for (int n = range[0]; n <= range[1]; n++)
            {
                if ((isEven(n) && oddEven == "even") || 
                    (!isEven(n) && oddEven == "odd"))
                {
                    numbers.Add(n);
                }
            }
            return numbers;
        }
    }
}

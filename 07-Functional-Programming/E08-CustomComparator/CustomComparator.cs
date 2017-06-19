using System;
using System.Linq;

namespace E08_CustomComparator
{
    public class CustomComparator
    {
        public static void Main()
        {
            Predicate<int> isEven = n => n % 2 == 0;

            var numbers = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .GroupBy(n => isEven(n))
                        .OrderByDescending(g => g.Key) // true-false => even-odd
                        .ToDictionary(g => g.Key, g => g.OrderBy(n => n).ToList());

            foreach (var group in numbers)
            {
                Console.Write(string.Join(" ", group.Value) + " ");
            }
        }
    }
}

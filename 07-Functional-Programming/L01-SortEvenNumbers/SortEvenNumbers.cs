using System;
using System.Collections.Generic;
using System.Linq;

namespace L01_SortEvenNumbers
{
    public class SortEvenNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            //var evenNumbers = FilterWithLinq(numbers);

            var evenNumbers = FilterNumbers(numbers, n => n % 2 == 0);
            Console.WriteLine(string.Join(", ", evenNumbers.OrderBy(n => n)));
        }

        private static List<int> FilterNumbers(List<int> numbers, Func<int, bool> condition)
        {
            var result = new List<int>();
            foreach (var n in numbers)
            {
                if (condition(n))
                {
                    result.Add(n);
                }
            }
            return result;
        }

        private static List<int> FilterWithLinq(List<int> numbers)
        {
            return numbers
                    .Where(x => x % 2 == 0)
                    .OrderBy(x => x)
                    .ToList();
        }
    }
}

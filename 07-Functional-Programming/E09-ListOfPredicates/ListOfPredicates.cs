using System;
using System.Collections.Generic;
using System.Linq;

namespace E09_ListOfPredicates
{
    public class ListOfPredicates
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var divisors = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .Distinct()
                        .ToList();
            var divisibleNumbers = GetDivisibleNumbers1ToN(n, divisors);
            Console.WriteLine(string.Join(" ", divisibleNumbers));
        }

        private static List<int> GetDivisibleNumbers1ToN(int n, List<int> divisors)
        {
            var divisibleNumbers = new List<int>();
            for (int num = 1; num <= n; num++)
            {
                var isDivisible = true;
                foreach (var d in divisors)
                {
                    Predicate<int> isNotDivisor = x => num % x != 0;

                    if (isNotDivisor(d))
                    {
                        isDivisible = false; break;
                    }
                }

                if (isDivisible)
                {
                    divisibleNumbers.Add(num);
                }
            }
            return divisibleNumbers;
        }
    }
}

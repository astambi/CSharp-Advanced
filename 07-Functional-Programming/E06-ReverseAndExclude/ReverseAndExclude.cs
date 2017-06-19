using System;
using System.Linq;

namespace E06_ReverseAndExclude
{
    public class ReverseAndExclude
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
            var divisor = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = n => n % divisor == 0;

            var nonDivisibleNumbers = numbers
                        .Where(n => !isDivisible(n))
                        .Reverse()
                        .ToList();
            Console.WriteLine(string.Join(" ", nonDivisibleNumbers));
        }
    }
}

using System;
using System.Linq;

namespace L06_FindAndSumIntegers
{
    public class FindAndSumIntegers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s =>
                        {
                            long number;
                            var success = long.TryParse(s, out number);
                            return new { success, number };
                        })
                        .Where(x => x.success)
                        .Select(x => x.number)
                        .ToList();

            if (numbers.Count != 0)
                Console.WriteLine(numbers.Sum());
            else
                Console.WriteLine("No match");
        }
    }
}

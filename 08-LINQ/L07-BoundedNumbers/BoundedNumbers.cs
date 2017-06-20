using System;
using System.Linq;

namespace L07_BoundedNumbers
{
    public class BoundedNumbers
    {
        public static void Main()
        {
            var range = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse)
                        .OrderBy(n => n)
                        .ToList();
            var numbers = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse)
                        .Where(n => n >= range[0] && n <= range[1])
                        .ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

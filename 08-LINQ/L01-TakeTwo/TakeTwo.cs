using System;
using System.Linq;

namespace L01_TakeTwo
{
    public class TakeTwo
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .Distinct()
                        .Where(n => n >= 10 && n <= 20)
                        .Take(2)
                        .ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

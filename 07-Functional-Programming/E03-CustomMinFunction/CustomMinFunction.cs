using System;
using System.Collections.Generic;
using System.Linq;

namespace E03_CustomMinFunction
{
    public class CustomMinFunction
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse)
                        .ToList();

            Func<List<double>, double> minNumber = nums => nums.Min();

            Console.WriteLine(minNumber(numbers));
        }
    }
}

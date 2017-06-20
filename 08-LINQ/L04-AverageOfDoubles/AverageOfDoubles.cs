using System;
using System.Linq;

namespace L04_AverageOfDoubles
{
    public class AverageOfDoubles
    {
        public static void Main()
        {
            var average = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse)
                        .ToList()
                        .Average();

            Console.WriteLine($"{average:f2}");
        }
    }
}

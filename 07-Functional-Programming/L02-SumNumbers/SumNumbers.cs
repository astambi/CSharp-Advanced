using System;
using System.Linq;

namespace L02_SumNumbers
{
    public class SumNumbers
    {
        public static void Main()
        {
            //Func<string, int> parser = n => int.Parse(n);

            var numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                //.Select(parser)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());
        }
    }
}

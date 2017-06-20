using System;
using System.Linq;

namespace L05_MinEvenNumber
{
    public class MinEvenNumber
    {
        public static void Main()
        {
            var evenNumbers = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(double.Parse)
                            .Where(n => n % 2 == 0)
                            .ToList();

            if (evenNumbers.Count != 0)
                Console.WriteLine($"{evenNumbers.Min():f2}");
            else
                Console.WriteLine("No match");
        }
    }
}

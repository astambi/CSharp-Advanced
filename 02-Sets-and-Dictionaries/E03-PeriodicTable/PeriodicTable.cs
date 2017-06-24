using System;
using System.Collections.Generic;

namespace E03_PeriodicTable
{
    public class PeriodicTable
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var periodicTable = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine()
                              .Trim()
                              .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var element in elements)
                {
                    periodicTable.Add(element);
                }
            }
            Console.WriteLine(string.Join(" ", periodicTable));
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace L03_GroupNumbers
{
    public class GroupNumbers
    {
        public static void Main()
        {
            PrintMatrix(GroupNumbersInMatrix());
        }

        public static void PrintMatrix(List<int>[] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        public static List<int>[] GroupNumbersInMatrix()
        {
            var matrix = new List<int>[3];
            for (int row = 0; row < 3; row++)
            {
                matrix[row] = new List<int>();
            }
            var elements = Console.ReadLine()
                            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            foreach (var element in elements)
            {
                var remainder = Math.Abs(element % 3);
                matrix[remainder].Add(element);
            }

            return matrix;
        }
    }
}

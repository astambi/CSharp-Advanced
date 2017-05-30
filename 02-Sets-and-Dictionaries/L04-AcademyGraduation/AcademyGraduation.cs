using System;
using System.Collections.Generic;
using System.Linq;

namespace L04_AcademyGraduation
{
    public class AcademyGraduation
    {
        public static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine().Trim());
            var studentsGrades = new SortedDictionary<string, double[]>();

            for (int i = 0; i < studentsCount; i++)
            {
                string studentName = Console.ReadLine().Trim();
                double[] grades = Console.ReadLine().Trim()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(double.Parse)
                                .ToArray();
                studentsGrades[studentName] = grades;
            }
            foreach (var kvp in studentsGrades)
            {
                Console.WriteLine($"{kvp.Key} is graduated with {kvp.Value.Average()}");
            }
        }
    }
}

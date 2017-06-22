using System;
using System.Collections.Generic;
using System.Linq;

namespace E09_StudentsEnrolledIn2014Or2015
{
    public class StudentsEnrolledIn2014Or2015
    {
        public static void Main()
        {
            var students = GetStudents();
            var enrollmentYears = new[] { "14", "15" };

            students
                .Where(s => enrollmentYears.Any(y => s[0].EndsWith(y)))
                .Select(s => s.Skip(1)) // marks
                .ToList()
                .ForEach(s => Console.WriteLine(string.Join(" ", s)));
        }

        private static List<string[]> GetStudents()
        {
            var students = new List<string[]>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                var tokens = input
                            .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                students.Add(tokens);
            }

            return students;
        }
    }
}

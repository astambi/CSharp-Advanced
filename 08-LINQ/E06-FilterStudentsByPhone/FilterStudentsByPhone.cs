using System;
using System.Collections.Generic;
using System.Linq;

namespace E06_FilterStudentsByPhone
{
    public class FilterStudentsByPhone
    {
        public static void Main()
        {
            var students = GetStudents();
            var prefixes = new[] { "02", "+3592" };

            var selection = students
                            .Where(s => prefixes.Any(p => s[2].StartsWith(p)))
                            .Select(s => s[0] + " " + s[1]);

            Console.WriteLine(string.Join("\n", selection));
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

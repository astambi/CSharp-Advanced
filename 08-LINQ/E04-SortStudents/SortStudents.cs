using System;
using System.Collections.Generic;
using System.Linq;

namespace E04_SortStudents
{
    public class SortStudents
    {
        public static void Main()
        {
            var students = GetStudents();
            var selection = students
                            .OrderBy(s => s[1])
                            .ThenByDescending(s => s[0])
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

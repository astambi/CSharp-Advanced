using System;
using System.Collections.Generic;
using System.Linq;

namespace E01_StudentsByGroup
{
    public class StudentsByGroup
    {
        public static void Main()
        {
            var students = GetStudents();
            var studentsInGroup = students
                                .Where(s => s[2] == "2")
                                .OrderBy(s => s[0])
                                .Select(s => s[0] + " " + s[1]);

            Console.WriteLine(string.Join("\n", studentsInGroup));
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

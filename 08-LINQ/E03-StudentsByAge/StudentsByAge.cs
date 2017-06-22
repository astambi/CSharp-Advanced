using System;
using System.Collections.Generic;
using System.Linq;

namespace E03_StudentsByAge
{
    public class StudentsByAge
    {
        public static void Main()
        {
            var students = GetStudents();
            var selection = students
                            .Where(s => int.Parse(s[2]) >= 18 && int.Parse(s[2]) <= 24)
                            .Select(s => string.Join(" ", s));

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

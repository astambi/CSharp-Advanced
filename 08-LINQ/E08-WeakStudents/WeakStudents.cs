using System;
using System.Collections.Generic;
using System.Linq;

namespace E08_WeakStudents
{
    public class WeakStudents
    {
        public static void Main()
        {
            var students = GetStudents();

            students
                .Select(s => new
                {
                    Name = s[0] + " " + s[1],
                    WeakMarksCount = s
                                    .Skip(2)
                                    .Select(int.Parse)
                                    .Count(m => m <= 3)
                })
                .Where(s => s.WeakMarksCount >= 2)
                .ToList()
                .ForEach(s => Console.WriteLine(s.Name));
        }

        private static List<string[]> GetStudents()
        {
            var students = new List<string[]>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                var tokens = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                students.Add(tokens);
            }

            return students;
        }
    }
}

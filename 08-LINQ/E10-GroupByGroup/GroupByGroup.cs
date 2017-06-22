using System;
using System.Collections.Generic;
using System.Linq;

namespace E10_GroupByGroup
{
    public class GroupByGroup
    {
        public class Person
        {
            public string Name { get; set; }
            public int Group { get; set; }
        }

        public static void Main()
        {
            var students = GetStudents();
            var groups = students
                        .GroupBy(s => s.Group)
                        .OrderBy(g => g.Key)
                        .ToDictionary(g => g.Key,
                                      g => g.Select(m => m.Name)); // order of appearance!
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key} - {string.Join(", ", group.Value)}");
            }
        }

        private static List<Person> GetStudents()
        {
            var students = new List<Person>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                var tokens = input
                            .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                students.Add(new Person
                {
                    Name = tokens[0] + " " + tokens[1],
                    Group = int.Parse(tokens[2])
                });
            }
            return students;
        }
    }
}

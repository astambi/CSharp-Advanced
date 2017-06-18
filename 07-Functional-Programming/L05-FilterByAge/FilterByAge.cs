using System;
using System.Collections.Generic;
using System.Linq;

namespace L05_FilterByAge
{
    public class FilterByAge
    {
        public static void Main()
        {
            var persons = GetPersons();
            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var ageFilter = AgeFilter(condition, age);
            var print = Print(format);
            PrintFilteredPersons(persons, ageFilter, print);
        }

        private static void PrintFilteredPersons(Dictionary<string, int> persons, Func<int, bool> ageFilter, Action<KeyValuePair<string, int>> print)
        {
            foreach (var person in persons)
            {
                if (ageFilter(person.Value))
                {
                    print(person);
                }
            }
        }

        private static Func<int, bool> AgeFilter(string condition, int age)
        {
            switch (condition)
            {
                case "older":   return x => x >= age;
                case "younger": return x => x < age;
                default:        return null;
            }
        }

        private static Action<KeyValuePair<string, int>> Print(string format)
        {
            switch (format)
            {
                case "name age":return person => Console.WriteLine($"{person.Key} - {person.Value}");
                case "name":    return person => Console.WriteLine(person.Key);
                case "age":     return person => Console.WriteLine(person.Value);
                default:        return null;
            }
        }

        private static Dictionary<string, int> GetPersons()
        {
            int n = int.Parse(Console.ReadLine());
            var persons = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()
                            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                persons[name] = age;
            }
            return persons;
        }
    }
}

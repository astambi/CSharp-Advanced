using System;
using System.Linq;

namespace E07_PredicateForNames
{
    public class PredicateForNames
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            Predicate<string> hasValidLength = s => s.Length <= length;

            Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(s => hasValidLength(s))
                    .ToList()
                    .ForEach(n => Console.WriteLine(n));
        }
    }
}

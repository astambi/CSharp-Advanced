using System;
using System.Linq;

namespace L03_FirstName
{
    public class FirstName
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
            var letters = Console.ReadLine()
                        .ToLower()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

            var firstName = names
                        .OrderBy(n => n)
                        .FirstOrDefault(n => letters.Any(l => n.ToLower().StartsWith(l)));

            Console.WriteLine(firstName != null ? firstName : "No match");
        }
    }
}

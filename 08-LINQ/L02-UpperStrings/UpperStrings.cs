using System;
using System.Linq;

namespace L02_UpperStrings
{
    public class UpperStrings
    {
        public static void Main()
        {
            var strings = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => s.ToUpper())
                        .ToList();

            Console.WriteLine(string.Join(" ", strings));
        }
    }
}

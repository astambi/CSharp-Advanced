using System;
using System.Text.RegularExpressions;

namespace L04_ExtractIntegerNumbers
{
    public class ExtractIntegerNumbers
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var regex = new Regex(@"\d+");
            var matches = regex.Matches(text);
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}

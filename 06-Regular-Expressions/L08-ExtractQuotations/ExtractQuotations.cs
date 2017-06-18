using System;
using System.Text.RegularExpressions;

namespace L08_ExtractQuotations
{
    public class ExtractQuotations
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var regex = new Regex("(\"|')(.+?)\\1");

            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2].Value);
            }
        }
    }
}

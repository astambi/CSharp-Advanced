using System;
using System.Text.RegularExpressions;

namespace L01_MatchCount
{
    public class MatchCount
    {
        public static void Main()
        {
            var pattern = Console.ReadLine();
            var text = Console.ReadLine();

            var regex = new Regex(pattern);
            var matches = regex.Matches(text);
            Console.WriteLine(matches.Count);
        }
    }
}

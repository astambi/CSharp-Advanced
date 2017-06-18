using System;
using System.Text.RegularExpressions;

namespace E05_ExtractEmail
{
    public class ExtractEmails
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var pattern = @"(?:^|\s)([a-zA-Z\d]+([._-][a-zA-Z\d]+)*?)@([a-zA-Z]+(-[a-zA-Z]+)*(\.[a-zA-Z]+(-[a-zA-Z]+)*)*(\.[a-zA-Z]+))\b"; // NB. (?:^|\s) instead of \b

            var regex = new Regex(pattern);
            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value.Trim());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace E08_ExtractHyperlinks
{
    public class ExtractHyperlinks
    {
        public static void Main()
        {
            // TODO 87/100

            var html = ReadHTML();
            var pattern = @"<a\s*?(?<a1>[a-z]+?\s*?=\s*?[^>]+?\s*?)*?(?<hr>href\s*?=\s*?)(?<link>[^>]*?)(?<a2>[a-z]+?\s*?=\s*?[^>]+?\s*?)*?\s*?>(?<v>.*?)\s*?<\/a>";

            var regex = new Regex(pattern);
            var matches = regex.Matches(html);
            var links = new List<string>();
            foreach (Match match in matches)
            {
                var link = match
                    .Groups["link"].Value
                    .Trim()
                    .Trim("\"'".ToCharArray());
                links.Add(link);
                Console.WriteLine(link);
            }
            Console.WriteLine();
        }

        private static string ReadHTML()
        {
            var builder = new StringBuilder();
            while (true)
            {
                var input = Console.ReadLine().Trim();
                if (input == "END") break;

                builder.Append(" ").Append(input);
            }
            return builder.ToString().Trim();
        }
    }
}

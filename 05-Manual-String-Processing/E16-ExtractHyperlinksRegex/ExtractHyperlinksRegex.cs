using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace E16_ExtractHyperlinksRegex
{
    public class ExtractHyperlinks
    {
        public static void Main()
        {
            var html = ReadHTML();
            var hyperlinks = ExtractLinks(html);
            PrintHyperlinks(hyperlinks);
        }

        private static void PrintHyperlinks(List<string> hyperlinks)
        {
            if (hyperlinks.Count != 0)
            {
                Console.WriteLine(string.Join("\n", hyperlinks));
            }
        }

        private static List<string> ExtractLinks(string html)
        {
            var pattern = @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'([^']*)'|""([^""]*)""|([^\s>]+))[^>]*>";
            var regex = new Regex(pattern);
            var matches = regex.Matches(html);

            var links = new List<string>();
            foreach (Match hyperlink in matches)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (hyperlink.Groups[i].Length > 0)
                    {
                        links.Add(hyperlink.Groups[i].ToString());
                    }
                }
            }

            return links;
        }

        private static string ReadHTML()
        {
            var builder = new StringBuilder();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;
                builder.Append(input);
            }
            return builder.ToString();
        }
    }
}

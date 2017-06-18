using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace E11_SemanticHTML
{
    public class SemanticHTML
    {
        public static void Main()
        {
            var semanticHTML = new StringBuilder();

            while (true)
            {
                var htmlLine = Console.ReadLine();
                if (htmlLine == "END") break;

                string patternOpeningTag = @"(?<indent>.*?)<div(?<attr1>.*?\s*?)(id|class)\s*?=\s*?""(?<tag>.*?)""(?<attr2>.*?\s*?)>";
                string pattenClosingTag = @"(?<indent>.*?)<\/div>\s*?<!--\s*?(?<tag>[^\s]*?)\s*?-->";

                if (Regex.IsMatch(htmlLine, patternOpeningTag))
                {
                    htmlLine = ConvertOpeningTagLine(htmlLine, patternOpeningTag);
                }
                if (Regex.IsMatch(htmlLine, pattenClosingTag))
                {
                    htmlLine = ConvertClosingTagLine(htmlLine, pattenClosingTag);
                }

                semanticHTML.AppendLine(htmlLine);
            }

            Console.WriteLine(semanticHTML.ToString());
        }

        private static string ConvertClosingTagLine(string htmlLine, string pattern)
        {
            var match = Regex.Match(htmlLine, pattern);
            var validTags = new[] { "main", "header", "nav", "article", "section", "aside", "footer" };

            if (!validTags.Contains(match.Groups["tag"].Value))
            {
                return htmlLine;
            }

            var modifiedLine = new StringBuilder()
                    .Append(match.Groups["indent"])
                    .Append("</")
                    .Append(match.Groups["tag"])
                    .Append(">");

            return modifiedLine.ToString();
        }

        private static string ConvertOpeningTagLine(string htmlLine, string pattern)
        {
            var match = Regex.Match(htmlLine, pattern);

            var tag = new StringBuilder()
                    .Append(match.Groups["tag"])
                    .Append(" ")
                    .Append(match.Groups["attr1"])
                    .Append(" ")
                    .Append(match.Groups["attr2"]);
            var trimmedTag = Regex.Replace(tag.ToString(), @"\s+", " ")
                    .Trim();
            var modifiedLine = new StringBuilder()
                    .Append(match.Groups["indent"])
                    .Append("<")
                    .Append(trimmedTag)
                    .Append(">");

            return modifiedLine.ToString();
        }
    }
}

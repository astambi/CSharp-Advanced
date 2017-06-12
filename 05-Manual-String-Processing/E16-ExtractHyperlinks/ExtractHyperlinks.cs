using System;
using System.Collections.Generic;
using System.Text;

namespace E16_ExtractHyperlinks
{
    public class ExtractHyperlinks
    {
        public static void Main()
        {
            var html = ReadHTML();
            var elements = ExtractElements(html);
            var hrefs = ExtractHrefs(elements);
            var hyperlinks = ExtractLinks(hrefs);
            PrintHyperlinks(hyperlinks);
        }
        private static void PrintHyperlinks(List<string> hyperlinks)
        {
            if (hyperlinks.Count != 0)
            {
                Console.WriteLine(string.Join("\n", hyperlinks));
            }
        }

        private static List<string> ExtractLinks(List<string> hrefs)
        {
            var hyperlinks = new List<string>();

            foreach (var href in hrefs)
            {
                var hrefLen = "href=".Length;
                var hyperlink = href.Substring(hrefLen);
                hyperlink = hyperlink
                            .TrimEnd('>')
                            .Trim('"')
                            .Trim('\'');
                hyperlinks.Add(hyperlink);
            }

            return hyperlinks;
        }

        private static List<string> ExtractHrefs(List<string> elements)
        {
            var hrefs = new List<string>();
            foreach (var element in elements)
            {
                var attributes = element.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                var attrBuilder = new StringBuilder();

                foreach (var attr in attributes)
                {
                    if (attr.Contains("href="))
                    {
                        if (!attr.Contains("(") ||
                            (attr.Contains("(") && attr.Contains(")")))
                        {
                            hrefs.Add(attr);
                        }
                        else
                        {
                            attrBuilder.Append(attr); // collect all href subparts
                        }
                    }
                    else if (attrBuilder.Length != 0)
                    {
                        if (!attr.Contains(")"))
                        {
                            attrBuilder.Append(" ").Append(attr);
                        }
                        else
                        {
                            attrBuilder.Append(" ").Append(attr);
                            hrefs.Add(attrBuilder.ToString());
                            attrBuilder = new StringBuilder();
                        }
                    }
                }
            }

            return hrefs;
        }

        private static string RemoveWhiteSpaces(string element)
        {
            while (element.Contains(" =") || element.Contains("= ") ||
                   element.Contains("\t=") || element.Contains("=\t"))
            {
                element = element
                        .Replace("\t=", "=")
                        .Replace(" =", "=")
                        .Replace("=\t", "=")
                        .Replace("= ", "=")
                        .Trim();
            }

            return element;
        }

        private static List<string> ExtractElements(string html)
        {
            var openingTag = "<a";
            var closingTag = ">";
            var openingIndex = 0;
            var closingIndex = -1;
            var elements = new List<string>();

            while (true)
            {
                openingIndex = html.IndexOf(openingTag, closingIndex + 1);
                if (openingIndex == -1) break;

                closingIndex = html.IndexOf(closingTag, openingIndex);
                if (closingIndex == -1) break;

                var element = html.Substring(openingIndex, closingIndex - openingIndex + 1);
                element = RemoveWhiteSpaces(element);
                elements.Add(element);
            }

            return elements;
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

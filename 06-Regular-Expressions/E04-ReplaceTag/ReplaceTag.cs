using System;
using System.Text;
using System.Text.RegularExpressions;

namespace E04_ReplaceTag
{
    public class ReplaceTag
    {
        public static void Main()
        {
            var html = ReadHTML();
            var pattern = @"<a(\s+href\s*=\s*.+?)>(.*?)<\/a>";
            
            // Replace matches
            var result = Regex.Replace(html, pattern, "[URL$1]$2[/URL]");
            
            //var result = Regex.Replace(html, pattern, m => $"[URL{m.Groups[1]}]{m.Groups[2]}[/URL]");
            
            //var result = Regex.Replace(html, pattern, delegate (Match m)
            //{
            //    return $"[URL{m.Groups[1]}]{m.Groups[2]}[/URL]";
            //});

            Console.WriteLine(result);
        }

        private static string ReadHTML()
        {
            var builder = new StringBuilder();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end") break;

                builder.AppendLine(input);
            }
            return builder.ToString();
        }
    }
}

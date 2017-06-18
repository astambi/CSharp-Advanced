using System;
using System.Text;
using System.Text.RegularExpressions;

namespace L05_ExtractTags
{
    public class ExtractTags
    {
        public static void Main()
        {
            var html = ReadHTML();

            var regex = new Regex(@"<.+?>");
            var matches = regex.Matches(html);
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }

        private static string ReadHTML()
        {
            var html = new StringBuilder();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                html.Append(input);
            }
            return html.ToString();
        }
    }
}

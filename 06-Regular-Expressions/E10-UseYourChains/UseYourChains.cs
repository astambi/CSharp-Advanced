using System;
using System.Text;
using System.Text.RegularExpressions;

namespace E10_UseYourChains
{
    public class UseYourChains
    {
        public static void Main()
        {
            var encodedText = ExtractTextFromHTML();
            var decodedText = GetDecodedText(encodedText);
            Console.WriteLine(decodedText);
        }

        private static string GetDecodedText(string text)
        {
            var builder = new StringBuilder();
            foreach (var ch in text)
            {
                if (!Char.IsLetter(ch))
                {
                    builder.Append(ch);
                    continue;
                }

                var charDiff = 'n' - 'a'; // [a-m] <=> [n-z]
                if (ch < 'n')
                {
                    builder.Append((char)(ch + charDiff));  // [a-m] => [n-z]
                }
                else
                {
                    builder.Append((char)(ch - charDiff));  // [n-z] => [a-m]
                }
            }

            var decodedText = builder.ToString();
            decodedText = Regex.Replace(decodedText, @"\s+", " ");
            decodedText = decodedText.Trim();

            return decodedText;
        }

        private static string ExtractTextFromHTML()
        {
            var html = Console.ReadLine();
            var matches = Regex.Matches(html, @"<p>(.*?)<\/p>");

            var builder = new StringBuilder();
            foreach (Match match in matches)
            {
                var text = Regex.Replace(match.Groups[1].Value, @"[^a-z\d]+", " ");
                builder.Append(text);
            }

            return builder.ToString();
        }
    }
}

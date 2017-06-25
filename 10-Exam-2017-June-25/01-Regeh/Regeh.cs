using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01_Regeh
{
    public class Regeh
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var len = input.Length;

            var currentIndex = 0;
            var builder = new StringBuilder();

            string pattern = @"\[[^[< ]+?<([0-9]+?)REGEH([0-9]+?)>[^]> ]+?]";
            var matches = Regex.Matches(input, pattern);

            if (Regex.IsMatch(input, pattern))
            {
                foreach (Match match in matches)
                {
                    if (Regex.IsMatch(match.Value, @"\s+")) continue;

                    currentIndex += int.Parse(match.Groups[1].Value);
                    builder = AppendChar(input, currentIndex, builder);

                    currentIndex += int.Parse(match.Groups[2].Value);
                    builder = AppendChar(input, currentIndex, builder);
                }
                Console.WriteLine(builder.ToString());
            }
        }

        private static StringBuilder AppendChar(string input, int currentIndex, StringBuilder builder)
        {
            var len = input.Length;
            if (currentIndex < len)
            {
                builder.Append(input[currentIndex]);
            }
            else
            {
                builder.Append(input[currentIndex % len + 1]);
            }
            return builder;
        }
    }
}

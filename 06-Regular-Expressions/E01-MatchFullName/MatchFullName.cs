using System;
using System.Text.RegularExpressions;

namespace E01_MatchFullName
{
    public class MatchFullName
    {
        public static void Main()
        {
            var regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end") break;

                var matches = regex.Matches(input);
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}

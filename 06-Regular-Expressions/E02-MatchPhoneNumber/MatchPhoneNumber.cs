using System;
using System.Text.RegularExpressions;

namespace E02_MatchPhoneNumber
{
    public class MatchPhoneNumber
    {
        public static void Main()
        {
            var regex = new Regex(@"(?=^| )\+359( |-)2\1\d{3}\1\d{4}\b");

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end") break;

                var matches = regex.Matches(input);
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace E07_ValidUsernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            var validUsernames = ExtractValidUsernames();
            var maxSumUsernames = ExtractMaxSumUsernames(validUsernames);
            Console.WriteLine(string.Join("\n", maxSumUsernames));
        }

        private static HashSet<string> ExtractMaxSumUsernames(string[] validUsernames)
        {
            var maxSumUsernames = new HashSet<string>();
            var maxSum = int.MinValue;

            for (var i = 1; i < validUsernames.Length; i++)
            {
                var currentSum = validUsernames[i].Length + validUsernames[i - 1].Length;
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxSumUsernames.Clear();
                    maxSumUsernames.Add(validUsernames[i - 1]);
                    maxSumUsernames.Add(validUsernames[i]);
                }
            }
            return maxSumUsernames;
        }

        private static string[] ExtractValidUsernames()
        {
            var input = Console.ReadLine();
            var usernames = Regex.Split(input, @"[ ()/\\]+");
            var validUsernamesRegex = new Regex(@"^[a-zA-Z]\w{2,24}$");
            return usernames
                    .Where(u => validUsernamesRegex.IsMatch(u))
                    .ToArray();
        }
    }
}

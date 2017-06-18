using System;
using System.Text.RegularExpressions;

namespace E03_SeriesOfLetters
{
    public class SeriesOfLetters
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            // Replace matches
            var result = Regex.Replace(input, @"(\w)\1+", "$1"); // group 1

            //var result = Regex.Replace(input, @"(\w)\1+", m => $"{m.Groups[1]}");

            //var result = Regex.Replace(input, @"(\w)\1+", delegate (Match m)
            //{
            //    return m.Groups[1].Value.ToString();
            //});

            Console.WriteLine(result);
        }
    }
}

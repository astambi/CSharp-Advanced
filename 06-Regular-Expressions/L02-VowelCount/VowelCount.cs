using System;
using System.Text.RegularExpressions;

namespace L02_VowelCount
{
    public class VowelCount
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var regex = new Regex(@"[aeiouyAEIOUY]");
            var matches = regex.Matches(text);
            Console.WriteLine($"Vowels: {matches.Count}");
        }
    }
}

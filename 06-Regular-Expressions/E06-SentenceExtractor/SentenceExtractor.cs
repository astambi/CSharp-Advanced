using System;
using System.Text.RegularExpressions;

namespace E06_SentenceExtractor
{
    public class SentenceExtractor
    {
        public static void Main()
        {
            var keyword = Console.ReadLine();
            var text = Console.ReadLine();

            var sentenceRegex = new Regex(@"(?=^|\s).*?[.?!]");

            var sentences = sentenceRegex.Matches(text);
            foreach (Match sentence in sentences)
            {
                var regexContainingKeyword = new Regex($@"\b{keyword}\b");
                if (regexContainingKeyword.IsMatch(sentence.Value))
                {
                    Console.WriteLine(sentence);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace L04_SpecialWords
{
    public class SpecialWords
    {
        public static void Main()
        {
            var specialWords = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var separators = " ()[]<>,-!?‘’".ToCharArray();
            var words = Console.ReadLine()
                        .TrimEnd('.')
                        .Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var specialWordsCount = new Dictionary<string, int>();

            foreach (var word in specialWords)
            {
                specialWordsCount[word] = 0;
            }
            foreach (var word in words)
            {
                if (specialWordsCount.ContainsKey(word))
                {
                    specialWordsCount[word]++;
                }
            }
            foreach (var word in specialWordsCount)
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}

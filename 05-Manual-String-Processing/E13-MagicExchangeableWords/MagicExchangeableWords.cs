using System;
using System.Collections.Generic;

namespace E13_MagicExchangeableWords
{
    public class MagicExchangeableWords
    {
        public static void Main()
        {
            var words = Console.ReadLine()
                        //.Trim().ToLower()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length < 2)
            {
                Console.WriteLine("false"); return;
            }

            Console.WriteLine(HasCorrectMapping(words).ToString().ToLower());
        }

        private static string[] SortByLengthASC(string[] texts)
        {
            if (texts[0].Length > texts[1].Length)
            {
                Array.Reverse(texts);
            }
            return texts;
        }

        private static bool HasCorrectMapping(string[] words)
        {
            words = SortByLengthASC(words);

            string shorterWord = words[0];
            string longerWord = words[1];
            var commonLen = Math.Min(longerWord.Length, shorterWord.Length);
            var mappingTable = new Dictionary<char, char>();

            for (var i = 0; i < commonLen; i++)
            {
                var shorterWordChar = shorterWord[i];
                var longerWordChar = longerWord[i];

                if (!mappingTable.ContainsKey(shorterWordChar) &&
                    !mappingTable.ContainsValue(longerWordChar))
                {
                    mappingTable[shorterWordChar] = longerWordChar;
                }
                else if (mappingTable.ContainsKey(shorterWordChar) &&
                         mappingTable[shorterWordChar] != longerWordChar)
                {
                    return false;
                }
                else if (!mappingTable.ContainsKey(shorterWordChar) &&
                          mappingTable.ContainsValue(longerWordChar))
                {
                    return false;
                }
            }

            if (shorterWord.Length != longerWord.Length)
            {
                var remainingSubstring = longerWord.Substring(commonLen);
                foreach (var ch in remainingSubstring)
                {
                    if (!mappingTable.ContainsValue(ch))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

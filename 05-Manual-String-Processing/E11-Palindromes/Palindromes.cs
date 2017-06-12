using System;
using System.Collections.Generic;

namespace E11_Palindromes
{
    public class Palindromes
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split(" ,.?!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var palindromes = GetUniquePalindromes(words);
            Console.WriteLine("[{0}]", string.Join(", ", palindromes));
        }

        private static bool IsPalindrome(string text)
        {
            for (int i = 0; i <= (text.Length - 1) / 2; i++)
            {
                if (text[i] != text[text.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        private static SortedSet<string> GetUniquePalindromes(string[] words)
        {
            var palindromes = new SortedSet<string>();
            foreach (var word in words)
            {
                if (IsPalindrome(word))
                {
                    palindromes.Add(word);
                }
            }

            return palindromes;
        }
    }
}

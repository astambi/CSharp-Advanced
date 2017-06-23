using System;
using System.Collections.Generic;
using System.Text;

namespace _03_NMS
{
    public class NMS
    {
        public static void Main()
        {
            var message = GetMessage();
            var delimiter = Console.ReadLine();
            var increasingWords = GetIncreasingWords(message);
            Console.WriteLine(string.Join(delimiter, increasingWords));
        }

        private static List<string> GetIncreasingWords(string message)
        {
            var increasingWords = new List<string>();
            var currentChars = new Stack<char>();
            foreach (var letter in message)
            {
                if (currentChars.Count == 0)
                {
                    currentChars.Push(letter);
                }
                else if (CharToLower(letter) >= CharToLower(currentChars.Peek()))
                {
                    currentChars.Push(letter);
                }
                else
                {
                    increasingWords.Add(ReverseWord(currentChars));
                    currentChars.Clear();
                    currentChars.Push(letter);
                }
            }
            increasingWords.Add(ReverseWord(currentChars));
            return increasingWords;
        }

        private static string ReverseWord(Stack<char> charsStack)
        {
            var reversedArr = new char[charsStack.Count];
            var i = charsStack.Count - 1;
            foreach (var ch in charsStack)
            {
                reversedArr[i--] = ch;
            }            
            return new string(reversedArr);
        }

        private static char CharToLower(char ch)
        {
            if (Char.IsLower(ch)) return ch;
            return (char)(ch - 'A' + 'a');
        }

        private static string GetMessage()
        {
            var builder = new StringBuilder();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "---NMS SEND---") break;

                builder.Append(input);
            }
            return builder.ToString();
        }
    }
}

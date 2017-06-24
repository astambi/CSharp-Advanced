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
            var words = new List<string>();
            var currentWord = new StringBuilder();
            currentWord.Append(message[0]);

            for (int i = 1; i < message.Length; i++)
            {
                if (char.ToLower(message[i]) >= char.ToLower(message[i - 1]))
                {
                    currentWord.Append(message[i]);
                }
                else
                {
                    words.Add(currentWord.ToString());
                    currentWord.Clear();
                    currentWord.Append(message[i]);
                }
                if (i == message.Length - 1)
                {
                    words.Add(currentWord.ToString());
                }
            }
            return words;
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

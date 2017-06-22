using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace E12_LittleJohn
{
    public class LittleJohn
    {
        public static void Main()
        {
            var count = GetArrowsCount();
            var encryptedMsg = EncryptCount(count);
            Console.WriteLine(encryptedMsg);
        }

        private static long EncryptCount(int number)
        {
            var binary = Convert.ToString(number, 2);
            binary += Reverse(binary);
            var resultDecimal = Convert.ToInt32(binary, 2);

            return resultDecimal;
        }

        private static string Reverse(string text)
        {
            var builder = new StringBuilder();
            for (int i = text.Length - 1; i >= 0; i--)
            {
                builder.Append(text[i]);
            }
            return builder.ToString();
        }
        
        private static int GetArrowsCount()
        {
            var arrowPatterns = new[] { ">>>----->>", ">>----->", ">----->" };
            var arrowsCount = new List<int>() { 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                var input = Console.ReadLine();
                for (int arrSize = 0; arrSize < arrowPatterns.Length; arrSize++)
                {
                    arrowsCount[arrSize] += Regex.Matches(input, arrowPatterns[arrSize]).Count;
                    input = Regex.Replace(input, arrowPatterns[arrSize], " "); // NB!!! string.Empty might distort results ">" + "----->"
                }
            }
            int number = int.Parse(string.Empty + arrowsCount[2] + arrowsCount[1] + arrowsCount[0]);
            return number;
        }
    }
}

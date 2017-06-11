using System;
using System.Text;

namespace E07_SumBigNumbers
{
    public class SumBigNumbers
    {
        public static void Main()
        {
            // Using BigInteger / BigDecimal classes not allowed
            var num1 = Console.ReadLine();
            var num2 = Console.ReadLine();

            var sumReversed = CalcReversedSum(num1, num2);
            Console.WriteLine(ReverseString(sumReversed));
        }

        private static string ReverseString(string text)
        {
            var reversedText = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                reversedText.Append(text[text.Length - 1 - i]);
            }
            return reversedText.ToString();
        }

        private static string CalcReversedSum(string num1, string num2)
        {
            var maxLen = Math.Max(num1.Length, num2.Length);
            var index = 0;
            var remainder = 0;
            var builder = new StringBuilder();
            while (index <= maxLen)
            {
                var digitNum1 = GetDigit(num1, index);
                var digitNum2 = GetDigit(num2, index++);

                var sum = digitNum1 + digitNum2 + remainder;
                builder.Append(sum % 10);
                remainder = sum / 10;
            }
            return builder.ToString().TrimEnd('0'); // remove ending 0
        }

        private static int GetDigit(string numStr, int index)
        {
            var len = numStr.Length;
            if (index >= len) return 0;
            return int.Parse(numStr[len - 1 - index].ToString());
        }
    }
}

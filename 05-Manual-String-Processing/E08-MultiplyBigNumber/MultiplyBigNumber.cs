using System;
using System.Text;

namespace E08_MultiplyBigNumber
{
    public class MultiplyBigNumber
    {
        public static void Main()
        {
            // Using BigInteger / BigDecimal classes not allowed
            var bigNumber = Console.ReadLine();
            var digit = int.Parse(Console.ReadLine());

            var productReversed = CalcProduct(bigNumber, digit);
            Console.WriteLine(ReverseString(productReversed));
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

        private static string CalcProduct(string bigNumber, int digit)
        {
            if (digit == 0) return "0";

            var len = bigNumber.Length;
            var remainder = 0;
            var builder = new StringBuilder();
            for (int index = 0; index <= len; index++)
            {
                var digitNum1 = GetDigit(bigNumber, index);
                var product = digitNum1 * digit + remainder;
                builder.Append(product % 10);
                remainder = product / 10;
            }
            return builder.ToString().TrimEnd('0'); // trim last zero
        }

        private static int GetDigit(string numStr, int index)
        {
            var len = numStr.Length;
            if (index >= len) return 0;
            return int.Parse(numStr[len - 1 - index].ToString());
        }
    }
}

using System;

namespace E03_FormattingNumbers
{
    public class FormattingNumbers
    {
        private const int width = 10;

        public static void Main()
        {
            var whiteSpaceSeparators = " \n\t".ToCharArray();
            var numbersStr = Console.ReadLine().Split(whiteSpaceSeparators, StringSplitOptions.RemoveEmptyEntries);
            var num1 = int.Parse(numbersStr[0]);
            var num2 = double.Parse(numbersStr[1]);
            var num3 = double.Parse(numbersStr[2]);
            var num1Bin = Convert.ToString(num1, 2);
            if (num1Bin.Length > width)
            {
                num1Bin = num1Bin.Substring(0, width);
            }
            Console.WriteLine($"|{num1,-width:X}|{num1Bin.PadLeft(width, '0')}|{num2,width:f2}|{num3,-width:f3}|");
        }
    }
}

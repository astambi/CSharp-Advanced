using System;
using System.Numerics;
using System.Text;

namespace E04_ConvertFromBase10ToBaseN
{
    public class ConvertFromBase10ToBaseN
    {
        public static void Main()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var baseN = int.Parse(args[0]);
            var numberDec = BigInteger.Parse(args[1]); // [0, 10e-50]

            Console.WriteLine(CalcNumberInBaseN(baseN, numberDec));
        }

        private static string CalcNumberInBaseN(int baseN, BigInteger number)
        {
            var remainders = new StringBuilder();
            while (number != 0)
            {
                remainders.Append(number % baseN);
                number /= baseN;
            }

            var numberBaseN = new StringBuilder();
            for (int i = remainders.Length - 1; i >= 0; i--)
            {
                numberBaseN.Append(remainders[i]);
            }
            return numberBaseN.ToString();
        }
    }
}

using System;
using System.Numerics;

namespace E05_ConvertFromBaseNToBase10
{
    public class ConvertFromBaseNToBase10
    {
        public static void Main()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var baseN = int.Parse(args[0]);
            var numberBaseN = args[1];

            Console.WriteLine(CalcDecNumberFromBaseN(baseN, numberBaseN));
        }

        private static BigInteger CalcDecNumberFromBaseN(int baseN, string numberBaseN)
        {
            BigInteger numberDec = 0;
            for (int power = 0; power < numberBaseN.Length; power++)
            {
                numberDec += int.Parse(numberBaseN[numberBaseN.Length - 1 - power].ToString()) * CalcNumberRaisedToPower(baseN, power);
            }
            return numberDec;
        }

        private static BigInteger CalcNumberRaisedToPower(int number, int power)
        {
            BigInteger result = 1;
            for (int p = 1; p <= power; p++)
            {
                result *= number;
            }
            return result;
        }
    }
}
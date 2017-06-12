using System;

namespace E14_LettersChangeNumbers
{
    public class LettersChangeNumbers
    {
        public static void Main()
        {
            var args = Console.ReadLine()
                        .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var result = CalcSumTotal(args);
            Console.WriteLine($"{result:f2}");
        }

        private static decimal CalcSumTotal(string[] args)
        {
            decimal result = 0m;
            foreach (var arg in args)
            {
                result += CalcSumElements(arg);
            }
            return result;
        }

        private static decimal CalcSumElements(string arg)
        {
            var firstLetter = arg[0];
            var lastLetter = arg[arg.Length - 1];
            var number = int.Parse(arg.Substring(1, arg.Length - 2));
            decimal sum = number;

            switch (Char.IsUpper(firstLetter))
            {
                case true: sum /= GetLetterPosition(firstLetter); break;
                case false: sum *= GetLetterPosition(firstLetter); break;
            }
            switch (Char.IsUpper(lastLetter))
            {
                case true: sum -= GetLetterPosition(lastLetter); break;
                case false: sum += GetLetterPosition(lastLetter); break;
            }
            return sum;
        }

        private static int GetLetterPosition(char letter)
        {
            if (Char.IsUpper(letter))
            {
                return (int)letter - 'A' + 1;
            }
            if (Char.IsLower(letter))
            {
                return (int)letter - 'a' + 1;
            }
            return 0;
        }
    }
}

using System;
using System.Linq;

namespace L03_CountUppercaseWords
{
    public class CountUppercaseWords
    {
        public static void Main()
        {
            //Func<string, bool> uppercaseWords = w => Char.IsUpper(w[0]);
            Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(w => Char.IsUpper(w[0]))
                    //.Where(uppercaseWords)  // Func
                    //.Where(UppercaseWords)  // Method
                    .ToList()
                    .ForEach(w => Console.WriteLine(w));
        }

        private static bool UppercaseWords(string s)
        {
            return Char.IsUpper(s[0]);
        }
    }
}

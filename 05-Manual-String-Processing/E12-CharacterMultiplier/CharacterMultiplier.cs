using System;

namespace E12_CharacterMultiplier
{
    public class CharacterMultiplier
    {
        public static void Main()
        {
            var strings = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var result = GetSumOfCharProducts(strings[0], strings[1]);
            Console.WriteLine(result);
        }

        private static long GetSumOfCharProducts(string textA, string textB)
        {
            var result = 0;
            var len = Math.Max(textA.Length, textB.Length);

            for (int i = 0; i < len; i++)
            {
                var codeA = GetCharCode(textA, i);
                var codeB = GetCharCode(textB, i);
                result += codeA * codeB;
            }

            return result;
        }

        private static int GetCharCode(string text, int index)
        {
            if (index >= text.Length) return 1;

            return (int)text[index];
        }
    }
}

using System;

namespace E06_CountSubstringOccurrences
{
    public class CountSubstringOccurrences
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToLower();
            var pattern = Console.ReadLine().ToLower();

            var count = CalcOccurrences1(text, pattern);
            //var count = CalcOccurrences2(text, pattern);

            Console.WriteLine(count);
        }

        private static int CalcOccurrences1(string text, string pattern)
        {
            var count = 0;
            while (true)
            {
                var index = text.IndexOf(pattern);
                if (index == -1) break;

                count++;
                text = text.Substring(index + 1);
            }
            return count;
        }

        private static int CalcOccurrences2(string text, string pattern)
        {
            var count = 0;
            var startIndex = -1;
            while (true)
            {
                startIndex = text.IndexOf(pattern, ++startIndex);
                if (startIndex == -1) break;

                count++;
            }
            return count;
        }
    }
}

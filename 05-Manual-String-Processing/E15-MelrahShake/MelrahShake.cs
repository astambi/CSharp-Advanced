using System;
using System.Text;

namespace E15_MelrahShake
{
    public class MelrahShake
    {
        private static string pattern;

        public static void Main(string[] args)
        {
            var text = Console.ReadLine();
            pattern = Console.ReadLine();

            while (true)
            {
                var firstIndex = text.IndexOf(pattern);
                var lastIndex = text.LastIndexOf(pattern);
                if (firstIndex == -1 || lastIndex == -1 || pattern == string.Empty)
                {
                    Console.WriteLine("No shake."); break;
                }
                text = RemovePattern(text, firstIndex, lastIndex);
            }
            Console.WriteLine(text);
        }

        private static string RemovePattern(string text, int firstIndex, int lastIndex)
        {
            var builder = new StringBuilder();
            builder.Append(text.Substring(0, firstIndex));
            builder.Append(text.Substring(firstIndex + pattern.Length, lastIndex - firstIndex - pattern.Length));
            builder.Append(text.Substring(lastIndex + pattern.Length));

            pattern = pattern.Remove(pattern.Length / 2, 1);
            Console.WriteLine("Shaked it.");

            return builder.ToString();
        }
    }
}

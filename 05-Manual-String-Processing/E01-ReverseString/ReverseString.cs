using System;
using System.Text;

namespace E01_ReverseString
{
    public class ReverseString
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            //ReverseString1(text);
            ReverseString2(text);
        }

        private static void ReverseString2(string text)
        {
            var chars = text.ToCharArray();
            Array.Reverse(chars);
            Console.WriteLine(chars);
        }

        private static void ReverseString1(string text)
        {
            var builder = new StringBuilder();
            for (int i = text.Length - 1; i >= 0; i--)
            {
                builder.Append(text[i]);
            }
            Console.WriteLine(builder.ToString());
        }
    }
}

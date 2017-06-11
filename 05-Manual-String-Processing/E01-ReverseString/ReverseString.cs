using System;
using System.Text;

namespace E01_ReverseString
{
    public class ReverseString
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var builder = new StringBuilder();
            for (int i = text.Length - 1; i >= 0; i--)
            {
                builder.Append(text[i]);
            }
            Console.WriteLine(builder.ToString());
        }
    }
}

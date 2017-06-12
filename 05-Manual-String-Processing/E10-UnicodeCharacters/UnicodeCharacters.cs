using System;
using System.Text;

namespace E10_UnicodeCharacters
{
    public class UnicodeCharacters
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var builder = new StringBuilder();

            foreach (var ch in text)
            {
                builder.AppendFormat(@"\u{0:x4}", (int)ch);
                //builder.Append(String.Format(@"\u{0:x4}", (int)ch));
            }
            Console.WriteLine(builder);
        }
    }
}

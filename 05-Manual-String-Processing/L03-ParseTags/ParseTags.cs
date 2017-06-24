using System;
using System.Text;

namespace L03_ParseTags
{
    public class ParseTags
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var tagOpen = "<upcase>";
            var tagClose = "</upcase>";
            var builder = new StringBuilder();

            if (text == null) return;

            while (true)
            {
                var indexOpen = text.IndexOf(tagOpen);
                var indexClose = text.IndexOf(tagClose);
                if (indexOpen == -1 || indexClose == -1)
                {
                    builder.Append(text); break;
                }

                builder.Append(text.Substring(0, indexOpen));
                var textUpper = text
                               .Substring(indexOpen + tagOpen.Length, indexClose - indexOpen - tagOpen.Length)
                               .ToUpper();
                builder.Append(textUpper);

                text = text.Substring(indexClose + tagClose.Length);
            }
            Console.WriteLine(builder.ToString());
        }
    }
}

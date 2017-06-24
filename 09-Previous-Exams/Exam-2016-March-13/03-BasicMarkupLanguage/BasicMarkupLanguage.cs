using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03_BasicMarkupLanguage
{
    public class BasicMarkupLanguage
    {
        private static int lineCount;

        public static void Main()
        {
            lineCount = 0;

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "<stop/>") break;

                string pattern = @"^\s*<\s*(?<tag>inverse|reverse|repeat)(?:\s+value\s*=\s*""(?<value>[0-9]+)"")?(?:\s+content\s*=\s*""(?<content>.+)"")\s*\/>$";
                var match = Regex.Match(input, pattern);
                if (!match.Success) continue;

                var tag = match.Groups["tag"].Value;
                var content = match.Groups["content"].Value; // regex guarantees content is not empty
                var value = match.Groups["value"].Value;

                switch (tag)
                {
                    case "inverse": InverseContent(content); break;
                    case "reverse": ReverseContent(content); break;
                    case "repeat":  RepeatContent(content, int.Parse(value)); break;
                    default: break;
                }
            }
        }

        private static void RepeatContent(string content, int repeatCount)
        {
            for (int i = 0; i < repeatCount; i++)
            {
                PrintResult(content);
            }
        }

        private static void ReverseContent(string content)
        {
            var builder = new StringBuilder();
            for (int i = content.Length - 1; i >= 0; i--)
            {
                builder.Append(content[i]);
            }
            PrintResult(builder.ToString());
        }

        private static void InverseContent(string content)
        {
            var builder = new StringBuilder();
            foreach (var ch in content)
            {
                if (!Char.IsLetter(ch))     builder.Append(ch);
                else if (Char.IsLower(ch))  builder.Append(char.ToUpper(ch));
                else                        builder.Append(char.ToLower(ch));
            }
            PrintResult(builder.ToString());
        }

        private static void PrintResult(string result)
        {
            Console.WriteLine($"{++lineCount}. {result}");
        }
    }
}

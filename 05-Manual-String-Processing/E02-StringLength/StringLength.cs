using System;

namespace E02_StringLength
{
    public class StringLength
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            if (text.Length < 20)
            {
                text = text.PadRight(20, '*');
            }
            else if (text.Length > 20)
            {
                text = text.Substring(0, 20);
            }
            Console.WriteLine(text);
        }
    }
}

using System;
using System.Text;

namespace L05_ConcatenateStrings
{
    public class ConcatenateStrings
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var builder = new StringBuilder(n);

            for (int i = 0; i < n; i++)
            {
                builder.Append(Console.ReadLine());
                builder.Append(" ");
            }
            Console.WriteLine(builder.ToString().TrimEnd());
        }
    }
}

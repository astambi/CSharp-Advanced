using System;
using System.Text.RegularExpressions;

namespace L07_ValidTime
{
    public class ValidTime
    {
        public static void Main()
        {
            var regex = new Regex(@"^(0\d|1[0-2]):([0-5]\d):([0-5]\d) (AM|PM)$");

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                if (regex.IsMatch(input))
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }
            }
        }
    }
}

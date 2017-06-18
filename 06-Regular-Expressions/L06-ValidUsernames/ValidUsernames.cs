using System;
using System.Text.RegularExpressions;

namespace L06_ValidUsernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            var regex = new Regex(@"^[\w-]{3,16}$");

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

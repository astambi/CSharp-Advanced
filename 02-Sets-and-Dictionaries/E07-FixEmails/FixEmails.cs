using System;
using System.Collections.Generic;

namespace E07_FixEmails
{
    public class FixEmails
    {
        public static void Main()
        {
            var emails = GetEmails();
            PrintEmails(emails);
        }

        private static Dictionary<string, string> GetEmails()
        {
            var emails = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (input == "stop") break;

                string email = Console.ReadLine().Trim();
                if (email.ToLower().EndsWith("uk") || email.ToLower().EndsWith("us")) continue;

                emails[input] = email;
            }

            return emails;
        }

        private static void PrintEmails(Dictionary<string, string> emails)
        {
            foreach (var kvp in emails)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}

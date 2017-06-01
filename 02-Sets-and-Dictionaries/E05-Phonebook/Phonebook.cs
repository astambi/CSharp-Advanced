using System;
using System.Collections.Generic;

namespace E05_Phonebook
{
    public class Phonebook
    {
        public static void Main()
        {
            var phonebook = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "search") break;

                if (String.IsNullOrEmpty(input)) continue;

                var contact = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = contact[0];
                string phoneNumber = contact.Length > 1 ? contact[1] : null;
                phonebook[name] = phoneNumber; // add or update
            }
            while (true)
            {
                string name = Console.ReadLine();
                if (name == "stop") break;

                if (phonebook.ContainsKey(name))
                {
                    Console.WriteLine($"{name} -> {phonebook[name]}");
                }
                else
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }
            }
        }
    }
}

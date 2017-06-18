using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace E09_QueryMess
{
    public class QueryMess
    {
        public static void Main()
        {
            // TODO 90/100

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                var separators = "[&?]";
                if (!Regex.IsMatch(input, separators)) continue;

                var regex = new Regex(@"(%20|\+)+");
                var tokens = Regex.Split(input, separators)
                            .Where(x => x.Contains("="))
                            .Select(x => regex.Replace(x, " "))
                            .ToArray();
                var pairs = new Dictionary<string, List<string>>();
                foreach (var token in tokens)
                {
                    var pair = Regex.Split(token, "=")
                            .Select(x => x.Trim())
                            .ToArray();
                    var key = pair[0];
                    var value = pair[1];
                    if (!pairs.ContainsKey(key))
                    {
                        pairs[key] = new List<string>();
                    }
                    pairs[key].Add(value);
                }
                PrintPairs(pairs);
            }
        }

        private static void PrintPairs(Dictionary<string, List<string>> pairs)
        {
            foreach (var kvp in pairs)
            {
                Console.Write("{0}=[{1}]", kvp.Key, string.Join(", ", kvp.Value));
            }
            Console.WriteLine();
        }
    }
}

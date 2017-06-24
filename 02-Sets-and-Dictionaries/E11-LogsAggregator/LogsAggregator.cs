using System;
using System.Collections.Generic;
using System.Linq;

namespace E11_LogsAggregator
{
    public class LogsAggregator
    {
        public static void Main()
        {
            PrintLogs(GetLogs());
        }

        private static void PrintLogs(SortedDictionary<string, SortedDictionary<string, int>> logs)
        {
            foreach (var kvp in logs)
            {
                // user: {sum of duration} [ip1, ip2, ...]
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Values.Sum()} [{string.Join(", ", kvp.Value.Keys)}]");
            }
        }

        private static SortedDictionary<string, SortedDictionary<string, int>> GetLogs()
        {
            // user, ip, duration
            var logs = new SortedDictionary<string, SortedDictionary<string, int>>();
            var logsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < logsCount; i++)
            {
                var args = Console.ReadLine()
                          .Trim()
                          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var ip = args[0];
                var user = args[1];
                var duration = int.Parse(args[2]);

                if (!logs.ContainsKey(user))
                {
                    logs[user] = new SortedDictionary<string, int>();
                }
                if (!logs[user].ContainsKey(ip))
                {
                    logs[user][ip] = 0;
                }
                logs[user][ip] += duration;
            }
            return logs;
        }
    }
}

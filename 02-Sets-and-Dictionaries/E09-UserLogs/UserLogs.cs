using System;
using System.Collections.Generic;
using System.Linq;

namespace E09_UserLogs
{
    public class UserLogs
    {
        public static void Main()
        {
            PrintUserLogs(GetUserLogs());
        }

        private static void PrintUserLogs(SortedDictionary<string, Dictionary<string, List<string>>> userLogs)
        {
            foreach (var userIp in userLogs)
            {
                var username = userIp.Key;
                var ipMsgCounts = userIp.Value.Select(x => $"{x.Key} => {x.Value.Count}"); // ip => msg count
                Console.WriteLine($"{username}: \n{string.Join(", ", ipMsgCounts)}.");
            }
        }

        private static SortedDictionary<string, Dictionary<string, List<string>>> GetUserLogs()
        {
            // usernames, IPs, msgs
            var userLogs = new SortedDictionary<string, Dictionary<string, List<string>>>();
            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (input == "end") break;

                var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var username = args[2].Substring("user=".Length);
                var ip = args[0].Substring("IP=".Length);
                var msg = args[1].Substring("message=".Length).Trim('\'');
                if (!userLogs.ContainsKey(username))
                {
                    userLogs[username] = new Dictionary<string, List<string>>();
                }
                if (!userLogs[username].ContainsKey(ip))
                {
                    userLogs[username][ip] = new List<string>();
                }
                userLogs[username][ip].Add(msg);
            }
            return userLogs;
        }
    }
}

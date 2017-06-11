using System;

namespace L02_ParseURLs
{
    public class ParseURLs
    {
        public static void Main()
        {
            var input = Console.ReadLine(); // [protocol]://[server]/[resource] 
            var protocolSeparator = "://";
            var resourceSeparator = "/";

            if (input == null ||
                input.IndexOf(protocolSeparator) == -1 ||
                input.Substring(input.IndexOf(protocolSeparator) + protocolSeparator.Length)
                     .IndexOf(resourceSeparator) == -1 ||
                input.IndexOf(protocolSeparator) != input.LastIndexOf(protocolSeparator))
            {
                Console.WriteLine("Invalid URL"); return;
            }

            var tokens = input.Split(new[] { protocolSeparator }, StringSplitOptions.RemoveEmptyEntries);
            var protocol = tokens[0];
            var indexResourceSeparator = tokens[1].IndexOf(resourceSeparator);
            var server = tokens[1].Substring(0, indexResourceSeparator);
            var resources = tokens[1].Substring(indexResourceSeparator + resourceSeparator.Length);

            Console.WriteLine($"Protocol = {protocol}\nServer = {server}\nResources = {resources}");
        }
    }
}

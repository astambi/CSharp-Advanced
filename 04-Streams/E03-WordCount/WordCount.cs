using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E03_WordCount
{
    public class WordCount
    {
        private const string path = "../../Files/";

        public static void Main()
        {
            Console.WriteLine($"Read words from '{path}words.txt'");
            Console.WriteLine($"Read text from '{path}text.txt'");
            Console.WriteLine($"Count words in text & save result in '{path}result.txt'");

            var wordsCount = new Dictionary<string, int>();

            using (var reader = new StreamReader($"{path}words.txt"))
            {
                while (true)
                {
                    var word = reader.ReadLine();
                    if (word == null) break;

                    word = word.ToLower();
                    if (!wordsCount.ContainsKey(word))
                    {
                        wordsCount[word] = 0;
                    }
                }
            }
            using (var reader = new StreamReader($"{path}text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null) break;

                    var currentWords = line
                        .Split(" .,?!:;-[]{}()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .ToArray();
                    foreach (var word in currentWords)
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }
                    }
                }
            }
            using (var writer = new StreamWriter($"{path}result.txt"))
            {
                var result = wordsCount
                            .OrderByDescending(w => w.Value)
                            .Select(w => $"{w.Key} - {w.Value}");
                foreach (var resultPair in result)
                {
                    writer.WriteLine(resultPair);
                }
            }
        }
    }
}

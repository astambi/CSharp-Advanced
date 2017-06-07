using System;
using System.IO;

namespace E01_OddLines
{
    public class OddLines
    {
        private const string path = "../../Files/";

        public static void Main()
        {
            Console.WriteLine($"Print odd lines from file '{path}CSharpAdvanced.txt'\n");

            using (var reader = new StreamReader($"{path}/CSharpAdvanced.txt"))
            {
                int lineNumber = 0;

                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null) break;

                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine($"Line {lineNumber}: {line}");
                    }
                    lineNumber++;
                }
            }
        }
    }
}

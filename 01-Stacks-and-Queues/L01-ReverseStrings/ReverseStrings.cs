namespace L01_ReverseStrings
{
    using System;
    using System.Collections.Generic;

    class ReverseStrings
    {
        static void Main()
        {
            ReverseStringsUsingStacks1();
            //ReverseStringsUsingStacks2();
        }

        private static void ReverseStringsUsingStacks1()
        {
            Stack<char> elements = new Stack<char>(Console.ReadLine());
            Console.WriteLine(string.Join("", elements));
        }

        private static void ReverseStringsUsingStacks2()
        {
            string input = Console.ReadLine();
            Stack<char> elements = new Stack<char>();
            foreach (var element in input)
            {
                elements.Push(element);
            }

            while (elements.Count > 0)
            {
                Console.Write(elements.Pop());
            }
            Console.WriteLine();
        }
    }
}

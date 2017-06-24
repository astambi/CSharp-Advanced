namespace E02_BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicStackOperations
    {
        static void Main()
        {
            var args = Console.ReadLine()
                      .Trim()
                      .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();
            var elementsArr = Console.ReadLine()
                      .Trim()
                      .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();

            if (args.Length < 3) return;

            int elementsCount = args[0];
            int elementToPopCount = args[1];
            int element = args[2];

            if (elementsCount != elementsArr.Length || elementsCount < elementToPopCount) return;

            var elementsStack = new Stack<int>(elementsArr);
            for (int i = 0; i < elementToPopCount; i++)
            {
                elementsStack.Pop();
            }

            if (elementsStack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (elementsStack.Contains(element))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(elementsStack.Min());
            }
        }
    }
}

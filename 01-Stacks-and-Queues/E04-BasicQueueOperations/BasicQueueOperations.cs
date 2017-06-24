namespace E04_BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicQueueOperations
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
            int elementsToRemoveCount = args[1];
            int element = args[2];

            if (elementsArr.Length != elementsCount || elementsCount < elementsToRemoveCount) return;

            var elementsQueue = new Queue<int>(elementsArr);
            for (int i = 0; i < elementsToRemoveCount; i++)
            {
                elementsQueue.Dequeue();
            }

            if (elementsQueue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (elementsQueue.Contains(element))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(elementsQueue.Min());
            }
        }
    }
}

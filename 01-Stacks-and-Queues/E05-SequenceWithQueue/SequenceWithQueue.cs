namespace E05_SequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    class SequenceWithQueue
    {
        static void Main()
        {
            var currentElement = long.Parse(Console.ReadLine());

            var sequenceElements = new Queue<long>();
            var sequence = new Queue<long>();
            sequence.Enqueue(currentElement);

            while (sequence.Count < 50)
            {
                sequence.Enqueue(currentElement + 1);
                sequenceElements.Enqueue(currentElement + 1);

                if (sequence.Count < 50)
                {
                    sequence.Enqueue(2 * currentElement + 1);
                    sequenceElements.Enqueue(2 * currentElement + 1);
                }

                if (sequence.Count < 50)
                {
                    sequence.Enqueue(currentElement + 2);
                    sequenceElements.Enqueue(currentElement + 2);
                    currentElement = sequenceElements.Dequeue();
                }
            }
            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}

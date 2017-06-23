using System;
using System.Collections.Generic;
using System.Linq;

namespace E01_SecondNature
{
    public class SecondNature
    {
        public static void Main()
        {
            var inputFlowers = Console.ReadLine()
                               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(long.Parse)
                               .Reverse();
            var inputBuckets = Console.ReadLine()
                               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(long.Parse);
            var flowers = new Stack<long>(inputFlowers);
            var buckets = new Stack<long>(inputBuckets);
            var secondNatureFlowers = new Queue<long>();

            while (AreExisting(buckets, flowers))
            {
                if (flowers.Peek() > buckets.Peek())            // more dust on flower than water
                {
                    flowers.Push(flowers.Pop() - buckets.Pop());// water flower, remove empty bucket
                }
                else if (buckets.Peek() > flowers.Peek())       // more water than flower dust
                {
                    buckets.Push(buckets.Pop() - flowers.Pop());// water flower, bloom, remove flower
                    if (buckets.Count > 1)                      // give extra water to next bucket
                    {
                        buckets.Push(buckets.Pop() + buckets.Pop());
                    }
                }
                else if (flowers.Peek() == buckets.Peek())      // eternally blooming flower
                {
                    secondNatureFlowers.Enqueue(flowers.Pop()); // transfer flower to second nature
                    buckets.Pop();                              // remove bucket
                }
            }

            Print(flowers, buckets, secondNatureFlowers);
        }

        private static bool AreExisting(Stack<long> buckets, Stack<long> flowers)
        {
            if (flowers.Any() && buckets.Any()) return true;

            return false;
        }

        private static void Print(Stack<long> flowers, Stack<long> buckets, Queue<long> secondNatureFlowers)
        {
            if (flowers.Count == 0)             Console.WriteLine(string.Join(" ", buckets));
            else                                Console.WriteLine(string.Join(" ", flowers));
            if (secondNatureFlowers.Count == 0) Console.WriteLine("None");
            else                                Console.WriteLine(string.Join(" ", secondNatureFlowers));
        }
    }
}

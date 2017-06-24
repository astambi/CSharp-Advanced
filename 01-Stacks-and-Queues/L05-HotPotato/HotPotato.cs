namespace L05_HotPotato
{
    using System;
    using System.Collections.Generic;

    class HotPotato
    {
        static void Main()
        {
            var kidsArr = Console.ReadLine()
                         .Trim()
                         .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int numberOfTosses = int.Parse(Console.ReadLine());

            if (kidsArr.Length == 0) return;

            Queue<string> kidsPlaying = new Queue<string>(kidsArr);
            while (kidsPlaying.Count > 1)
            {
                for (int i = 1; i < numberOfTosses; i++)
                {
                    kidsPlaying.Enqueue(kidsPlaying.Dequeue());
                }
                Console.WriteLine($"Removed {kidsPlaying.Dequeue()}");
            }
            Console.WriteLine($"Last is {kidsPlaying.Peek()}");
        }
    }
}

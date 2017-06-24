namespace L06_MathPotato
{
    using System;
    using System.Collections.Generic;

    class MathPotato
    {
        static void Main()
        {
            var kidsInput = Console.ReadLine()
                           .Trim()
                           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int numberOfTosses = int.Parse(Console.ReadLine());

            if (kidsInput.Length == 0) return;

            Queue<string> kidsPlaying = new Queue<string>(kidsInput);
            int cycleCount = 1;

            while (kidsPlaying.Count > 1)
            {
                for (int i = 1; i < numberOfTosses; i++)
                {
                    kidsPlaying.Enqueue(kidsPlaying.Dequeue());
                }
                if (isPrime(cycleCount++))
                {
                    Console.WriteLine($"Prime {kidsPlaying.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {kidsPlaying.Dequeue()}");
                }
            }
            Console.WriteLine($"Last is {kidsPlaying.Peek()}");
        }

        private static bool isPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                    return false;
            }

            return true;
        }
    }
}

namespace E06_TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TruckTour
    {
        static void Main()
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            var pumps = new Queue<long[]>();

            for (int i = 0; i < pumpsCount; i++)
            {
                // [amount of petrol, distance to next petrol pump]
                var pumpInfo = Console.ReadLine()
                              .Trim()
                              .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(long.Parse)
                              .ToArray();
                pumps.Enqueue(pumpInfo);
            }

            for (int pumpIndex = 0; pumpIndex < pumpsCount; pumpIndex++)
            {
                long petrol = 0, distance = 0;
                bool isCompleteTour = true;

                foreach (var pump in pumps)
                {
                    petrol += pump[0];
                    distance += pump[1];
                    if (petrol < distance)
                    {
                        isCompleteTour = false;
                        break;
                    }
                }
                if (isCompleteTour)
                {
                    Console.WriteLine(pumpIndex);
                    break;
                }
                pumps.Enqueue(pumps.Dequeue());
            }
        }
    }
}

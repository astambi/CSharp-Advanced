using System;
using System.Collections.Generic;
using System.Linq;

namespace L01_ParkingLot
{
    public class ParkingLot
    {
        public static void Main()
        {
            SortedSet<string> parkingLot = GetParkingLot();
            PrintParking(parkingLot);
        }

        private static void PrintParking(SortedSet<string> parkingLot)
        {
            if (parkingLot.Count != 0)
            {
                Console.WriteLine(string.Join("\n", parkingLot));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }

        private static SortedSet<string> GetParkingLot()
        {
            var parkingLot = new SortedSet<string>(); // sorted
            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (input == "END") break;

                var args = input
                          .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(x => x.Trim())
                          .ToArray();
                string direction = args[0];
                string carNumber = args[1];
                switch (direction)
                {
                    case "IN": parkingLot.Add(carNumber); break;
                    case "OUT": parkingLot.Remove(carNumber); break;
                }
            }

            return parkingLot;
        }
    }
}

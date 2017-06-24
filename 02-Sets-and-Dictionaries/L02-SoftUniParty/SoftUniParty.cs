using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace L02_SoftUniParty
{
    public class SoftUniParty
    {
        public static void Main()
        {
            var vipReservations = new SortedSet<string>();      // sorted
            var regularReservations = new SortedSet<string>();  // sorted

            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (input == "PARTY") break;

                AddReservation(vipReservations, regularReservations, input);
            }
            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (input == "END") break;

                RemoveReservation(vipReservations, regularReservations, input);
            }
            //PrintRemainingReservations(vipReservations, regularReservations);
            PrintRemainingReservationsUnited(vipReservations, regularReservations);
        }

        private static void PrintRemainingReservationsUnited(SortedSet<string> vipReservations, SortedSet<string> regularReservations)
        {
            vipReservations.UnionWith(regularReservations); // unite reservations, VIP first

            Console.WriteLine(vipReservations.Count);
            if (vipReservations.Count != 0)
            {
                Console.WriteLine(string.Join("\n", vipReservations));
            }
        }

        private static void PrintRemainingReservations(SortedSet<string> vipReservations, SortedSet<string> regularReservations)
        {
            Console.WriteLine(vipReservations.Count + regularReservations.Count);
            if (vipReservations.Count != 0)
            {
                Console.WriteLine(string.Join("\n", vipReservations));
            }
            if (regularReservations.Count != 0)
            {
                Console.WriteLine(string.Join("\n", regularReservations));
            }
        }

        private static void RemoveReservation(SortedSet<string> vipReservations, SortedSet<string> regularReservations, string reservation)
        {
            if (vipReservations.Contains(reservation))
            {
                vipReservations.Remove(reservation);
            }
            else if (regularReservations.Contains(reservation))
            {
                regularReservations.Remove(reservation);
            }
        }

        private static void AddReservation(SortedSet<string> vipReservations, SortedSet<string> regularReservations, string reservation)
        {
            if (reservation.Length != 8) return; // reservations input exactly 8 chars
            if (Regex.IsMatch(reservation, @"^\d"))
            {
                vipReservations.Add(reservation);
            }
            else
            {
                regularReservations.Add(reservation);
            }
        }
    }
}

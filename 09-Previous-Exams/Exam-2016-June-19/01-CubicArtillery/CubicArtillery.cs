using System;
using System.Collections.Generic;

namespace _01_CubicArtillery
{
    public class CubicArtillery
    {
        public static void Main()
        {
            var maxCapacity = int.Parse(Console.ReadLine());
            var bunkers = new Queue<string>();
            var weapons = new Queue<int>();
            var availableCapacity = maxCapacity;

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Bunker Revision") break;

                var data = input
                           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            // NB ToList() leads to Memory limit!!!

                foreach (var element in data)
                {
                    int weapon;
                    var isWeapon = int.TryParse(element, out weapon);

                    // add bunker
                    if (!isWeapon)
                    {
                        bunkers.Enqueue(element); continue;
                    }

                    // store weapon => several bunkers
                    var isStoredInBunker = false;
                    while (bunkers.Count > 1)
                    {
                        // store weapon
                        if (availableCapacity >= weapon)
                        {
                            weapons.Enqueue(weapon);
                            availableCapacity -= weapon;
                            isStoredInBunker = true;
                            break;
                        }

                        // print content of oldest bunker
                        if (weapons.Count == 0)
                        {
                            Console.WriteLine($"{bunkers.Dequeue()} -> Empty");
                        }
                        else
                        {
                            Console.WriteLine($"{bunkers.Dequeue()} -> {string.Join(", ", weapons)}");
                        }
                        // remove overflowing bunker & weapons
                        weapons.Clear();
                        availableCapacity = maxCapacity;
                    }

                    // store weapon => single bunker & valid weapon
                    if (!isStoredInBunker && weapon <= maxCapacity)
                    {
                        // remove weapons to free capacity
                        while (availableCapacity < weapon)
                        {
                            availableCapacity += weapons.Dequeue();
                        }
                        // store weapon
                        weapons.Enqueue(weapon);
                        availableCapacity -= weapon;
                    }
                }
            }
        }
    }
}
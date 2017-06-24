using System;
using System.Collections.Generic;
using System.Linq;

namespace E02_SetsOfElements
{
    public class SetsOfElements
    {
        public static void Main()
        {
            int[] setsLength = Console.ReadLine().Trim()
                              .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();
            var setN = new HashSet<int>();
            var setM = new HashSet<int>();
            for (int i = 0; i < setsLength[0]; i++)
            {
                setN.Add(int.Parse(Console.ReadLine().Trim()));
            }
            for (int i = 0; i < setsLength[1]; i++)
            {
                setM.Add(int.Parse(Console.ReadLine().Trim()));
            }
            setN.IntersectWith(setM);
            Console.WriteLine(string.Join(" ", setN));
        }
    }
}

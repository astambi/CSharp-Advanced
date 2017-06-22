using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_CubicsRube
{
    public class CubicsRube
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var unaffectedCells = size * size * size;
            long damageParticles = 0;

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Analyze") break;

                var tokens = input
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();
                var coordinates = tokens.Take(3);
                var particle = tokens[3];

                if (isInsideRube(coordinates, size) && particle > 0) // NB adding damage from particle
                {
                    unaffectedCells--;
                    damageParticles += particle;
                }
            }

            Console.WriteLine(damageParticles);
            Console.WriteLine(unaffectedCells);
        }

        private static bool isInsideRube(IEnumerable<int> coordinates, int size)
        {
            if (coordinates.Any(c => c < 0 || c > size)) return false;
            return true;
        }
    }
}

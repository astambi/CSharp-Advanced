using System;

namespace E02_Knights_Of_Honor
{
    public class KnightsOfHonor
    {
        public static void Main()
        {
            var persons = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = x => Console.WriteLine("Sir {0}", x);

            foreach (var p in persons)
            {
                print(p);
            }
        }
    }
}

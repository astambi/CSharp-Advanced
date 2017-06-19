using System;

namespace E01_ActionPlan
{
    public class ActionPlan
    {
        public static void Main()
        {
            var persons = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = x => Console.WriteLine(x);

            foreach (var p in persons)
            {
                print(p);
            }
        }
    }
}

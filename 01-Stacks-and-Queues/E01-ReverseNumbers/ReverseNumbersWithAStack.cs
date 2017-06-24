namespace E01_ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseNumbersWithAStack
    {
        static void Main()
        {
            var integersArr = Console.ReadLine()
                             .Trim()
                             .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse);
            var integersStack = new Stack<int>(integersArr);
            Console.WriteLine(string.Join(" ", integersStack));
        }
    }
}

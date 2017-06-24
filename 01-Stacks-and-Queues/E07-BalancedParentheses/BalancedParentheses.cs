namespace E07_BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParentheses
    {
        public static void Main()
        {
            var parenthesesArr = Console.ReadLine()
                                .Trim()
                                .ToCharArray();
            if (parenthesesArr.Length % 2 != 0) // odd count of parentheses
            {
                Console.WriteLine("NO"); return;
            }

            var parentheses = new Stack<char>();
            var parenthesesPairs = new Dictionary<char, char>();
            parenthesesPairs['{'] = '}';
            parenthesesPairs['['] = ']';
            parenthesesPairs['('] = ')';

            foreach (var parenthesis in parenthesesArr)
            {
                if (parenthesesPairs.ContainsKey(parenthesis)) // opening paranthesis
                {
                    parentheses.Push(parenthesis);
                }
                else
                {
                    var openingParenthesis = parentheses.Pop();
                    if (parenthesesPairs[openingParenthesis] != parenthesis) // non-matching parentheses
                    {
                        Console.WriteLine("NO"); return;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}

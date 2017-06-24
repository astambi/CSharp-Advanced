namespace L02_SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SimpleCalculator
    {
        static void Main()
        {
            Calculator1();
            //Calculator2();
        }
        private static void Calculator1()
        {
            var stringInput = Console.ReadLine()
                            .Trim()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Reverse()
                            .ToArray();
            Stack<string> elements = new Stack<string>(stringInput);

            int result = elements.Count > 0 ? int.Parse(elements.Pop()) : 0;
            while (elements.Count > 1)
            {
                string calcOperator = elements.Pop();
                int nextNumber = int.Parse(elements.Pop());
                result += calcOperator == "+" ? nextNumber : -nextNumber; // + and - only
            }
            Console.WriteLine(result);
        }

        private static void Calculator2()
        {
            var stringInput = Console.ReadLine()
                            .Trim()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Reverse()
                            .ToArray();
            Stack<string> elements = new Stack<string>(stringInput);

            while (elements.Count > 2)
            {
                int result = int.Parse(elements.Pop());
                string calcOperator = elements.Pop();
                int nextNumber = int.Parse(elements.Pop());

                result += calcOperator == "+" ? nextNumber : -nextNumber; // + and - only
                elements.Push(result.ToString());
            }
            Console.WriteLine(elements.Pop());
        }
    }
}

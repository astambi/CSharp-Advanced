using System;
using System.Collections.Generic;

namespace DemoKenov
{
    public class Demo
    {
        public static void Main()
        {
            string text = "--some txt---";
            text = text.TrimDashes();
            Console.WriteLine(text);

            var set = new HashSet<int>() { 1, 2, 3 };
            set.ForEach(n => Console.WriteLine(n));

            var words = new HashSet<string>() { "one", "two", "three" };
            words.ForEach(w => Console.WriteLine(w));

            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.ForEach(s => Console.WriteLine(s));
        }
    }
}

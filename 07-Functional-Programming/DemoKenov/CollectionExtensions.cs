using System;
using System.Collections.Generic;

namespace DemoKenov
{
    public static class CollectionExtensions
    {
        public static string TrimDashes(this string input) => input.Trim('-');

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
            return collection;
        }
    }
}

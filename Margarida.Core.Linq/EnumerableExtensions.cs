using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Margarida.Core.Linq
{
    public static class EnumerableExtensions
    {
        public class CompareOptions
        {
            private readonly IEnumerable<bool> booleans;
            public CompareOptions(IEnumerable<bool> booleans) => this.booleans = booleans;
            public bool All => booleans.All(x => x);
            public bool Any => booleans.Any(x => x);
        }

        public static CompareOptions ToCompare<T>(this IEnumerable<T> values, Func<T,T,bool> predicate)
        {
            return new CompareOptions(GetResultsOfComparison());

            IEnumerable<bool> GetResultsOfComparison()
            {
                T previous = values.FirstOrDefault();
                var enumerator = values.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    yield return predicate.Invoke(previous, enumerator.Current);
                }
            }
        }

        public static IEnumerable<IEnumerable<TValue>> ChunkBy<TValue>(this IEnumerable<TValue> values, int chunkSize)
        {
            return values.Select((v, i) => new { v, groupIndex = i / chunkSize })
                         .GroupBy(x => x.groupIndex)
                         .Select(g => g.Select(x => x.v));
        }

        public static void AddRange<T>(this IList<T> dest, IEnumerable<T> source)
        {
            foreach (var set in source)
                dest?.Add(set);
        }

        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> func)
        {
            var keyVisited = new HashSet<TKey>();
            foreach (T el in source) 
                if (keyVisited.Add(func(el))) 
                    yield return el;
        }

        public static T[] InsertAt<T>(this T[] arr, T element, int index)
        {
            var temp = new T[arr.Count() + 1];

            for (int i = 0; i < arr.Count(); i++)
            {
                if (i == index) continue;
                temp[i] = arr[i];
            }

            temp[index] = element;
            arr = temp;
            return arr;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = new Random().Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source) action(item);
        }

        public static T Most<T>(this IEnumerable<T> enumerable, Func<T, T, bool> predicate)
        {
            T actual = enumerable.FirstOrDefault();
            if (actual is null) return actual;

            foreach (var item in enumerable)
                if (predicate(item, actual))
                    actual = item;

            return actual;
        }
    }

}

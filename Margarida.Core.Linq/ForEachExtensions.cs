using System;
using System.Collections.Generic;

namespace Margarida.Core.Linq
{
    public static class ForEachExtensions
    {
        public static TupleEnumerator<T1, T2> GetEnumerator<T1, T2>(this (IEnumerable<T1>, IEnumerable<T2>) tuple)
        {
            return new TupleEnumerator<T1, T2>(tuple);
        }

        public ref struct TupleEnumerator<T1, T2>
        {
            private readonly IEnumerator<T1> sequence1;
            private readonly IEnumerator<T2> sequence2;

            public TupleEnumerator((IEnumerable<T1>, IEnumerable<T2>) tuple)
            {
                sequence1 = tuple.Item1.GetEnumerator();
                sequence2 = tuple.Item2.GetEnumerator();
            }

            public (T1, T2) Current => (sequence1.Current, sequence2.Current);

            public bool MoveNext() => sequence1.MoveNext() && sequence2.MoveNext();
        }

        public static IntEnumerator GetEnumerator(this Range range)
        {
            return new IntEnumerator(range);
        }

        public static IntEnumerator GetEnumerator(this int ends)
        {
            return new IntEnumerator(new Range(0, ends));
        }

        public ref struct IntEnumerator
        {
            private int _current;
            private readonly int _end;

            public IntEnumerator(Range range)
            {
                if (range.End.IsFromEnd)
                {
                    throw new InvalidOperationException();
                }

                _current = range.Start.Value - 1;
                _end = range.End.Value;
            }

            public int Current => _current;

            public bool MoveNext()
            {
                _current++;
                return _current <= _end;
            }

            public void Reset()
            {
                _current = 0;
            }
        }
    }

}

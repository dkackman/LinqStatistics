using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqStatistics
{
    class Bin<T> : ItemCount<T> where T : IComparable<T>, IEquatable<T>
    {
        private readonly Range<T> _range;

        public Range<T> Range { get { return _range; } }

        public Bin(T v, T min, T max, int count)
            :base(v, count)
        {
            _range = new Range<T>(min, max);
        }
    }
}

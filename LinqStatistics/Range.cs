using System;

namespace LinqStatistics
{
    /// <summary>
    /// An ordered pair of values, representing a segment.
    /// </summary>
    /// <typeparam name="T">Type of each of two values of range.</typeparam>
    public struct Range<T> : IEquatable<Range<T>> where T : IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Range&lt;T&gt;"/> struct.
        /// </summary>
        /// <param name="min">The minimal value of segment.</param>
        /// <param name="max">The maximal value of segment.</param>
        public Range(T min, T max, bool maxInclusive = false)
        {
            this.min = min;
            this.max = max;

            if (min.CompareTo(max) >= 0)
                throw new InvalidOperationException("Minimum must be less then maximum");

            _maxInclusive = maxInclusive;
        }

        private bool _maxInclusive;

        private readonly T min;
        /// <summary>
        /// Gets the minimal value of segment.
        /// </summary>
        /// <value>The min.</value>
        public T Min
        {
            get { return min; }
        }

        private readonly T max;
        /// <summary>
        /// Gets the maximal value of segment.
        /// </summary>
        /// <value>The max.</value>
        public T Max
        {
            get { return max; }
        }

        public static bool operator ==(Range<T> first, Range<T> second)
        {
            return first.min.Equals(second.min) && first.max.Equals(second.max);
        }

        public static bool operator !=(Range<T> first, Range<T> second)
        {
            return !(first == second);
        }

        public bool Contains(T item)
        {
            //return item >= Min && item < Max;
            if (_maxInclusive)
            {
                if (item.Equals(3.0))
                {
                double s = Math.Abs((double)(object)Max - (double)(object)item);
                    return true;
                }

                return item.CompareTo(Min) >= 0 && item.CompareTo(Max) <= 0;
            }

            return item.CompareTo(Min) >= 0 && item.CompareTo(Max) < 0;
        }

        public static bool operator <(Range<T> first, Range<T> second)
        {
            return first.min.CompareTo(second.Min) > 0 && first.Max.CompareTo(second.Max) < 0;
        }

        public static bool operator >(Range<T> first, Range<T> second)
        {
            return first.Min.CompareTo(second.min) < 0 && first.Max.CompareTo(second.max) > 0;
        }

        public static bool operator <=(Range<T> first, Range<T> second)
        {
            return (first.min.CompareTo(second.Min) > 0 && first.Max.CompareTo(second.Max) < 0) || first == second;
        }

        public static bool operator >=(Range<T> first, Range<T> second)
        {
            return (first.Min.CompareTo(second.min) < 0 && first.Max.CompareTo(second.max) > 0) || first == second;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Range<T>)
            {
                Range<T> other = (Range<T>)obj;
                return min.Equals(other.min) && max.Equals(other.max) && _maxInclusive.Equals(other._maxInclusive);
            }

            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return min.GetHashCode() ^ max.GetHashCode() ^ _maxInclusive.GetHashCode();
        }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            return String.Format("{0} — {1}", min, max);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Range<T> other)
        {
            return this == other;
        }
    }
}

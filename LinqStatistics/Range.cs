using System;

namespace LinqStatistics
{
    /// <summary>
    /// An ordered pair of values, representing a segment.
    /// </summary>
    public struct Range<T> : IEquatable<Range<T>>, IComparable, IComparable<Range<T>> where T : struct, IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Range[T]"/> struct.
        /// </summary>
        /// <param name="Min">The minimal value of segment.</param>
        /// <param name="Max">The maximal value of segment.</param>
        /// <param name="maxInclusive">When true Contains will include the Max value.</param>
        public Range(T Min, T Max, bool maxInclusive = false)
        {
            this.Min = Min;
            this.Max = Max;

            if (Min.CompareTo(Max) >= 0)
                throw new InvalidOperationException("Minimum must be less then maximum");

            MaxInclusive = maxInclusive;
        }

        /// <summary>
        /// Determines whether Max should be included in the range or excluded
        /// </summary>
        public bool MaxInclusive { get; private set; }

        /// <summary>
        /// Gets the minimal value of segment.
        /// </summary>
        /// <value>The Min.</value>
        public T Min { get; internal set; }

        /// <summary>
        /// Gets the maximal value of segment.
        /// </summary>
        /// <value>The Max.</value>
        public T Max { get; internal set; }

        public static bool operator ==(Range<T> first, Range<T> second)
        {
            return first.Min.Equals(second.Min) && first.Max.Equals(second.Max) && first.MaxInclusive.Equals(second.MaxInclusive);
        }

        public static bool operator !=(Range<T> first, Range<T> second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Determines if a value is contained with the segment
        /// </summary>
        /// <param name="item">The item to check</param>
        /// <returns>True if item is contained in the range - taking into acount MaxInclusive</returns>
        public bool Contains(T item)
        {
            if (MaxInclusive)
            {
                return item.CompareTo(Min) >= 0 && item.CompareTo(Max) <= 0;
            }
            return item.CompareTo(Min) >= 0 && item.CompareTo(Max) < 0;
        }

        public static bool operator <(Range<T> first, Range<T> second)
        {
            return first.Min.CompareTo(second.Min) > 0 && first.Max.CompareTo(second.Max) < 0;
        }

        public static bool operator >(Range<T> first, Range<T> second)
        {
            return first.Min.CompareTo(second.Min) < 0 && first.Max.CompareTo(second.Max) > 0;
        }

        public static bool operator <=(Range<T> first, Range<T> second)
        {
            return (first.Min.CompareTo(second.Min) > 0 && first.Max.CompareTo(second.Max) < 0) || first == second;
        }

        public static bool operator >=(Range<T> first, Range<T> second)
        {
            return (first.Min.CompareTo(second.Min) < 0 && first.Max.CompareTo(second.Max) > 0) || first == second;
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
                return this == (Range<T>)obj;
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
            return Min.GetHashCode() ^ Max.GetHashCode() ^ MaxInclusive.GetHashCode();
        }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            return String.Format("{0} — {1}", Min, Max);
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

        /// <summary>
        /// <see cref="System.IComparable.CompareTo(object)"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (obj is Range<T>)
            {
                return this.CompareTo((Range<T>)obj);
            }

            throw new ArgumentException("Comparand must be of type Range<T>");
        }

        /// <summary>
        /// <see cref="System.IComparable{T}.CompareTo(T)"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Range<T> other)
        {
            if (this < other)
            {
                return -1;
            }

            if (this > other)
            {
                return 1;
            }

            return 0;
        }
    }    
}

using System;

namespace LinqStatistics
{
    /// <summary>
    /// An ordered pair of values, representing a segment.
    /// </summary>
    public struct Range
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> struct.
        /// </summary>
        /// <param name="min">The minimal value of segment.</param>
        /// <param name="max">The maximal value of segment.</param>
        /// <param name="maxInclusive">When true Contains will include the max value.</param>
        public Range(double min, double max, bool maxInclusive = false)
        {
            this.min = min;
            this.max = max;

            if (min.CompareTo(max) >= 0)
                throw new InvalidOperationException("Minimum must be less then maximum");

            _maxInclusive = maxInclusive;
        }

        private readonly bool _maxInclusive;
        /// <summary>
        /// Determines whether max should be included in the range or excluded
        /// </summary>
        public bool MaxInclusive
        {
            get { return _maxInclusive; }
        }

        private readonly double min;
        /// <summary>
        /// Gets the minimal value of segment.
        /// </summary>
        /// <value>The min.</value>
        public double Min
        {
            get { return min; }
        }

        private readonly double max;
        /// <summary>
        /// Gets the maximal value of segment.
        /// </summary>
        /// <value>The max.</value>
        public double Max
        {
            get { return max; }
        }

        /// <summary>
        /// The width of the range
        /// </summary>
        public double Width { get { return Max - Min; } }

        public static bool operator ==(Range first, Range second)
        {
            return first.min.Equals(second.min) && first.max.Equals(second.max);
        }

        public static bool operator !=(Range first, Range second)
        {
            return !(first == second);
        }

        public bool Contains(double item)
        {
            if (_maxInclusive)
            {
                return (item >= Min && item <= Max);
            }

            return (item >= Min && item < Max);
        }

        public static bool operator <(Range first, Range second)
        {
            return first.min.CompareTo(second.Min) > 0 && first.Max.CompareTo(second.Max) < 0;
        }

        public static bool operator >(Range first, Range second)
        {
            return first.Min.CompareTo(second.min) < 0 && first.Max.CompareTo(second.max) > 0;
        }

        public static bool operator <=(Range first, Range second)
        {
            return (first.min.CompareTo(second.Min) > 0 && first.Max.CompareTo(second.Max) < 0) || first == second;
        }

        public static bool operator >=(Range first, Range second)
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
            if (obj is Range)
            {
                Range other = (Range)obj;
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
        public bool Equals(Range other)
        {
            return this == other;
        }
    }
}

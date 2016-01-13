using System;
using System.Globalization;

namespace LinqStatistics
{
    /// <summary>
    /// An ordered pair of values, representing a segment.
    /// </summary>
    public struct Range<T> : IFormattable, IEquatable<Range<T>>, IComparable, IComparable<Range<T>> where T : struct, IComparable<T>, IFormattable, IEquatable<T>
    {
        private readonly T _min;
        private readonly T _max;

        /// <summary>
        /// Initializes a new instance of the <see cref="Range{T}"/> struct.
        /// </summary>
        /// <param name="min">The minimal value of segment.</param>
        /// <param name="max">The maximal value of segment.</param>
        public Range(T min, T max)
            : this(min, max, false)
        {
        }

        /// <summary>
        /// This ctor is used internally and used to bypass the max > min check during MinMax calculation
        /// </summary>
        /// <param name="min">The minimal value of segment.</param>
        /// <param name="max">The maximal value of segment.</param>
        /// <param name="noThrow">True to allow min to be less than max</param>
        internal Range(T min, T max, bool noThrow)
        {
            _min = min;
            _max = max;

            if (!noThrow && min.CompareTo(max) > 0)
                throw new InvalidOperationException("Minimum must be less then maximum");
        }

        /// <summary>
        /// Gets the minimal value of segment.
        /// </summary>
        /// <value>The Min.</value>
        public T Min => _min;

        /// <summary>
        /// Gets the maximal value of segment.
        /// </summary>
        /// <value>The Max.</value>
        public T Max => _max;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator ==(Range<T> first, Range<T> second)
        {
            return first.Min.Equals(second.Min) && first.Max.Equals(second.Max);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator !=(Range<T> first, Range<T> second)
        {
            return !(first == second);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator <(Range<T> first, Range<T> second)
        {
            return first.Min.CompareTo(second.Min) > 0 && first.Max.CompareTo(second.Max) < 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator >(Range<T> first, Range<T> second)
        {
            return first.Min.CompareTo(second.Min) < 0 && first.Max.CompareTo(second.Max) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator <=(Range<T> first, Range<T> second)
        {
            return first < second || first == second;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator >=(Range<T> first, Range<T> second)
        {
            return first > second || first == second;
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

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return Min.GetHashCode() ^ Max.GetHashCode();
        }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            return Format(Min.ToString(), Max.ToString());
        }

        private static string Format(string min, string max)
        {
            return String.Format("{0} — {1}", min, max);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ToString(IFormatProvider provider)
        {
            return Format(Min.ToString(null, provider), Max.ToString(null, provider));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            return Format(Min.ToString(format, CultureInfo.CurrentCulture), Max.ToString(format, CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider provider)
        {
            return Format(Min.ToString(format, provider), Max.ToString(format, provider));
        }
    }
}

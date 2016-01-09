using System;

namespace LinqStatistics
{
    public struct MinMax<T> where T : struct, IConvertible, IComparable
    {
        /// <summary>
        /// Minimum
        /// </summary>
        public T Min { get; internal set; }

        /// <summary>
        /// Maximum
        /// </summary>
        public T Max { get; internal set; }
         
        public T Range { get; internal set; }

        public MinMax(T min, T max, T range)
        {
            if (min.CompareTo(max) >= 0)
                throw new InvalidOperationException("Minimum must be less then maximum");

            Min = min;
            Max = max;
            Range = range;
        }

        public static bool operator ==(MinMax<T> lhs, MinMax<T> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(MinMax<T> lhs, MinMax<T> rhs)
        {
            return !(lhs == rhs);
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
            if (obj is MinMax<T>)
            {
                MinMax<T> other = (MinMax<T>)obj;

                return this.Max.Equals(other.Max) && this.Min.Equals(other.Min) && this.Range.Equals(other.Range);
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
            return Max.GetHashCode() ^ Min.GetHashCode() ^ Range.GetHashCode();
        }
    }
}

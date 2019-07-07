using System;
using System.Globalization;

namespace LinqStatistics
{
    /// <summary>
    /// A discrete count of items which fall into a given range
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(false)] // code analysis was complaining that this type was marked as com visible
    public sealed class Bin : ItemCount<double>, IEquatable<Bin>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="v">Representative value for the Bin</param>
        /// <param name="min">The minimum value of the Range</param>
        /// <param name="max">The maximum value of the range</param>
        /// <param name="count">The number of items in the Bin</param>
        /// <param name="maxInclusive">Should Max be included in the Range or excluded - default is excluded</param>
        public Bin(double v, double min, double max, int count, bool maxInclusive = false)
            : base(v, count)
        {
            Range = new Range<double>(min, max);
            MaxInclusive = maxInclusive;
        }

        internal Bin(double v, double min, double max, bool maxInclusive = false)
            : this(v, min, max, 0, maxInclusive)
        {
        }

        /// <summary>
        /// Determines whether Max should be included or excluded in the range
        /// </summary>
        public bool MaxInclusive { get; private set; }

        /// <summary>
        /// The range
        /// </summary>
        public Range<double> Range { get; private set; }

        /// <summary>
        /// Determines if a value is contained with the segment
        /// </summary>
        /// <param name="item">The item to check</param>
        /// <returns>True if item is contained in the range - taking into acount MaxInclusive</returns>
        public bool Contains(double item)
        {
            if (MaxInclusive)
            {
                return item.CompareTo(Range.Min) >= 0 && item.CompareTo(Range.Max) <= 0;
            }

            return item.CompareTo(Range.Min) >= 0 && item.CompareTo(Range.Max) < 0;
        }

        /// <summary>
        /// <see cref="System.Object.GetHashCode"/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = base.GetHashCode();
            hash = hash * 23 + Range.GetHashCode();
            hash = hash * 23 + MaxInclusive.GetHashCode();
            return hash;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(Bin lhs, Bin rhs)
        {
            if (object.ReferenceEquals(null, lhs) && object.ReferenceEquals(rhs, null))
            {
                return true;
            }

            if (object.ReferenceEquals(null, lhs) || object.ReferenceEquals(rhs, null))
            {
                return false;
            }

            return lhs.Equals(rhs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(Bin lhs, Bin rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// <see cref="System.Object.Equals(object)"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Bin b)
            {
                this.Equals(b);
            }

            return false;
        }

        /// <summary>
        /// <see cref="System.IEquatable{T}.Equals(T)"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Bin other)
        {
            if (base.Equals(other))
            {
                return other.Range == this.Range && other.MaxInclusive == this.MaxInclusive;
            }

            return false;
        }

        /// <summary>
        /// <see cref="System.Object.ToString"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + " " + Range.ToString(CultureInfo.CurrentCulture);
        }
    }
}

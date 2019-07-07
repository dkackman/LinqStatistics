using System;
using System.Globalization;

namespace LinqStatistics
{
    /// <summary>
    /// Represents the count of an item in a collection
    /// </summary>
    /// <typeparam name="T">The type of the item</typeparam>
    public class ItemCount<T> : IEquatable<ItemCount<T>>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="v"></param>
        /// <param name="count"></param>
        public ItemCount(T v, int count)
        {
            RepresentativeValue = v;
            Count = count;
        }

        internal ItemCount(T v)
            : this(v, 0)
        {
        }

        /// <summary>
        /// The value represented by the bin
        /// </summary>
        public T RepresentativeValue { get; private set; }

        /// <summary>
        /// The number of times RepresentativeValue appears in the source data
        /// </summary>
        public int Count { get;

            // this is marked internal so histogram binning can update Count while counting
            internal set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(ItemCount<T> lhs, ItemCount<T> rhs)
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
        public static bool operator !=(ItemCount<T> lhs, ItemCount<T> rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// <see cref="System.Object.Equals(object)"/>
        /// </summary>
        /// <param name="obj">The item to compare to.</param>
        /// <returns>True if obj is a Bin{T} and Value and Count are equal</returns>
        public override bool Equals(object obj)
        {
            if (obj is ItemCount<T> c)
            {
                return this.Equals(c);
            }

            return false;
        }

        /// <summary>
        /// <see cref="System.IEquatable{T}.Equals(T)"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ItemCount<T> other)
        {
            if (other == null)
            {
                return false;
            }

            if (RepresentativeValue != null)
            {
                return this.RepresentativeValue.Equals(other.RepresentativeValue) && this.Count == other.Count;
            }

            return other.RepresentativeValue == null && this.Count == other.Count;
        }

        /// <summary>
        /// <see cref="System.Object.GetHashCode"/>
        /// </summary>
        /// <returns>Hash of Value and Count</returns>
        public override int GetHashCode()
        {
            if (RepresentativeValue == null)
            {
                int hash = 17;
                hash = hash * 23 + RepresentativeValue.GetHashCode();
                hash = hash * 23 + Count.GetHashCode();
                return hash;
            }

            return 0;
        }

        /// <summary>
        /// <see cref="System.Object.ToString"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "v={0}:c={1}", RepresentativeValue, Count);
        }
    }
}

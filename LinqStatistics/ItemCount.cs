using System;

namespace LinqStatistics
{
    /// <summary>
    /// Represents the count of an item in a collection
    /// </summary>
    /// <typeparam name="T">The type of the item</typeparam>
    public class ItemCount<T> : IEquatable<ItemCount<T>>
    {
        private readonly T _value;
        private int _count;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="v"></param>
        /// <param name="count"></param>
        public ItemCount(T v, int count)
        {
            _value = v;
            _count = count;
        }

        internal ItemCount(T v)
            : this(v, 0)
        {
        }

        /// <summary>
        /// The value represented by the bin
        /// </summary>
        public T RepresentativeValue => _value;

        /// <summary>
        /// The number of times RepresentativeValue appears in the source data
        /// </summary>
        public int Count
        {
            get { return _count; }

            // this is marked internal so histogram binning can update Count while counting
            internal set { _count = value; }
        }

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
            if (obj is ItemCount<T>)
            {
                return this.Equals((ItemCount<T>)obj);
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
            if (_value != null)
            {
                return this._value.Equals(other._value) && this._count == other._count;
            }

            return other._value == null && this._count == other._count;
        }

        /// <summary>
        /// <see cref="System.Object.GetHashCode"/>
        /// </summary>
        /// <returns>Hash of Value and Count</returns>
        public override int GetHashCode()
        {
            return (_value != null ? _value.GetHashCode() : 0) ^ _count.GetHashCode();
        }

        /// <summary>
        /// <see cref="System.Object.ToString"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("v={0}:c={1}", _value, _count);
        }
    }
}

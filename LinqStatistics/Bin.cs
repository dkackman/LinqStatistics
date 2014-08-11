using System.Linq;
using System.Collections;

namespace LinqStatistics
{
    /// <summary>
    /// Represents a Histogram bin
    /// </summary>
    /// <typeparam name="T">The type of the Bin value</typeparam>
    public class Bin<T>
    {
        private readonly T _value;
        private int _count;

        /// <summary>
        /// The value represented by the bin
        /// </summary>
        public T RepresentativeValue { get { return _value; } }

        /// <summary>
        /// The number of times Value appears in the source data
        /// </summary>
        public int Count
        { 
            get { return _count; } 
            internal set { _count = value; } 
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="v"></param>
        /// <param name="count"></param>
        public Bin(T v, int count)
        {
            _value = v;
            _count = count;
        }

        /// <summary>
        /// <see cref="System.Object.Equals"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if obj is a Bin{T} and Value and Count are equal</returns>
        public override bool Equals(object obj)
        {
            if (obj is Bin<T>)
            {
                Bin<T> other = (Bin<T>)obj;
                if (_value != null)
                {
                    return this._value.Equals(other._value) && this._count == other._count;
                }
                return other._value == null && this._count == other._count;
            }
            return false;
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
            return string.Format("v{0}:c{1}", _value, _count);
        }
    }
}

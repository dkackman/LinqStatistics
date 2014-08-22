using System;

namespace LinqStatistics
{
    /// <summary>
    /// A discrete count of items which fall into a given range
    /// </summary>
    public class Bin : ItemCount<double>
    {
        private readonly Range _range;

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
            _range = new Range(min, max, maxInclusive);
        }

        internal Bin(double v, double min, double max, bool maxInclusive = false)
            : this(v, min, max, 0, maxInclusive)
        {
            
        }

        /// <summary>
        /// The range
        /// </summary>
        public Range Range { get { return _range; } }

        /// <summary>
        /// <see cref="System.Object.GetHashCode"/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _range.GetHashCode();
        }

        /// <summary>
        /// <see cref="System.Object.Equals(object)"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Bin && base.Equals(obj))
            {
                return ((Bin)obj)._range == this._range;
            }

            return false;
        }

        /// <summary>
        /// <see cref="System.Object.ToString"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + " " + _range.ToString();
        }
    }
}

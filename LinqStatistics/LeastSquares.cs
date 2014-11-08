using System;

namespace LinqStatistics
{
    /// <summary>
    /// Represent the result of a LeastSquares calculation of the form y = mX + b
    /// </summary>
    public struct LeastSquares
    {
        private readonly double _m;
        private readonly double _b;

        /// <summary>
        /// M Coefficient for y = Mx + B
        /// </summary>
        public double M { get { return _m; } }
        /// <summary>
        /// B Coefficient for y = Mx + B
        /// </summary>
        public double B { get { return _b; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m">The slope</param>
        /// <param name="b">the intercept</param>
        public LeastSquares(double m, double b)
        {
            _m = m;
            _b = b;
        }

        /// <summary>
        /// Uses the calculated coefficients to solve Y for inputted X
        /// </summary>
        /// <param name="x">X value to solve for</param>
        /// <returns>Y value (y = Mx + B)</returns>
        public double Solve(double x)
        {
            return (M * x) + B;
        }

        public double SolveForX(double y)
        {
            return (y - B) / M;
        }

        public static bool operator ==(LeastSquares lhs, LeastSquares rhs)
        {
            return lhs.M == rhs.M && lhs.B == rhs.B;
        }
        public static bool operator !=(LeastSquares lhs, LeastSquares rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// <see cref="System.Object.Equals(object)"/>
        /// </summary>
        /// <param name="obj">The object to compare to</param>
        /// <returns>True if obj is a LeastSquares and has equal m and b values</returns>
        public override bool Equals(object obj)
        {
            if (obj is LeastSquares)
                return this == (LeastSquares)obj;

            return false;
        }

        /// <summary>
        /// <see cref="System.Object.GetHashCode"/>
        /// </summary>
        /// <returns>Hascode of the instance</returns>
        public override int GetHashCode()
        {
            return _m.GetHashCode() ^ _b.GetHashCode();
        }

        private static string Format(string m, string b)
        {
            return string.Format("y = ({0} * x) + {1}", m, b);
        }

        /// <summary>
        /// <see cref="System.Object.ToString"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Format(_m.ToString(), _b.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ToString(IFormatProvider provider)
        {
            return Format(_m.ToString(provider), _b.ToString(provider));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            return Format(_m.ToString(format), _b.ToString(format));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider provider)
        {
            return Format(_m.ToString(format, provider), _b.ToString(format, provider));
        }
    }
}

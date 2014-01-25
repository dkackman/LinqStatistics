using System;

namespace LinqStatistics
{
    public struct LeastSquares
    {
        private double _m;
        private double _b;

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
        /// <returns>Y value (y = Mx + C)</returns>
        public double Solve(double x)
        {
            return (M * x) + B;
        }

        public static bool operator ==(LeastSquares lhs, LeastSquares rhs)
        {
            return lhs.M == rhs.M && lhs.B == rhs.B;
        }
        public static bool operator !=(LeastSquares lhs, LeastSquares rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            if (obj is LeastSquares)
                return this == (LeastSquares)obj;

            return false;
        }

        public override int GetHashCode()
        {
            return _m.GetHashCode() ^ _b.GetHashCode();
        }

        private static string Format(string m, string b)
        {
            return string.Format("y = ({0} * x) + {1}", m, b);
        }

        public override string ToString()
        {
            return Format(_m.ToString(), _b.ToString());
        }

        public string ToString(IFormatProvider provider)
        {
            return Format(_m.ToString(provider), _b.ToString(provider));
        }

        public string ToString(string format)
        {
            return Format(_m.ToString(format), _b.ToString(format));
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return Format(_m.ToString(format, provider), _b.ToString(format, provider));
        }
    }
}

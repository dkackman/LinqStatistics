using System;
using System.Globalization;

namespace LinqStatistics
{
    /// <summary>
    /// Represents the result of a LeastSquares calculation of the form y = mX + b
    /// </summary>
    public struct LeastSquares : IFormattable, IEquatable<LeastSquares>
    {
        /// <summary>
        /// Empty instance - returned when EnumerableStats.LeastSquares is passed a singular matrix.
        /// All members are zero.
        /// </summary>
        public static readonly LeastSquares Empty = new LeastSquares(0, 0, 0);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m">The slope</param>
        /// <param name="b">The intercept</param>
        public LeastSquares(double m, double b)
            : this(m, b, 1)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m">The slope</param>
        /// <param name="b">The intercept</param>
        /// <param name="r2">The R Squared correlation coefficient</param>
        public LeastSquares(double m, double b, double r2)
        {
            M = m;
            B = b;
            RSquared = r2;
        }

        /// <summary>
        /// M Coefficient for y = Mx + B
        /// (i.e. slope)
        /// </summary>
        public double M { get; private set; }

        /// <summary>
        /// B Coefficient for y = Mx + B
        /// (i.e. y intercept)
        /// </summary>
        public double B { get; private set; }

        /// <summary>
        /// The R Squared correlation coefficient
        /// </summary>
        public double RSquared { get; private set; }

        /// <summary>
        /// Uses the calculated coefficients to solve Y for inputted X
        /// </summary>
        /// <param name="x">X value to solve for</param>
        /// <returns>Y value (y = Mx + B)</returns>
        public double Solve(double x)
        {
            return (M * x) + B;
        }

        /// <summary>
        /// Uses the calculated coefficients to solve X for inputted Y
        /// </summary>
        /// <param name="y">Y value to solve for</param>
        /// <returns>X value (x = (y - b) / m)</returns>
        public double SolveForX(double y)
        {
            if (M == 0.0) throw new InvalidOperationException("Cannot solve for X when the equation slope (M) is zero");

            return (y - B) / M;
        }

        /// <summary>
        /// Casts a LeastSqaures to a Function <see cref="Solve(double)"/>
        /// </summary>
        /// <param name="ls">The LeastSquares instance</param>
        public static implicit operator Func<double, double>(LeastSquares ls)
        {
            return (double d) => ls.Solve(d);
        }

        /// <summary>
        /// Casts a LeastSqaures to a Function <see cref="Solve(double)"/>
        /// </summary>
        /// <param name="ls">The LeastSquares instance</param>
        public static Func<double, double> ToFunc(LeastSquares ls)
        {
            return (double d) => ls.Solve(d);
        }

        /// <summary>
        /// Equality operator (M, B and RSquared must be equal)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(LeastSquares lhs, LeastSquares rhs)
        {
            return lhs.M == rhs.M && lhs.B == rhs.B && lhs.RSquared == rhs.RSquared;
        }

        /// <summary>
        /// Inequality operatory
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
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
            if (obj is LeastSquares ls)
            {
                return this == ls;
            }

            return false;
        }

        /// <summary>
        /// <see cref="System.IEquatable{T}.Equals(T)"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns>True if other has equal m and b values</returns>
        public bool Equals(LeastSquares other)
        {
            return this == other;
        }

        /// <summary>
        /// <see cref="System.Object.GetHashCode"/>
        /// </summary>
        /// <returns>Hascode of the instance</returns>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + M.GetHashCode();
            hash = hash * 23 + B.GetHashCode();
            hash = hash * 23 + RSquared.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Determines if the <see cref="LeastSquares"/> argument has Not a Number elements
        /// </summary>
        /// <param name="ls"></param>
        /// <returns>True if either <see cref="M"/>, <see cref="B"/> or <see cref="RSquared"/> is <see cref="double.NaN"/></returns>
        public static bool IsNaN(LeastSquares ls)
        {
            return double.IsNaN(ls.M) || double.IsNaN(ls.B) || double.IsNaN(ls.RSquared);
        }

        private static string Format(string m, string b)
        {
            return string.Format(CultureInfo.CurrentCulture, "y = ({0} * x) + {1}", m, b);
        }

        /// <summary>
        /// <see cref="System.Object.ToString"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Format(M.ToString(CultureInfo.CurrentCulture), B.ToString(CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ToString(IFormatProvider provider)
        {
            return Format(M.ToString(provider), B.ToString(provider));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            return Format(M.ToString(format, CultureInfo.CurrentCulture), B.ToString(format, CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider provider)
        {
            return Format(M.ToString(format, provider), B.ToString(format, provider));
        }
    }
}


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

        /// <param name="points">Known points which are used to calculated coefficients</param>
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
    }
}

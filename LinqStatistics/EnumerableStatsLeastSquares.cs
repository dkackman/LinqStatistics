using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStatistics
{
    public static partial class EnumerableStats
    {
    	
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<int?, int?>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            
            IEnumerable<Tuple<int, int>> values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }

        public static LeastSquares LeastSquares(this IEnumerable<Tuple<int, int>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int numPoints = 0;
            double sumX = 0;
            double sumY = 0;
            double sumXX = 0;
            double sumXY = 0;

            foreach (var tuple in source)
            {
                numPoints++;
                sumX += (double)tuple.Item1;
                sumY += (double)tuple.Item2;
                sumXX += (double)(tuple.Item1 * tuple.Item1);
                sumXY += (double)(tuple.Item1 * tuple.Item2);
            }

            if (numPoints < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");

            double b = (-sumX * sumXY + sumXX * sumY) / (numPoints * sumXX - sumX * sumX);
            double m = (-sumX * sumY + numPoints * sumXY) / (numPoints * sumXX - sumX * sumX);

            return new LeastSquares(m, b);
        }

        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<int?, int?>> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }

        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<int, int>> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }
 	
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<long?, long?>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            
            IEnumerable<Tuple<long, long>> values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }

        public static LeastSquares LeastSquares(this IEnumerable<Tuple<long, long>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int numPoints = 0;
            double sumX = 0;
            double sumY = 0;
            double sumXX = 0;
            double sumXY = 0;

            foreach (var tuple in source)
            {
                numPoints++;
                sumX += (double)tuple.Item1;
                sumY += (double)tuple.Item2;
                sumXX += (double)(tuple.Item1 * tuple.Item1);
                sumXY += (double)(tuple.Item1 * tuple.Item2);
            }

            if (numPoints < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");

            double b = (-sumX * sumXY + sumXX * sumY) / (numPoints * sumXX - sumX * sumX);
            double m = (-sumX * sumY + numPoints * sumXY) / (numPoints * sumXX - sumX * sumX);

            return new LeastSquares(m, b);
        }

        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<long?, long?>> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }

        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<long, long>> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }
 	
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<float?, float?>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            
            IEnumerable<Tuple<float, float>> values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }

        public static LeastSquares LeastSquares(this IEnumerable<Tuple<float, float>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int numPoints = 0;
            double sumX = 0;
            double sumY = 0;
            double sumXX = 0;
            double sumXY = 0;

            foreach (var tuple in source)
            {
                numPoints++;
                sumX += (double)tuple.Item1;
                sumY += (double)tuple.Item2;
                sumXX += (double)(tuple.Item1 * tuple.Item1);
                sumXY += (double)(tuple.Item1 * tuple.Item2);
            }

            if (numPoints < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");

            double b = (-sumX * sumXY + sumXX * sumY) / (numPoints * sumXX - sumX * sumX);
            double m = (-sumX * sumY + numPoints * sumXY) / (numPoints * sumXX - sumX * sumX);

            return new LeastSquares(m, b);
        }

        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<float?, float?>> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }

        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<float, float>> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }
 	
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<double?, double?>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            
            IEnumerable<Tuple<double, double>> values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }

        public static LeastSquares LeastSquares(this IEnumerable<Tuple<double, double>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int numPoints = 0;
            double sumX = 0;
            double sumY = 0;
            double sumXX = 0;
            double sumXY = 0;

            foreach (var tuple in source)
            {
                numPoints++;
                sumX += (double)tuple.Item1;
                sumY += (double)tuple.Item2;
                sumXX += (double)(tuple.Item1 * tuple.Item1);
                sumXY += (double)(tuple.Item1 * tuple.Item2);
            }

            if (numPoints < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");

            double b = (-sumX * sumXY + sumXX * sumY) / (numPoints * sumXX - sumX * sumX);
            double m = (-sumX * sumY + numPoints * sumXY) / (numPoints * sumXX - sumX * sumX);

            return new LeastSquares(m, b);
        }

        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<double?, double?>> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }

        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<double, double>> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }
 	
        public static LeastSquares? LeastSquares(this IEnumerable<Tuple<decimal?, decimal?>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            
            IEnumerable<Tuple<decimal, decimal>> values = source.AllValues();
            if (values.Any())
                return values.LeastSquares();

            return null;
        }

        public static LeastSquares LeastSquares(this IEnumerable<Tuple<decimal, decimal>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int numPoints = 0;
            double sumX = 0;
            double sumY = 0;
            double sumXX = 0;
            double sumXY = 0;

            foreach (var tuple in source)
            {
                numPoints++;
                sumX += (double)tuple.Item1;
                sumY += (double)tuple.Item2;
                sumXX += (double)(tuple.Item1 * tuple.Item1);
                sumXY += (double)(tuple.Item1 * tuple.Item2);
            }

            if (numPoints < 2)
                throw new InvalidOperationException("Source must have at least 2 elements");

            double b = (-sumX * sumXY + sumXX * sumY) / (numPoints * sumXX - sumX * sumX);
            double m = (-sumX * sumY + numPoints * sumXY) / (numPoints * sumXX - sumX * sumX);

            return new LeastSquares(m, b);
        }

        public static LeastSquares? LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<decimal?, decimal?>> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }

        public static LeastSquares LeastSquares<TSource>(this IEnumerable<TSource> source, Func<TSource, Tuple<decimal, decimal>> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(selector).LeastSquares();
        }
     }
}